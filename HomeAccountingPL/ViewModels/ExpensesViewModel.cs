namespace HomeAccountingPL.ViewModels
{
    public class ExpensesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Comment { get; set; }
    }
}
