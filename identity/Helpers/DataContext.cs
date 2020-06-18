namespace IdentityService.Helpers
{
   using IdentityService.Entities;
   using Microsoft.EntityFrameworkCore;

   public class DataContext : DbContext
   {
      public DataContext(DbContextOptions<DataContext> options)
       : base(options)
      {
      }

      public DbSet<User> Users { get; set; }
   }
}