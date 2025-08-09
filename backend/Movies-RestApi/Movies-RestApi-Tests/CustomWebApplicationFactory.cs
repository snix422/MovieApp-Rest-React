using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movies_RestApi.Data;
using Movies_RestApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies_RestApi_Tests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        private readonly string _databaseName;

        public CustomWebApplicationFactory(string databaseName)
        {
            _databaseName = databaseName;
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Testing");
            builder.UseEnvironment("Testing");
            builder.ConfigureServices(services =>
            {

                var descriptor = services.SingleOrDefault(
              d => d.ServiceType == typeof(DbContextOptions<DataContext>));
                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<DataContext>(options =>
                {
                    options.UseInMemoryDatabase(_databaseName);
                });



            });
        }
    }
}
