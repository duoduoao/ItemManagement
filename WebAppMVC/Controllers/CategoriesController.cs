using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoryInMemoryRepository.GetCategories();

            return View(categories);
        }
        //url or query string
        // /edit?id=5
        // /edit/5 if [FromRoute]
        //model binding from query, header, body etc.
        [HttpGet]
        //defualt get
        public IActionResult Edit( int? id)
        {
            ViewBag.Action="edit";

            //var cat = new Category { CategoryId = id.HasValue ? id.Value : 0 };

            var cat = CategoryInMemoryRepository.GetCategoryById(id.HasValue ? id.Value : 0);

            return View(cat);

            //if (id.HasValue)
            //    return new ContentResult{Content = id.ToString()};
            //else {
            //    return new ContentResult{Content = "null value"};
            //}
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            //var cat = new Category { CategoryId = id.HasValue ? id.Value : 0 };
            if(ModelState.IsValid)
            {
                CategoryInMemoryRepository.UpdateCategory(category.CategoryId, category);

                return RedirectToAction(nameof(Index));

            }

            //CategoryInMemoryRepository.UpdateCategory(category.CategoryId,category);

            //return RedirectToAction(nameof(Index));
             return View(category);
        }



        public IActionResult Add() {

            ViewBag.Action = "add";
            return View();
        }
        [HttpPost]
        public IActionResult Add([FromForm]Category category)
        {

            if (ModelState.IsValid) {
                CategoryInMemoryRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));

            }
            return View(category);
        }
        public IActionResult Delete(int categoryId)
        {
            
                CategoryInMemoryRepository.DeleteCategory(categoryId );

                return RedirectToAction(nameof(Index));

           

            //CategoryInMemoryRepository.UpdateCategory(category.CategoryId,category);

            //return RedirectToAction(nameof(Index));
            //return View(category);
        }

    }


}
