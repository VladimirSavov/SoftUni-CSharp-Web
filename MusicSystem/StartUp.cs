namespace MusicPlay
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MusicSystem.Data;
    using MusicSystem.Entities;

    public class Startup
    {

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            app.UseMvc();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
        }
        public Startup(IConfiguration configuration)
        => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddSessionStateTempDataProvider();
            services.AddSession();
            services
                .AddDbContext<MusicSystemDbContext>(options => options
                  .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
