namespace HomeAccounting.DAL.Entities
{
    public class ExpensesStatisticEntity
    {
        public string CategoryName { get; set; } = null!;
        public decimal TotalExpenses { get; set; }
    }
}
