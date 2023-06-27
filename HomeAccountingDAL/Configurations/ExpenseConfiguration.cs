using HomeAccountingDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeAccountingDAL.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<ExpensesEntity>
    {
        public void Configure(EntityTypeBuilder<ExpensesEntity> builder)
        {
            builder.ToTable("Expenses");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.Cost).HasColumnType("money");
            builder.Property(e => e.Comment).HasColumnType("varchar(max)");

            builder.HasOne(e => e.Category)
                .WithMany(c => c.Expenses)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
