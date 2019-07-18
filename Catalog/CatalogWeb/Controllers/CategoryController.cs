using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Business;
using Catalog.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CatalogWeb.Controllers
{
    public class CategoryController : Controller
    {
        [Authorize]
        public IActionResult List()
        {
            var dataService = new CategoryService();
            return View(dataService.GetList());
        }
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Add(Category model)
        {
            var dataService = new CategoryService();
            try
            {
                dataService.Add(model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(ViewBag.Message);
                
            }
            return RedirectToAction("List");
        }
        [Authorize]
        public IActionResult Update(int id)
        {
            var categoryService = new CategoryService();
            ViewBag.Categories = new SelectList(categoryService.GetList(), "CategoryID", "Name");
            var category = categoryService.GetCategory(id);
            return View(category);
        }


        [Authorize]
        [HttpPost]
        public IActionResult Update(Category model)
        {
            var dataService = new CategoryService();
            try
            {
                dataService.Update(model);
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View(ViewBag.Error);
            }
            return RedirectToAction("List");
        }

        [Authorize]
        public IActionResult Delete (int id)
        {
            var dataService = new CategoryService();
            try
            {
                dataService.Delete(id);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("List", ViewBag.Error);
                throw;
            }
            return RedirectToAction("List");
        }
    }
}