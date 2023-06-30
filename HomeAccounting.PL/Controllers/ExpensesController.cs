﻿using AutoMapper;
using HomeAccounting.BLL.Services.Interfaces;
using HomeAccounting.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccounting.PL.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ILogger<ExpensesController> _logger;
        private readonly IExpensesService _expensesService;
        private readonly IMapper _mapper;

        public ExpensesController(
            ILogger<ExpensesController> logger,
            IExpensesService expensesService,
            IMapper mapper)
        {
            _logger = logger;
            _expensesService = expensesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var expensesDto = await _expensesService.GetExpensesAsync();
            var expensesViewModel = _mapper.Map<IEnumerable<ExpensesViewModel>>(expensesDto);

            _logger.LogInformation($"Returned {expensesViewModel.Count()} rows");

            return View(expensesViewModel);
        }
    }
}