using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Catalog.DataAccess;
namespace CatalogWeb.Controllers
{
    public class BrandController : Controller
    {
        [Authorize]
        public IActionResult List()
        {
            var dataService = new BrandService();
            return View(dataService.GetList());
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Brand model)
        {
            var dataService = new BrandService();
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
        public IActionResult Update()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Update(Brand model)
        {
            var dataService = new BrandService();
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
        public IActionResult Delete(int id)
        {
            var dataService = new BrandService();
            try
            {
                dataService.Delete(id);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("List",ViewBag.Error);
            }
            return RedirectToAction("List");
        }


    }
}