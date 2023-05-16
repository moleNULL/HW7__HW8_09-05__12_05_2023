using HomeAccounting.Data;
using HomeAccounting.Repositories;
using HomeAccounting.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(ConfigurationHelper.GetConnectionString());
            });
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IStatisticRepository, StatisticRepository>();
            builder.Services.AddScoped<IExpensesRepository, ExpensesRepository>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/Error/Index/{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Expenses}/{action=Index}");

            app.Run();
        }
    }
}