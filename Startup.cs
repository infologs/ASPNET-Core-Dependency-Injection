using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyFirstCoreWebApplication.Interface;
using MyFirstCoreWebApplication.Logger;
using System.Text;

namespace MyFirstCoreWebApplication
{

    public class AppConfiguration
    {
        public string ConnectionString { get; set; }
        public int Interval { get; set; }
        public string ApplicationName  { get; set; }
    }

    public class Startup
    {
        public static string ConnectionString { get; private set; }

        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            //Configuration = configuration;         
            Configuration = new ConfigurationBuilder().SetBasePath(hostEnvironment.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.Configure<AppConfiguration>(Configuration.GetSection("AppConfiguration"));
            
            services.Add(new ServiceDescriptor(typeof(ILog), typeof(MyLogger), ServiceLifetime.Scoped));
            //services.AddSingleton<ILog, MyLogger>();
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
                app.UseExceptionHandler("/Error");
            }

            //Middleware configuration

            //app.Use(async (context, next) => {

            //    byte[] data = Encoding.ASCII.GetBytes("This is from first middleware.");
            //    await context.Response.Body.WriteAsync(data);
            //    await next();
            //});

            //app.Run(async (context) => await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes("This message is from second middleware.")));

            app.UseWelcomePage();

            //ConnectionString = Configuration["AppConfiguration:ConnectionString"].ToString();

            /*app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });*/
        }
    }
}
