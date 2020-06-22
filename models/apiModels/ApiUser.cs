namespace Models.apiModels
{
   using System;
   // using Dapper.Contrib.Extensions;

   // [Table("Users")]
   public class ApiUser
   {
      public int Id { get; set; }

      public int UserId { get; set; }

      public bool Enabled { get; set; }

      public DateTime LastLogin { get; set; }
   }
}