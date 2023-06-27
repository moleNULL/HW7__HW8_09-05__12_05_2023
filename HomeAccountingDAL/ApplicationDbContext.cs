using HomeAccountingDAL.Configurations;
using HomeAccountingDAL.EFCore.Extensions;
using HomeAccountingDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeAccountingDAL
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
