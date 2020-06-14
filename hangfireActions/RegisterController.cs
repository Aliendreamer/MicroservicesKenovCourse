using System;
using Hangfire;

namespace HangfireActions
{
   public class RegisterController
   {
      public static void RegisterJob<T>(Action<T> action) where T : class
      {
         BackgroundJob.Enqueue<T>(action);
      }
   }
}