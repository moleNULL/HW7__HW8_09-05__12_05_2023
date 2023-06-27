namespace HomeAccountingDAL.Entities
{
    public class ExpensesEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; } = null!;
        public string? Comment { get; set; }
    }
}
