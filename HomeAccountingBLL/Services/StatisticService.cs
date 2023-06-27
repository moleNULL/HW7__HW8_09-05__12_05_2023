using AutoMapper;
using HomeAccountingBLL.Dtos;
using HomeAccountingBLL.Services.Interfaces;
using HomeAccountingDAL.Repositories.Interfaces;

namespace HomeAccountingBLL.Services
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

        public async Task<IEnumerable<ExpensesStatisticViewModelDto>> GetExpenseStatisticAsync(int year, int month)
        {
            var monthStatisticEntity = await _statisticRepository.GetExpenseStatisticAsync(year, month);
            var monthStatisticDto = _mapper.Map<IEnumerable<ExpensesStatisticViewModelDto>>(monthStatisticEntity);

            return monthStatisticDto;
        }
    }
}
