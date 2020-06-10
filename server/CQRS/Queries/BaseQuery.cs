using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace server.CQRS.Queries
{
    public interface IBaseQuery<T> where T:class
    {
        Task<IEnumerable<T>> GetList(string query);
        Task<T> Get(string query);
    }
    public class BaseQuery<T> : IBaseQuery<T> where T:class
    {
          public IConfiguration configuration { get; set; }
         public BaseQuery(IConfiguration configuration)
         {
            this.configuration = configuration;
         }

       
      public async Task<T> Get(string query)
      {
          using var connection = new NpgsqlConnection("");
          await connection.OpenAsync();
          return  await connection.QuerySingleAsync<T>(query);
      }

      public async Task<IEnumerable<T>> GetList(string query)
      {
          using var connection = new NpgsqlConnection("");
          await connection.OpenAsync();
          return  await connection.QueryAsync<T>(query);
      }
   }

}