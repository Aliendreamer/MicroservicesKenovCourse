

using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace server.CQRS
{
   public interface IBase
   {
        IDbConnection Connection {get;}
   }
   public class Base:IBase
   {
      private IConfiguration config;
      public Base(IConfiguration configuration )
      {
         config=configuration;
      }
     public IDbConnection Connection => new SqlConnection(config.GetConnectionString("ConnectionString"));
   }
}