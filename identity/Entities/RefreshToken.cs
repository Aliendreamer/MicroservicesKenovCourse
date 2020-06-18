namespace IdentityService.Entities
{
   using System;
   using Microsoft.EntityFrameworkCore;

   [Owned]
   public class RefreshToken
   {
      public string Token { get; set; }

      public DateTime Expires { get; set; }

      public bool IsExpired => DateTime.UtcNow >= this.Expires;

      public DateTime Created { get; set; }

      public string CreatedByIp { get; set; }

      public DateTime? Revoked { get; set; }

      public string RevokedByIp { get; set; }

      public string ReplacedByToken { get; set; }

      public bool IsActive => this.Revoked == null && !this.IsExpired;
   }
}