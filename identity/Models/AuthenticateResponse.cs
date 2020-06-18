namespace IdentityService.Models
{
   using System.Text.Json.Serialization;
   using IdentityService.Entities;

   public class AuthenticateResponse
   {
      public AuthenticateResponse(User user, string jwtToken, string refreshToken)
      {
         this.Id = user.Id;
         this.FirstName = user.FirstName;
         this.LastName = user.LastName;
         this.Username = user.Username;
         this.JwtToken = jwtToken;
         this.RefreshToken = refreshToken;
      }

      public int Id { get; set; }

      public string FirstName { get; set; }

      public string LastName { get; set; }

      public string Username { get; set; }

      public string JwtToken { get; set; }

      [JsonIgnore] // refresh token is returned in http only cookie
      public string RefreshToken { get; set; }
   }
}