using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;  
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Cartegories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the name.");
            }
            /*if (obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value.");
            }*/
            if (ModelState.IsValid)
            {
                _db.Cartegories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index","Category");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id == 0 || id == null)
            {
                return NotFound();
            }
            
            Category? categoryFromDb = _db.Cartegories.Find(id);
            //Category? categoryFromDb1 = _db.Cartegories.FirstOrDefault(c => c.Id == id);
            //Category? categoryFromDb2 = _db.Cartegories.Where(u=>u.Id== id).FirstOrDefault();
            
            if (categoryFromDb==null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.Cartegories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Cartegories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Cartegories.Find(id); 
            if (obj == null)
            {
                return NotFound();
            }
            _db.Cartegories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            }
        }
    }

