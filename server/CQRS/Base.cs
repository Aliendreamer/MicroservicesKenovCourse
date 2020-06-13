using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Server.CQRS
{
   public interface IBase
   {
        IDbConnection Connection { get; }
   }

   public class Base : IBase
   {
      private IConfiguration config;

      public Base(IConfiguration configuration)
      {
         this.config = configuration;
      }

      public IDbConnection Connection => new SqlConnection(this.config.GetConnectionString("ConnectionString"));
   }
}
