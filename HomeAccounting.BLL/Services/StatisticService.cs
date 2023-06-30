using AutoMapper;
using HomeAccounting.BLL.Dtos;
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

        public async Task<ExpensesStatisticViewModelDto> GetExpenseStatisticAsync(int? year, int? month)
        {
            int yearsBeforeCurrentYear = 1;

            year ??= 2023;
            month ??= 5;

            if (!IsValid(year.Value, month.Value, yearsBeforeCurrentYear))
            {
                throw new ArgumentException($"Year must be in range between {DateTime.Now.Year - yearsBeforeCurrentYear}" +
                    $" and {DateTime.Now.Year}\nMonth must be in range between 1 and 12");
            }

            var monthStatisticEntity = await _statisticRepository.GetExpenseStatisticAsync(year.Value, month.Value);
            var monthStatisticDto = _mapper.Map<IEnumerable<ExpensesStatisticDto>>(monthStatisticEntity);

            return new ExpensesStatisticViewModelDto
            {
                ExpensesStatistic = monthStatisticDto,
                ExpensesStatisticDate = new ExpensesStatisticDateDto
                {
                    YearsBeforeCurrentYear = yearsBeforeCurrentYear,
                    SelectedMonth = month.Value,
                    SelectedYear = year.Value
                }
            };
        }

        private bool IsValid(int year, int month, int yearsBeforeCurrentYear)
        {
            if (year < DateTime.Now.Year - yearsBeforeCurrentYear || year > DateTime.Now.Year)
            {
                return false;
            }

            if (month > 12 || month < 1)
            {
                return false;
            }

            return true;
        }
    }
}
