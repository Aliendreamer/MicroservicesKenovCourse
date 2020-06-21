namespace IdentityService
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Text;
   using HangfireActions;
   using IdentityService.Entities;
   using IdentityService.Helpers;
   using IdentityService.Services;
   using Microsoft.AspNetCore.Authentication.JwtBearer;
   using Microsoft.AspNetCore.Builder;
   using Microsoft.EntityFrameworkCore;
   using Microsoft.Extensions.Configuration;
   using Microsoft.Extensions.DependencyInjection;
   using Microsoft.IdentityModel.Tokens;
   using Microsoft.OpenApi.Models;

   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         this.Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddCors();
         services.AddControllers()
                 .AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);
         services.AddSwaggerGen(c =>
          {
             c.SwaggerDoc("v1", new OpenApiInfo { Title = "identity api", Version = "v1" });
          });

         // configure strongly typed settings objects
         services.AddDbContext<DataContext>(options =>
                      options.UseSqlServer(this.Configuration["DefaultConnection:connectionString"]));

         var appSettingsSection = this.Configuration.GetSection("AppSettings");
         services.Configure<AppSettings>(appSettingsSection);
         var appSettings = appSettingsSection.Get<AppSettings>();

         // configure jwt authentication
         var key = Encoding.ASCII.GetBytes(appSettings.Secret);
         services.AddAuthentication(x =>
         {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
         })
         .AddJwtBearer(x =>
         {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
               ValidateIssuerSigningKey = true,
               IssuerSigningKey = new SymmetricSecurityKey(key),
               ValidateIssuer = false,
               ValidateAudience = false,
               ClockSkew = TimeSpan.Zero,
            };
         });
         services.AddScoped<IUserService, UserService>();

         RegisterController.AddDbConnectionStrings(new Dictionary<string, string>
         {
            { "IdentityConnection", this.Configuration.GetConnectionString("IdentityConnectionString") },
            { "AppDbConnectionString", this.Configuration.GetConnectionString("AppDbConnectionString") },
         });
      }

      public void Configure(IApplicationBuilder app, DataContext context)
      {
         // add hardcoded test user to db on startup
         // plain text password is used for simplicity, hashed passwords should be used in production applications
         if (!context.Users.Any())
         {
            context.Users.Add(new User { FirstName = "Test", LastName = "User", Username = "test", Password = "test", UserRole = 1 });
            context.SaveChanges();
         }

         app.UseRouting();
         app.UseStaticFiles();

         // global cors policy
         app.UseCors(x => x
             .SetIsOriginAllowed(origin => true)
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials());

         app.UseAuthentication();
         app.UseAuthorization();
         app.UseSwagger();
         app.UseSwaggerUI(c =>
         {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = string.Empty;
         });
         app.UseEndpoints(x => x.MapControllers());
      }
   }
}
