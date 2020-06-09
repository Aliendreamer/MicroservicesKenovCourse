using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.CQRS.Queries
{
    public interface IBaseQuery<T> where T:class
    {
        Task<IEnumerable<T>> GetList(string query);
        Task<T> Get(string query);
    }
    public class BaseQuery<T> : IBaseQuery<T> where T:class
    {
        public Task<T> Get(string query)
      {
         throw new System.NotImplementedException();
      }

      public Task<IEnumerable<T>> GetList(string query)
      {
         throw new System.NotImplementedException();
      }
   }

}