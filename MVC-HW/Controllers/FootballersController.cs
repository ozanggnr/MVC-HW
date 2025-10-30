using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CORE.APP.Services;
using APP.Models;

// Generated from Custom MVC Template.

namespace MVC_HW.Controllers
{
    public class FootballersController : Controller
    {
        // Service injections:
        private readonly IService<FootballerRequest, FootballerResponse> _footballerService;
        private readonly IService<CategoryRequest, CategoryResponse> _categoryService;

        /* Can be uncommented and used for many to many relationships, "entity" may be replaced with the related entity name in the controller and views. */
        //private readonly IService<EntityRequest, EntityResponse> _EntityService;

        public FootballersController(
			IService<FootballerRequest, FootballerResponse> footballerService
            , IService<CategoryRequest, CategoryResponse> categoryService

            /* Can be uncommented and used for many to many relationships, "entity" may be replaced with the related entity name in the controller and views. */
            //, IService<EntityRequest, EntityResponse> EntityService
        )
        {
            _footballerService = footballerService;
            _categoryService = categoryService;

            /* Can be uncommented and used for many to many relationships, "entity" may be replaced with the related entity name in the controller and views. */
            //_EntityService = EntityService;
        }

        private void SetViewData()
        {
            /* 
            ViewBag and ViewData are the same collection (dictionary).
            They carry extra data other than the model from a controller action to its view, or between views.
            */

            // Related items service logic to set ViewData (Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["CategoryId"] = new SelectList(_categoryService.List(), "Id", "Name");
            
            /* Can be uncommented and used for many to many relationships, "entity" may be replaced with the related entity name in the controller and views. */
            //ViewBag.EntityIds = new MultiSelectList(_EntityService.List(), "Id", "Name");
        }

        private void SetTempData(string message, string key = "Message")
        {
            /*
            TempData is used to carry extra data to the redirected controller action's view.
            */

            TempData[key] = message;
        }

        // GET: Footballers
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _footballerService.List();
            return View(list); // return response collection as model to the Index view
        }

        // GET: Footballers/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _footballerService.Item(id);
            return View(item); // return response item as model to the Details view
        }

        // GET: Footballers/Create
        public IActionResult Create()
        {
            SetViewData(); // set ViewData dictionary to carry extra data other than the model to the view
            return View(); // return Create view with no model
        }

        // POST: Footballers/Create
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(FootballerRequest footballer)
        {
            if (ModelState.IsValid) // check data annotation validation errors in the request
            {
                // Insert item service logic:
                var response = _footballerService.Create(footballer);
                if (response.IsSuccessful)
                {
                    SetTempData(response.Message); // set TempData dictionary to carry the message to the redirected action's view
                    return RedirectToAction(nameof(Details), new { id = response.Id }); // redirect to Details action with id parameter as response.Id route value
                }
                ModelState.AddModelError("", response.Message); // to display service error message in the validation summary of the view
            }
            SetViewData(); // set ViewData dictionary to carry extra data other than the model to the view
            return View(footballer); // return request as model to the Create view
        }

        // GET: Footballers/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _footballerService.Edit(id);
            SetViewData(); // set ViewData dictionary to carry extra data other than the model to the view
            return View(item); // return request as model to the Edit view
        }

        // POST: Footballers/Edit
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(FootballerRequest footballer)
        {
            if (ModelState.IsValid) // check data annotation validation errors in the request
            {
                // Update item service logic:
                var response = _footballerService.Update(footballer);
                if (response.IsSuccessful)
                {
                    SetTempData(response.Message); // set TempData dictionary to carry the message to the redirected action's view
                    return RedirectToAction(nameof(Details), new { id = response.Id }); // redirect to Details action with id parameter as response.Id route value
                }
                ModelState.AddModelError("", response.Message); // to display service error message in the validation summary of the view
            }
            SetViewData(); // set ViewData dictionary to carry extra data other than the model to the view
            return View(footballer); // return request as model to the Edit view
        }

        // GET: Footballers/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _footballerService.Item(id);
            return View(item); // return response item as model to the Delete view
        }

        // POST: Footballers/Delete
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var response = _footballerService.Delete(id);
            SetTempData(response.Message); // set TempData dictionary to carry the message to the redirected action's view
            return RedirectToAction(nameof(Index)); // redirect to the Index action
        }
    }
}
