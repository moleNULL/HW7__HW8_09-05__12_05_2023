﻿using HomeAccountingPL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccountingPL.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            return View("Error");
        }

        [HttpGet]
        [Route("/Error/Index/{code:int}")]
        public IActionResult Index(int code)
        {
            var errorViewModel = new ErrorViewModel { Message = $"Status code: {code}" };

            if (code == 404)
            {
                errorViewModel.Message += " | This page could not be found";
            }

            return View("Error", errorViewModel);
        }
    }
}