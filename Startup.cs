using HPStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace HPStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<HPStoreDbContext>(opts =>
            {
                opts.UseSqlServer(
                Configuration["ConnectionStrings:HPStoreConnection"]);
            });
            services.AddScoped<IHPStoreRepository,
           EFHPStoreRepository>();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped<MyCart>(sp => MySessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IHPStoreRepository, EFHPStoreRepository>();
            services.AddScoped<IOrderRepository, EFOrderRepository>();
            services.AddRazorPages();
            services.AddServerSideBlazor();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                }
                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseRouting();
                app.UseSession();
                app.UseAuthorization();
                app.UseEndpoints(endpoints =>
                {

                    endpoints.MapControllerRoute("genpage", "{genre}/{Page:int}",
                    new { Controller = "Home", action = "Index" });
                    endpoints.MapControllerRoute("page", "{Page:int}",
                    new { Controller = "Home", action = "Index", Page = 1 });
                    endpoints.MapControllerRoute("genre", "{genre}",
                    new { Controller = "Home", action = "Index", Page = 1 });
                    endpoints.MapControllerRoute("pagination","Tainghes/{Page}",
                    new { Controller = "Home", action = "Index" });
                    endpoints.MapDefaultControllerRoute();
                    endpoints.MapRazorPages();
                    endpoints.MapBlazorHub();
                    endpoints.MapFallbackToPage("/admin/{*catchall}",
                   "/Admin/Index");
                });
                SeedData.EnsurePopulated(app);

            }
        }
    }
}
