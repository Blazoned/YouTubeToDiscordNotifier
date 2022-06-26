using DiscordYouTubeNotifier.DataStore;
using DiscordYouTubeNotifier.Services;
using DiscordYouTubeNotifier.Services.Options;
using DiscordYouTubeNotifier.YouTubeNotifier;
using DiscordYouTubeNotifier.YouTubeSubscriber;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DiscordYouTubeNotifier.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDataStoreFactory, DataStoreFactory>()
                    .AddScoped<INotificationService, WebhookNotificationService>()
                    .AddSingleton(Configuration.GetRequiredSection("ServiceOptions")
                                               .GetRequiredSection("SubscriptionService")
                                               .Get<SubscriptionServiceOptions>())
                    .AddSingleton<ISubscriptionService, PubsubhubbubService>()
                    .AddHostedService<PubsubhubbubService>();

            services.AddMvc(setupAction => setupAction.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvc(routeBuilder => {
                routeBuilder
                    .MapAreaRoute(
                        name: "api",
                        areaName: "API",
                        template: "api/{controller}/{action}")
                    .MapRoute(
                        name: "areaRoute",
                        template: "{area:exists}/{controller}/{action}")
                    .MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}"
                    );
            });

            app.Run(context =>
            {
                return context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
