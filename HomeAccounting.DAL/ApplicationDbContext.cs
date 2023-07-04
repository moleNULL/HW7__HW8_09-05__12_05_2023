using HomeAccounting.DAL.Configurations;
using HomeAccounting.DAL.EFCore.Extensions;
using HomeAccounting.DAL.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.DAL
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
