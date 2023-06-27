namespace HomeAccountingDAL.Entities
{
    public class ExpensesStatisticViewModelEntity
    {
        public string CategoryName { get; set; } = null!;
        public decimal TotalExpenses { get; set; }
    }
}
