using AutoMapper;
using HomeAccounting.BLL.Models;
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

        public async Task<IEnumerable<ExpensesModel>> GetExpensesAsync()
        {
            var expensesDataModel = await _expensesRepository.GetExpensesAsync();
            var expensesModel = _mapper.Map<IEnumerable<ExpensesModel>>(expensesDataModel);

            return expensesModel;
        }
    }
}
