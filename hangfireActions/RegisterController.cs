using System.Linq.Expressions;
using System;
using Hangfire;
using Hangfire.SqlServer;

namespace HangfireActions
{
   public class RegisterController
   {
      public static void RegisterJob<T>(Expression<Action<T>> action) where T : class
      {
         JobStorage.Current = new SqlServerStorage("Server=localhost; Database=Hangfire;User=sa;Password=p@ssw0rd;",new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true
                });
         BackgroundJob.Enqueue<T>(action);
      }
   }
}