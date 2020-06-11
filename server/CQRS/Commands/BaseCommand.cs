using System;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace server.CQRS.Commands
{
    public interface IBaseCommand 
    {
        Task<int> Delete(string query);
        Task<int> Update(string query);
        Task<int> Create(string query,object obj);

    }
    public class BaseCommand : IBaseCommand 
    {
      public ILogger<BaseCommand> Logger { get; }
      public IConfiguration Configuration { get; set; }
         public BaseCommand(ILogger<BaseCommand> logger,IConfiguration configuration)
         {
         Logger = logger;
         this.Configuration = configuration;
         }

      public Task<int> Delete(string query)
      {
         throw new System.NotImplementedException();
      }

      public Task<int> Update(string query)
      {
         throw new System.NotImplementedException();
      }

      public async  Task<int> Create(string query,object obj)
      {
         try
         {
            using var connection = new NpgsqlConnection(Configuration.GetConnectionString("PostgresString"));
            await connection.OpenAsync();
            return  await connection.ExecuteAsync(query,obj);
         }catch(Exception ex){
            Logger.LogError(ex,$"Creating entity in database failed with {ex.Message} and  with trace {ex.StackTrace}");
            return 0;
         }
         finally
         {
            Logger.LogInformation("Creating entity in database succeeded");   
         }
         
      }
   }

}