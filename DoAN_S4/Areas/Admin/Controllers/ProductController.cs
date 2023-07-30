using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DoAN_S4.Areas.Admin.Models.BussinesModel;
using DoAN_S4.Models.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoAN_S4.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductController : Controller
    {
        IRepositoryCategory repositoryCategory;
        IRepositoryProduct repositoryProduct;

        
        public ProductController(IRepositoryProduct repositoryProduct , IRepositoryCategory repositoryCategory)
        {
            this.repositoryCategory = repositoryCategory;
            this.repositoryProduct = repositoryProduct;
        }

        // GET: Product
        public IActionResult Index( string name , int page = 1)
        {
            page = page < 1 ? 1 : page;
            if (string.IsNullOrEmpty(name))
            {
                long totalpage;
                var data = repositoryProduct.Paging(page, 5, out totalpage);
                ViewBag.totalpage = totalpage;
                ViewBag.page = page;
                return View(data);
            }
            else
            {
                long totalpage;
                var data = repositoryProduct.SearchPaging(name, page, 5, out totalpage);
                ViewBag.totalpage = totalpage;
                ViewBag.page = page;
                ViewBag.name = name;
                return View(data);
            }
            //var data = repositoryProduct.getAll();
            //return View(data);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewBag.categoryId = new SelectList(repositoryCategory.getAll(), "_id", "CategoryName");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product  ,IFormCollection collection, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                // upload file vào thư mục wwwroot/Product
                var files = HttpContext.Request.Form.Files;
                //using System.Linq;
                if (files.Count() > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var FileName = file.FileName;
                    // Nhớ tạo thư mục avatar trong thư mụcwwwroot/images
                    //using System.IO;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        product.Images = FileName; // gán tên ảnh cho thuộc tính Avatar
                    }

                }
            }
            try
            {
                // TODO: Add insert logic here
                repositoryProduct.Insert(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public IActionResult Edit(string id)
        {
            var p = repositoryProduct.GetByID(id);
            ViewBag.categoryId = new SelectList(repositoryCategory.getAll(), "_id", "CategoryName", p.Id_Cate);
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product, IFormFile fileUpload , IFormCollection collection, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                // upload file vào thư mục wwwroot/Product
                var files = HttpContext.Request.Form.Files;
                //using System.Linq;
                if (files.Count() > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var FileName = file.FileName;
                    // Nhớ tạo thư mục avatar trong thư mụcwwwroot/images
                    //using System.IO;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        product.Images = FileName; // gán tên ảnh cho thuộc tính Avatar
                    }

                }
            }
            try
            {
                // TODO: Add insert logic here
                repositoryProduct.Update(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
          
        }

        public IActionResult productFull()
        {
            var data = repositoryProduct.getProductFull();
            return View(data);
        }

        // GET: Product/Delete/5
        public IActionResult Delete(string id)
        {
            repositoryProduct.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}