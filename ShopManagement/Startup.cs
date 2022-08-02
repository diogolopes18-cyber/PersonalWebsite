using Microsoft.EntityFrameworkCore;
using ShopManagement.DatabaseModel;

namespace ShopManagement;

public class Startup
{
    private IConfiguration _config { get; }

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
            .UseSqlServer(_config.GetConnectionString("ShopManagement"), builder =>
            {
                builder.MigrationsAssembly("ShopManagement.DatabaseModel");
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                    .MigrationsAssembly("ShopManagement");
            }));

        //Inspects API code and generates Swagger documents
        services.AddMvcCore().AddApiExplorer();
        services.AddSwaggerGen();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DatabaseContext context)
    {
        //Enable auto migrations
        context.Database.Migrate();
        app.UseSwagger();
        app.UseSwaggerUI(ui =>
            {
                ui.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop Management v1");
            }
        );

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