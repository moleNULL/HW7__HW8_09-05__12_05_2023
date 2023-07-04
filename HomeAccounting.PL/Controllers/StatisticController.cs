using AutoMapper;
using HomeAccounting.BLL.Models;
using HomeAccounting.BLL.Services.Interfaces;
using HomeAccounting.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccounting.PL.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IStatisticService _statisticService;
        private readonly IMapper _mapper;

        public StatisticController(IStatisticService statistiService, IMapper mapper)
        {
            _statisticService = statistiService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? year, int? month)
        {
            StatisticCompositeModel monthStatisticCompositeModel;
            try
            {
                monthStatisticCompositeModel = await _statisticService.GetExpenseStatisticAsync(year, month);
            }
            catch (ArgumentException ex)
            {
                return View("Error", new ErrorViewModel { Message = ex.Message });
            }

            var monthStatisticCompositeViewModel =
                _mapper.Map<StatisticCompositeViewModel>(monthStatisticCompositeModel);

            return View(monthStatisticCompositeViewModel);
        }
    }
}
