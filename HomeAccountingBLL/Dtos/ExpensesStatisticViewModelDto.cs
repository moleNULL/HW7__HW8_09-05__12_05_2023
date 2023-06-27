namespace HomeAccountingBLL.Dtos
{
    public class ExpensesStatisticViewModelDto
    {
        public string CategoryName { get; set; } = null!;
        public decimal TotalExpenses { get; set; }
    }
}
