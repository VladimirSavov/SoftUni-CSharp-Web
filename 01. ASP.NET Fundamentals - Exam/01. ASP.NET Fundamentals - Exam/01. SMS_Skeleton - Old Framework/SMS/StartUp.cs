namespace SMS
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;
    using SUS.HTTP;
    using SUS.MvcFramework;

    using Data;
    using SMS.Services;

    public class Startup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            //new SMSDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUserServices, UserServices>();
        }
    }
}