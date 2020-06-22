namespace HangfireApp
{
   using System;
   using System.Collections.Generic;
   using Hangfire;
   using Hangfire.SqlServer;
   using HangfireActions;
   using Microsoft.AspNetCore.Builder;
   using Microsoft.AspNetCore.Hosting;
   using Microsoft.Extensions.Configuration;
   using Microsoft.Extensions.DependencyInjection;
   using Microsoft.Extensions.Hosting;

   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         this.Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      public void ConfigureServices(IServiceCollection services)
      {
         // TODO: test if need this di I think not and also should make hangfire string
         // to come from the library not  for every project it should be a problem to change on many places a string
         // pointless for sure
         // services.AddTransient<IUserHandler, UserHandler>();
         services.AddHangfire(configuration => configuration
                     .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                     .UseSimpleAssemblyNameTypeSerializer()
                     .UseRecommendedSerializerSettings()
                     .UseSqlServerStorage(this.Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
                     {
                        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                        QueuePollInterval = TimeSpan.Zero,
                        UseRecommendedIsolationLevel = true,
                        UsePageLocksOnDequeue = true,
                        DisableGlobalLocks = true,
                     }));

         services.AddHangfireServer();
         RegisterController.AddDbConnectionStrings(new Dictionary<string, string>
         {
            { "IdentityConnection", this.Configuration.GetConnectionString("IdentityConnectionString") },
            { "AppDbConnectionString", this.Configuration.GetConnectionString("AppDbConnectionString") },
         });
      }

      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseHttpsRedirection();
         app.UseStaticFiles();
         app.UseHangfireDashboard("/hangfire");
      }
   }
}
