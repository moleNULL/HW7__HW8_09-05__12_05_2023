using AutoMapper;
using HomeAccounting.BLL.Dtos;
using HomeAccounting.BLL.Services.Interfaces;
using HomeAccounting.DAL.Repositories.Interfaces;

namespace HomeAccounting.BLL.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly IExpensesRepository _expensesRepository;
        private readonly IMapper _mapper;

        public ExpensesService(IExpensesRepository expensesRepository, IMapper mapper)
        {
            _expensesRepository = expensesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExpensesViewModelDto>> GetExpensesAsync()
        {
            var expensesEntity = await _expensesRepository.GetExpensesAsync();
            var expensesDto = _mapper.Map<IEnumerable<ExpensesViewModelDto>>(expensesEntity);

            return expensesDto;
        }
    }
}
