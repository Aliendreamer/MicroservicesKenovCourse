namespace IdentityService.Entities
{
   using System.Collections.Generic;
   using System.Text.Json.Serialization;

   public class User
   {
      public int Id { get; set; }

      public string FirstName { get; set; }

      public string LastName { get; set; }

      public string Username { get; set; }

      public int RoleId { get; set; }

      public Role UserRole { get; set; }

      [JsonIgnore]
      public string Password { get; set; }

      [JsonIgnore]
      public List<RefreshToken> RefreshTokens { get; set; }
   }
}