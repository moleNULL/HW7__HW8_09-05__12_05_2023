using AutoMapper;
using HomeAccounting.BLL.Enums;
using HomeAccounting.BLL.Models;
using HomeAccounting.BLL.Services.Interfaces;
using HomeAccounting.DAL.Repositories.Interfaces;

namespace HomeAccounting.BLL.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IStatisticRepository _statisticRepository;
        private readonly IMapper _mapper;

        public StatisticService(IStatisticRepository statisticRepository, IMapper mapper)
        {
            _statisticRepository = statisticRepository;
            _mapper = mapper;
        }

        public async Task<StatisticCompositeModel> GetExpenseStatisticAsync(int? year, int? month)
        {
            // years before the current year to begin maintaining statistic from: currentYear - 1 = 2022 (2023 - 1)
            int yearsBeforeCurrentYear = 1;

            year ??= 2023;
            month ??= 5;

            if (!CheckValid(year.Value, month.Value, yearsBeforeCurrentYear))
            {
                throw new ArgumentException($"Year must be in range between {DateTime.Now.Year - yearsBeforeCurrentYear}" +
                    $" and {DateTime.Now.Year} && Month must be in range between 1 and 12");
            }

            var monthStatisticDataModel = await _statisticRepository.GetExpenseStatisticAsync(year.Value, month.Value);
            var monthStatisticModel = _mapper.Map<IEnumerable<StatisticModel>>(monthStatisticDataModel);

            return new StatisticCompositeModel
            {
                Statistic = monthStatisticModel,
                StatisticDate = new StatisticDateModel
                {
                    YearsBeforeCurrentYear = yearsBeforeCurrentYear,
                    SelectedMonth = month.Value,
                    SelectedYear = year.Value
                }
            };
        }

        private bool CheckValid(int year, int month, int yearsBeforeCurrentYear)
        {
            // provided year should not be less than (currentYear - yearsBeforeCurrentYear, i.e. 2023 - 1 = 2022)
            if (year < DateTime.Now.Year - yearsBeforeCurrentYear || year > DateTime.Now.Year)
            {
                return false;
            }

            // provided months should be between 1 (January) and 12 (December)
            if (month > (int)Month.December || month < (int)Month.January)
            {
                return false;
            }

            return true;
        }
    }
}
