using System.Reflection;
using Hangfire;
using Hangfire.PostgreSql;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationService.Application.UseCases.Notifications.Queries.GetAll;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService
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
            services.AddDbContext<NotificationContext>(options => options.UseNpgsql(Configuration.GetConnectionString("defaultConnection")));
            services.AddControllers();
            services.AddHangfire(config =>
                        config.UsePostgreSqlStorage("Host=127.0.0.1;Database=bgdb;Username=postgres;Password=docker"));
            services.AddMediatR(typeof(GetAllQueryHandler).GetTypeInfo().Assembly);
           
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHangfireServer();

            app.UseHangfireDashboard();
            RecurringJob.AddOrUpdate(() => ReceiverRabbit.Receiver(), Cron.Minutely);

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
