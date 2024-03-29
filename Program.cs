using IServiceContract;
using Services;
using System;

namespace b
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddTransient(typeof(ICityServices), typeof(CityServices)); 
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.MapControllers(); //useRouting + use Endpoints
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();
        }
    }
}   