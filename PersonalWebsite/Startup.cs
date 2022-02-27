using Microsoft.EntityFrameworkCore;
using PersonalWebsite.DatabaseModel;

namespace PersonalWebsite;

public class Startup
{
    public IConfiguration _config { get; }

    public Startup(IConfiguration configuration)
    {
        _config = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddRazorPages();
        services.AddDbContext<DatabaseContext>(opt => opt
            .UseSqlServer(_config.GetConnectionString("PersonalWebsite"), builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                    .MigrationsAssembly("PersonalWebsite");
            }));

        //Inspects API code and generates Swagger documents
        services.AddMvcCore().AddApiExplorer();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DatabaseContext context)
    {
        //Enable auto migrations
        context.Database.Migrate();

        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();
        else
            app.UseExceptionHandler("/Error");

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                "default",
                "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapControllers();
            endpoints.MapRazorPages();
        });
    }
}