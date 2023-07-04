namespace HomeAccounting.DAL.Models.DataModels
{
    public class ExpensesDataModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public decimal Cost { get; init; }
        public DateTime Date { get; init; }
        public string CategoryName { get; init; } = null!;
        public string? Comment { get; init; }
    }
}
