using DoAN_S4.Areas.Admin.Models.BussinesModel;
using DoAN_S4.Areas.Admin.Models.BussinesModel.IRepository;
using DoAN_S4.Models.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace DoAN_S4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        IRepositotyColor repositotyColor;
        public ColorController(IRepositotyColor repositotyColor) 
        {
            this.repositotyColor = repositotyColor;
        }
        // GET: ColorController
        public ActionResult Index(string name, int page = 1)
        {
            page = page < 1 ? 1 : page;
            if (string.IsNullOrEmpty(name))
            {
                long totalpage;
                var data = repositotyColor.Paging(page, 5, out totalpage);
                ViewBag.totalpage = totalpage;
                ViewBag.page = page;
                return View(data);
            }
            else
            {
                long totalpage;
                var data = repositotyColor.SearchPaging(name, page, 5, out totalpage);
                ViewBag.totalpage = totalpage;
                ViewBag.page = page;
                ViewBag.name = name;
                return View(data);
            }
        }

        // GET: ColorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ColorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Color color)
        {
            try
            {
                // TODO: Add insert logic here
                repositotyColor.Insert(color);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: ColorController/Edit/5
        public ActionResult Edit(int id)
        {
            var p = repositotyColor.GetByID(id);
            return View(p);
        }

        // POST: ColorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Color color)
        {
            repositotyColor.Update(color);
            return RedirectToAction(nameof(Index));
        }

        // GET: ColorController/Delete/5
        public ActionResult Delete(int id)
        {
            repositotyColor.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
