namespace HomeAccounting.DAL.Models.Entities
{
    public class ExpensesEntity
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public decimal Cost { get; init; }
        public DateTime Date { get; init; }
        public int CategoryId { get; init; }
        public CategoryEntity Category { get; init; } = null!;
        public string? Comment { get; init; }
    }
}
