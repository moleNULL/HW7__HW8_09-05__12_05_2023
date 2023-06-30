using HomeAccounting.PL.Models;

namespace HomeAccounting.PL.ViewModels
{
    public class ExpensesStatisticViewModel
    {
        public IEnumerable<ExpensesStatistic> ExpensesStatistic { get; set; } = null!;
        public ExpensesStatisticDate ExpensesStatisticDate { get; set; } = null!;
    }
}
