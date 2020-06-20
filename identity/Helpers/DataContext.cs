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

      public DbSet<Role> Roles { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<User>()
             .HasOne(a => a.UserRole)
             .WithOne(b => b.User)
             .HasForeignKey<User>(u => u.RoleId);
      }
   }
}