using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using RaspberryAPI.DBContext;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Replace this with your actual connection string
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ItemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        // Add database context
        services.AddDbContext<ScannerDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the request pipeline
        // ...

        // Configure other middleware...

        // Use the following if you want to serve static files (e.g., for development)
        app.UseStaticFiles();
    }
}
