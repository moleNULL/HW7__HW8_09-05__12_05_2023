using HomeAccounting.Data.Configurations;
using HomeAccounting.Data.Entities;
using HomeAccounting.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ExpensesEntity> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());

            modelBuilder.Seed();
        }
    }
}
