using AutoMapper;
using HomeAccounting.BLL.Services.Interfaces;
using HomeAccounting.BLL.Dtos;
using HomeAccounting.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccounting.PL.Controllers
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
            ExpensesStatisticViewModelDto monthStatisticViewModelDto;
            try
            {
                monthStatisticViewModelDto = await _statisticService.GetExpenseStatisticAsync(year, month);
            }
            catch (ArgumentException ex)
            {
                return View("Error", new ErrorViewModel { Message = ex.Message });
            }

            var monthStatisticViewModel = _mapper.Map<ExpensesStatisticViewModel>(monthStatisticViewModelDto);

            _logger.LogInformation($"Returned {monthStatisticViewModelDto.ExpensesStatistic.Count()} rows");

            return View(monthStatisticViewModel);
        }
    }
}
