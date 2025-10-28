using APP.Models;
using APP.Services;
using Microsoft.AspNetCore.Mvc;

namespace MVC_HW.Controllers
{
    // This controller is intentionally named Obsolete; it injects the concrete service
    public class CategoriesObsoleteController : Controller
    {
        private readonly CategoryObsoleteService _categoryService;

        public CategoriesObsoleteController(CategoryObsoleteService categoryService)
        {
            _categoryService = categoryService;
        }

        private void SetTempData(string message, string key = "Message")
        {
            TempData[key] = message;
        }

        public IActionResult Index()
        {
            var list = _categoryService.List();
            return View(list);
        }

        public IActionResult Details(int id)
        {
            var item = _categoryService.Item(id);
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = _categoryService.Create(request);
                if (response.IsSuccessful)
                {
                    SetTempData(response.Message);
                    return RedirectToAction(nameof(Details), new { id = response.Id });
                }
                ModelState.AddModelError("", response.Message);
            }
            return View(request);
        }

        public IActionResult Edit(int id)
        {
            var item = _categoryService.Edit(id);
            return View(item);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = _categoryService.Update(request);
                if (response.IsSuccessful)
                {
                    SetTempData(response.Message);
                    return RedirectToAction(nameof(Details), new { id = response.Id });
                }
                ModelState.AddModelError("", response.Message);
            }
            return View(request);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var response = _categoryService.Delete(id);
            SetTempData(response.Message);
            return RedirectToAction(nameof(Index));
        }
    }
}


