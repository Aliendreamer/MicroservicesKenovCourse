using System;

namespace HangfireActions
{
    public interface IUserHandler
    {
        void RegisterNewUser();
    }
    public class UserHandler:IUserHandler,IHandler
    {
        public void RegisterNewUser()
        {
              Console.WriteLine("It works");
        }
    }
}
