namespace IdentityService.Controllers
{
   using System;
   using System.Threading.Tasks;
   using IdentityService.Models;
   using IdentityService.Services;
   using Microsoft.AspNetCore.Authorization;
   using Microsoft.AspNetCore.Http;
   using Microsoft.AspNetCore.Mvc;

   [Authorize]
   [ApiController]
   [Route("[controller]")]
   public class UsersController : ControllerBase
   {
      private readonly IUserService userService;

      public UsersController(IUserService userService)
      {
         this.userService = userService;
      }

      [AllowAnonymous]
      [HttpPost("authenticate")]
      public IActionResult Authenticate([FromBody] AuthenticateRequest model)
      {
         var response = this.userService.Authenticate(model, this.IpAddress());

         if (response == null)
            return this.BadRequest(new { message = "Username or password is incorrect" });

         this.SetTokenCookie(response.RefreshToken);

         return this.Ok(response);
      }

      [AllowAnonymous]
      [HttpPost("refresh-token")]
      public IActionResult RefreshToken()
      {
         var refreshToken = this.Request.Cookies["refreshToken"];
         var response = this.userService.RefreshToken(refreshToken, this.IpAddress());

         if (response == null)
            return this.Unauthorized(new { message = "Invalid token" });

         this.SetTokenCookie(response.RefreshToken);

         return this.Ok(response);
      }

      [HttpPost("revoke-token")]
      public IActionResult RevokeToken([FromBody] RevokeTokenRequest model)
      {
         // accept token from request body or cookie
         var token = model.Token ?? this.Request.Cookies["refreshToken"];

         if (string.IsNullOrEmpty(token))
            return this.BadRequest(new { message = "Token is required" });

         var response = this.userService.RevokeToken(token, this.IpAddress());

         if (!response)
            return this.NotFound(new { message = "Token not found" });

         return this.Ok(new { message = "Token revoked" });
      }

      [HttpGet("{id}")]
      public IActionResult GetById(int id)
      {
         var user = this.userService.GetById(id);
         return this.Ok(user);
      }

      [AllowAnonymous]
      [HttpPost("register")]
      public async Task<IActionResult> RegisterUser([FromBody] UserRegisterRequest request)
      {
         var response = await this.userService.CreateUser(request, this.IpAddress());
         return this.Ok(response);
      }

      // helper methods
      private void SetTokenCookie(string token)
      {
         var cookieOptions = new CookieOptions
         {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(7),
         };
         this.Response.Cookies.Append("refreshToken", token, cookieOptions);
      }

      private string IpAddress()
      {
         if (this.Request.Headers.ContainsKey("X-Forwarded-For"))
            return this.Request.Headers["X-Forwarded-For"];
         else
            return this.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
      }
   }
}
