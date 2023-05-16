using HomeAccounting.Models;
using HomeAccounting.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccounting.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ILogger<ExpensesController> _logger;
        private readonly IExpensesRepository _expensesRepository;

        public ExpensesController(ILogger<ExpensesController> logger, IExpensesRepository expensesRepository)
        {
            _logger = logger;
            _expensesRepository = expensesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var expenses = await _expensesRepository.GetExpensesAsync();

                _logger.LogInformation($"Returned {expenses.Count()} rows");

                return View(expenses);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception! {ex.Message}");

                return View("Error", new ErrorViewModel { Message = ex.Message });
            }
        }
    }
}
