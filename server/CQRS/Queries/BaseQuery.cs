using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace server.CQRS.Queries
{
    public interface IBaseQuery<T> where T:class
    {
        Task<IEnumerable<T>> GetList(string query);
        Task<T> Get(string query);
    }
    public class BaseQuery<T> :Base, IBaseQuery<T> where T:class
    {
          public IConfiguration configuration { get; set; }
         public BaseQuery(IConfiguration configuration)
                :base(configuration)
         {
            this.configuration = configuration;
         }

       
      public async Task<T> Get(string query)
      {
          using var connection = this.Connection;
          return  await connection.QuerySingleAsync<T>(query);
      }

      public async Task<IEnumerable<T>> GetList(string query)
      {
          using var connection = this.Connection;
          return  await connection.QueryAsync<T>(query);
      }
   }

}