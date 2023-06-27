using HomeAccountingDAL;
using HomeAccountingPL.Extensions;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace HomeAccountingPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(ConfigurationHelper.GetConnectionString());
            });

            builder.Services.RegisterHomeAccountingServices();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/Error/Index/{0}");
            app.UseCustomExceptionMiddleware("/Error");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Category}/{action=Index}");

            app.Run();
        }
    }
}