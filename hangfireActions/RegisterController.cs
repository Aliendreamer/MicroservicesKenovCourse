namespace HangfireActions
{
   using System;
   using System.Collections.Generic;
   using System.Linq.Expressions;
   using Hangfire;
   using Hangfire.SqlServer;

   public class RegisterController
   {
      private static Dictionary<string, string> DbConnectionStrings { get; set; }

      public static void RegisterJob<T>(Expression<Action<T>> action)
      where T : class
      {
         JobStorage.Current = new SqlServerStorage("Server=localhost; Database=Hangfire;User=sa;Password=p@ssw0rd;", new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true,
                });
         BackgroundJob.Enqueue<T>(action);
      }

      public static void AddDbConnectionStrings(Dictionary<string, string> connections)
      {
         if (connections is null || connections.Count == 0)
         {
            throw new NullReferenceException("Connections dictionary can't be null or empty");
         }

         DbConnectionStrings = connections;
      }

      public static string GetConnectionString(string key)
      {
         return DbConnectionStrings.GetValueOrDefault(key);
      }
   }
}