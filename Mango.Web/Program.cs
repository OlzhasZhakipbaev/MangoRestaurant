using Mango.Web.Services;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Security.Cryptography.X509Certificates;

namespace Mango.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            var config = builder.Configuration;
            // Add services to the container.
            builder.Services.AddHttpClient<IProductService, ProductService>();
            SD.ProductAPIBase = config["ServicesUrls:ProductAPI"];
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

          //  app.UseAuthorization();
           
            app.MapControllers();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}