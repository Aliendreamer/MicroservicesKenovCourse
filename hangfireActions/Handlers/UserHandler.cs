namespace HangfireActions
{
   using System;
   using System.Data.SqlClient;
   using System.Threading.Tasks;
   using Dapper.Contrib.Extensions;
   using Models.apiModels;

   public interface IUserHandler
   {
      Task RegisterNewUser(int id);

      Task LoginUser(int id);
   }

   public class UserHandler : IUserHandler, IHandler
   {
      public UserHandler()
      {
          this.DbConnection = RegisterController.GetConnectionString("AppDbConnectionString");
          this.IdentityDbConnection = RegisterController.GetConnectionString("IdentityConnection");
      }

      private string DbConnection { get; }

      private string IdentityDbConnection { get; }

      public async Task RegisterNewUser(int id)
      {
         // TODO have to add logger here to log different things on success or fail
          using var dbConnection = new SqlConnection(this.DbConnection);
          await dbConnection.InsertAsync(new ApiUser { UserId = id, Enabled = true, LastLogin = DateTime.UtcNow });
      }

      public async Task LoginUser(int id)
      {
         using var dbConnection = new SqlConnection(this.DbConnection);
         await dbConnection.UpdateAsync(new ApiUser { UserId = id, LastLogin = DateTime.UtcNow });
      }
   }
}
