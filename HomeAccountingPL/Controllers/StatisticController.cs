using AutoMapper;
using HomeAccountingBLL.Services.Interfaces;
using HomeAccountingPL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccountingPL.Controllers
{
    public class StatisticController : Controller
    {
        private readonly ILogger<StatisticController> _logger;
        private readonly IStatisticService _statisticService;
        private readonly IMapper _mapper;

        public StatisticController(
            ILogger<StatisticController> logger,
            IStatisticService statistiService,
            IMapper mapper)
        {
            _logger = logger;
            _statisticService = statistiService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? year, int? month)
        {
            const int YEARS_DIFFERENCE = 1;

            year ??= 2023;
            month ??= 5;

            if (!IsValid(year.Value, month.Value, YEARS_DIFFERENCE))
            {
                var errorViewModel = new ErrorViewModel
                {
                    Message = $"Year must be in range between {DateTime.Now.Year - YEARS_DIFFERENCE} and " +
                        $"{DateTime.Now.Year}\nMonth must be in range between 1 and 12"
                };

                return View("Error", errorViewModel);
            }

            var monthStatisticDto =
                await _statisticService.GetExpenseStatisticAsync(year.Value, month.Value);

            var monthStatisticViewModel =
                _mapper.Map<IEnumerable<ExpensesStatisticViewModel>>(monthStatisticDto);

            _logger.LogInformation($"Returned {monthStatisticViewModel.Count()} rows");

            ViewBag.YearsDifference = YEARS_DIFFERENCE;
            ViewBag.SelectedMonth = month.Value;
            ViewBag.SelectedYear = year.Value;

            return View(monthStatisticViewModel);
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
