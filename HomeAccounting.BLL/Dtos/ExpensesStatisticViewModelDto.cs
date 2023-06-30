namespace HomeAccounting.BLL.Dtos
{
    public class ExpensesStatisticViewModelDto
    {
        public IEnumerable<ExpensesStatisticDto> ExpensesStatistic { get; set; } = null!;
        public ExpensesStatisticDateDto ExpensesStatisticDate { get; set; } = null!;
    }
}
