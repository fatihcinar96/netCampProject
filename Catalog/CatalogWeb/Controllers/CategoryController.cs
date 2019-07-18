using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Business;
using Catalog.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult List()
        {
            var dataService = new CategoryService();
            return View(dataService.GetList());
        }

        public IActionResult Add()
        {
            return View();
        }

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

        public IActionResult Update()
        {
            return View();
        }

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
                return View(ex.Message);
            }
            return RedirectToAction("List");
        }


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