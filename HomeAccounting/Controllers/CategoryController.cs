using HomeAccounting.Data.Entities;
using HomeAccounting.Models;
using HomeAccounting.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccounting.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ILogger<CategoryController> logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var categories = await _categoryRepository.GetCategoriesAsync();

                _logger.LogInformation($"Returned {categories.Count()} rows");

                return View(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception! {ex.Message}");

                return View("Error", new ErrorViewModel { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddAsync()
        {
            try
            {
                var categories = await _categoryRepository.GetCategoriesAsync();

                _logger.LogInformation($"Returned {categories.Count()} rows");

                return View(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception! {ex.Message}");

                return View("Error", new ErrorViewModel { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CategoryEntity category)
        {
            try
            {
                int count = await _categoryRepository.AddCategoryAsync(category);

                _logger.LogInformation($"Rows added: {count}");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception! {ex.Message}");

                return View("Error", new ErrorViewModel { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync()
        {
            try
            {
                var categories = await _categoryRepository.GetCategoriesAsync();

                _logger.LogInformation($"Returned {categories.Count()} rows");

                return View(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception! {ex.Message}");

                return View("Error", new ErrorViewModel { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(IEnumerable<CategoryEntity> categories)
        {
            try
            {
                int count = await _categoryRepository.UpdateCategoriesAsync(categories);

                _logger.LogInformation($"Rows updated: {count}");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception! {ex.Message}");

                return View("Error", new ErrorViewModel { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync()
        {
            try
            {
                var categories = await _categoryRepository.GetCategoriesAsync();

                _logger.LogInformation($"Returned {categories.Count()} rows");

                return View(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception! {ex.Message}");

                return View("Error", new ErrorViewModel { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(IEnumerable<int> categoryIds)
        {
            try
            {
                int count = await _categoryRepository.DeleteCategoriesAsync(categoryIds);

                _logger.LogInformation($"Rows deleted: {count}");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception! {ex.Message}");

                return View("Error", new ErrorViewModel { Message = ex.Message });
            }
        }
    }
}