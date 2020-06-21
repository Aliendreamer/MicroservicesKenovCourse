namespace HangfireActions
{
   using System;

   public interface IUserHandler
   {
      void RegisterNewUser();
   }

   public class UserHandler : IUserHandler, IHandler
   {
      public void RegisterNewUser()
      {
         Console.WriteLine("It works");
      }
   }
}
