namespace HomeAccounting.BLL.Dtos
{
    public class ExpensesStatisticDto
    {
        public string CategoryName { get; set; } = null!;
        public decimal TotalExpenses { get; set; }
    }
}
