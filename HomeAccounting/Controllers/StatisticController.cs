using HomeAccounting.Models;
using HomeAccounting.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccounting.Controllers
{
    public class StatisticController : Controller
    {
        private readonly ILogger<StatisticController> _logger;
        private readonly IStatisticRepository _statisticRepository;

        public StatisticController(ILogger<StatisticController> logger, 
            IStatisticRepository statisticRepository)
        {
            _logger = logger;
            _statisticRepository = statisticRepository;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(int? year, int? month)
        {
            const int YEARS_DIFFERENCE = 1;

            year ??= DateTime.Now.Year;
            month ??= DateTime.Now.Month;

            if (!IsValid(year.Value, month.Value, YEARS_DIFFERENCE))
            {
                var errorViewModel = new ErrorViewModel
                {
                    Message = $"Year must be in range between {DateTime.Now.Year - YEARS_DIFFERENCE} and " +
                        $"{DateTime.Now.Year}\nMonth must be in range between 1 and 12"
                };

                return View("Error", errorViewModel);
            }

            try
            {
                var monthStatistic = 
                    await _statisticRepository.GetExpenseStatisticAsync(year.Value, month.Value);

                _logger.LogInformation($"Returned {monthStatistic.Count()} rows");

                ViewBag.YearsDifference = YEARS_DIFFERENCE;
                ViewBag.SelectedMonth = month.Value;
                ViewBag.SelectedYear = year.Value;

                return View(monthStatistic);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception! {ex.Message}");

                return View("Error", new ErrorViewModel { Message = ex.Message });
            }
        }

        private bool IsValid(int year, int month, int yearsDifference)
        {
            if (year < DateTime.Now.Year - yearsDifference || year > DateTime.Now.Year)
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
