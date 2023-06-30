using HomeAccounting.BLL.Services;
using HomeAccounting.BLL.Services.Interfaces;
using HomeAccounting.DAL.Repositories;
using HomeAccounting.DAL.Repositories.Interfaces;

namespace HomeAccounting.PL.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterHomeAccountingServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IStatisticRepository, StatisticRepository>();
            services.AddScoped<IExpensesRepository, ExpensesRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IExpensesService, ExpensesService>();
            services.AddScoped<IStatisticService, StatisticService>();

            return services;
        }
    }
}
