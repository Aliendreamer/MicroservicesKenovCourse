using System.Collections.Generic;

namespace server.CQRS.Queries
{
   public interface IBaseQuery<T>
   {
        IEnumerable<T> GetList();
        T GetItem(int id);
   }
   public abstract class BaseQuery<T> : IBaseQuery<T>
   {
      public T GetItem(int id)
      {
         throw new System.NotImplementedException();
      }

      public IEnumerable<T> GetList()
      {
         throw new System.NotImplementedException();
      }
   }

}