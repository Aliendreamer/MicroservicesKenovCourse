namespace IdentityService.Services
{
   using System;
   using System.IdentityModel.Tokens.Jwt;
   using System.Linq;
   using System.Security.Claims;
   using System.Security.Cryptography;
   using System.Text;
   using System.Threading.Tasks;
   using HangfireActions;
   using IdentityService.Entities;
   using IdentityService.Helpers;
   using IdentityService.Models;
   using Microsoft.EntityFrameworkCore;
   using Microsoft.Extensions.Options;
   using Microsoft.IdentityModel.Tokens;

   public interface IUserService
   {
      AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);

      AuthenticateResponse RefreshToken(string token, string ipAddress);

      bool RevokeToken(string token, string ipAddress);

      User GetById(int id);

      Task<AuthenticateResponse> CreateUser(UserRegisterRequest request, string url);
   }

   public class UserService : IUserService
   {
      private readonly AppSettings appSettings;

      private readonly DataContext context;

      public UserService(
         DataContext context,
         IOptions<AppSettings> appSettings)
      {
         this.context = context;
         this.appSettings = appSettings.Value;
      }

      public async Task<AuthenticateResponse> CreateUser(UserRegisterRequest request, string ip)
      {
         var adminRole = await this.context.Roles.FirstOrDefaultAsync(x => x.Name == "Admin");
         var user = new User
         {
            Username = request.Username,
            Password = request.Password,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = adminRole,
         };
         await this.context.Users.AddAsync(user);
         await this.context.SaveChangesAsync();
         RegisterController.RegisterJob<UserHandler>((UserHandler) => UserHandler.RegisterNewUser(user.Id));
         return this.Authenticate(new AuthenticateRequest { Username = request.Username, Password = request.Password }, ip);
      }

      public AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress)
      {
         var user = this.context.Users.Include(x => x.Role)
                                      .SingleOrDefault(x => x.Username.ToLower() == model.Username.ToLower()
                                       && x.Password.ToLower() == model.Password.ToLower());

         // return null if user not found
         if (user == null) return null;

         // authentication successful so generate jwt and refresh tokens
         var jwtToken = this.GenerateJwtToken(user);
         var refreshToken = this.GenerateRefreshToken(ipAddress);

         // save refresh token
         user.RefreshTokens.Add(refreshToken);
         this.context.Update(user);
         this.context.SaveChanges();
         RegisterController.RegisterJob<UserHandler>((UserHandler) => UserHandler.LoginUser(user.Id));
         return new AuthenticateResponse(user, jwtToken, refreshToken.Token);
      }

      public AuthenticateResponse RefreshToken(string token, string ipAddress)
      {
         var user = this.context.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));

         // return null if no user found with token
         if (user == null) return null;

         var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

         // return null if token is no longer active
         if (!refreshToken.IsActive) return null;

         // replace old refresh token with a new one and save
         var newRefreshToken = this.GenerateRefreshToken(ipAddress);
         refreshToken.Revoked = DateTime.UtcNow;
         refreshToken.RevokedByIp = ipAddress;
         refreshToken.ReplacedByToken = newRefreshToken.Token;
         user.RefreshTokens.Add(newRefreshToken);
         this.context.Update(user);
         this.context.SaveChanges();

         // generate new jwt
         var jwtToken = this.GenerateJwtToken(user);

         return new AuthenticateResponse(user, jwtToken, newRefreshToken.Token);
      }

      public bool RevokeToken(string token, string ipAddress)
      {
         var user = this.context.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));

         // return false if no user found with token
         if (user == null) return false;

         var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

         // return false if token is not active
         if (!refreshToken.IsActive) return false;

         // revoke token and save
         refreshToken.Revoked = DateTime.UtcNow;
         refreshToken.RevokedByIp = ipAddress;
         this.context.Update(user);
         this.context.SaveChanges();

         return true;
      }

      public User GetById(int id)
      {
         return this.context.Users.Find(id);
      }

      // helper methods
      private string GenerateJwtToken(User user)
      {
         var tokenHandler = new JwtSecurityTokenHandler();
         var key = Encoding.ASCII.GetBytes(this.appSettings.Secret);
         var tokenDescriptor = new SecurityTokenDescriptor
         {
            Subject = new ClaimsIdentity(new Claim[]
            {
               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
               new Claim(ClaimTypes.Role, user.Role.Name),
            }),
            Expires = DateTime.UtcNow.AddDays(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
         };
         var token = tokenHandler.CreateToken(tokenDescriptor);
         return tokenHandler.WriteToken(token);
      }

      private RefreshToken GenerateRefreshToken(string ipAddress)
      {
         using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
         var randomBytes = new byte[64];
         rngCryptoServiceProvider.GetBytes(randomBytes);
         return new RefreshToken
         {
            Token = Convert.ToBase64String(randomBytes),
            Expires = DateTime.UtcNow.AddDays(7),
            Created = DateTime.UtcNow,
            CreatedByIp = ipAddress,
         };
      }
   }
}