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

    public class ProductController : Controller
    {
        [Authorize]
        public IActionResult List()
        {
            var dataService = new ProductService();
            var products = dataService.GetList();
            return View(dataService.GetList());
        }
        [Authorize]
        public IActionResult Add()
        {
            var categoryService = new CategoryService();
            var brandService = new BrandService();
            ViewBag.Brands = new SelectList(brandService.GetList(),"BrandID","Name");
            ViewBag.Categories = new SelectList(categoryService.GetList(), "CategoryID", "Name");
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Add(Product model)
        {
            var dataService = new ProductService();
            try
            {
                dataService.Add(model);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ViewBag.Error(ex.Message);
                return View(ex.Message);
             
            }
        }

        [Authorize]
        public IActionResult Update(int id)
        {
            var brandService = new BrandService();
            var categoryService = new CategoryService();
            var productService = new ProductService();
            var product = productService.GetProduct(id);
            ViewBag.Brands = new SelectList(brandService.GetList(), "BrandID", "Name");
            ViewBag.Categories = new SelectList(categoryService.GetList(), "CategoryID", "Name");
            return View(product);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(Product model)
        {
            var dataService = new ProductService();
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
            var dataService = new ProductService();
            try
            {
                dataService.Delete(id);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("List", ViewBag.Error);
            }
            
        }
    }
}