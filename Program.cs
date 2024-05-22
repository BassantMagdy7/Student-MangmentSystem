using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MVC_Project_eng_ayman.Models;
using MVC_Project_eng_ayman.Repository;

namespace MVC_Project_eng_ayman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            builder.Services.AddTransient<IDeptRepo, DepartmentRepo>();
            builder.Services.AddTransient<IStudentRepo, StudentRepo>();
            builder.Services.AddDbContext<ITIContext>(a =>
            {
                a.UseSqlServer(builder.Configuration.GetConnectionString("con1"));
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting(); //name of controller ,name of action
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
