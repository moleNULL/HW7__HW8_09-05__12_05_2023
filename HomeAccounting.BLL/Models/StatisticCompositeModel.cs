namespace HomeAccounting.BLL.Models
{
    public class StatisticCompositeModel
    {
        public IEnumerable<StatisticModel> Statistic { get; init; } = null!;
        public StatisticDateModel StatisticDate { get; init; } = null!;
    }
}
