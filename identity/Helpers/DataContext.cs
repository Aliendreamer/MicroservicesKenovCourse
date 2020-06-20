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
             modelBuilder.Entity<Role>()
            .HasOne(b => b.User)
            .WithOne(i => i.Role)
            .HasForeignKey<User>(b => b.UserRole);
      }
   }
}