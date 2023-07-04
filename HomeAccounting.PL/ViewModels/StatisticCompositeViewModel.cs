namespace HomeAccounting.PL.ViewModels
{
    public class StatisticCompositeViewModel
    {
        public IEnumerable<StatisticViewModel> Statistic { get; init; } = null!;
        public StatisticDateViewModel StatisticDate { get; init; } = null!;
    }
}
