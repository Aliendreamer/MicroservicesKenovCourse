namespace Server.Models
{
   using System;

   public class ApiUser
   {
      public int Id { get; set; }

      public int UserId { get; set; }

      public bool Enabled { get; set; }

      public DateTime LastLogin { get; set; }
   }
}