namespace HomeAccountingBLL.Dtos
{
    public class ExpensesDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public string? Comment { get; set; }
    }
}
