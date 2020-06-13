using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using server.CQRS.Queries;
using Microsoft.OpenApi.Models;
using server.CQRS.Commands;
using server.CQRS;

namespace server
{
    public class Startup
    {   
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
             services.AddSwaggerGen(c =>
             {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "course api", Version = "v1" });
             });
            services.AddLogging();
            services.AddControllers();
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddTransient<IBase,Base>();
            services.AddTransient(typeof(IBaseQuery<>),typeof(BaseQuery<>));
            services.AddTransient(typeof(IBaseCommand),typeof(BaseCommand));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                 c.RoutePrefix = string.Empty;
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
