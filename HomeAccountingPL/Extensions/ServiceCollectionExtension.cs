using HomeAccountingBLL.Services;
using HomeAccountingBLL.Services.Interfaces;
using HomeAccountingDAL.Repositories;
using HomeAccountingDAL.Repositories.Interfaces;

namespace HomeAccountingPL.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterHomeAccountingServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IStatisticRepository, StatisticRepository>();
            services.AddScoped<IExpensesRepository, ExpensesRepository>();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IExpensesService, ExpensesService>();
            services.AddTransient<IStatisticService, StatisticService>();

            return services;
        }
    }
}
