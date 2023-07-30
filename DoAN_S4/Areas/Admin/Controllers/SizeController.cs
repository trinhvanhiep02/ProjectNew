using DoAN_S4.Areas.Admin.Models.BussinesModel;
using DoAN_S4.Areas.Admin.Models.BussinesModel.IRepository;
using DoAN_S4.Models.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAN_S4.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class SizeController : Controller
    {
        IRepositorySize repositorySize;
        public SizeController(IRepositorySize repositorySize)
        {
            this.repositorySize = repositorySize;
        }

        // GET: SizeController
        public ActionResult Index(string name, int page = 1)
        {

            page = page < 1 ? 1 : page;
            if (string.IsNullOrEmpty(name))
            {
                long totalpage;
                var data = repositorySize.Paging(page, 5, out totalpage);
                ViewBag.totalpage = totalpage;
                ViewBag.page = page;
                return View(data);
            }
            else
            {
                long totalpage;
                var data = repositorySize.SearchPaging(name, page, 5, out totalpage);
                ViewBag.totalpage = totalpage;
                ViewBag.page = page;
                ViewBag.name = name;
                return View(data);
            }

        }

        // GET: SizeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SizeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SizeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Size size)
        {
            try
            {
                // TODO: Add insert logic here
                repositorySize.Insert(size);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SizeController/Edit/5
        public ActionResult Edit(int id)
        {
            var p = repositorySize.GetByID(id);
            return View(p);
        }

        // POST: SizeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Size size)
        {
            repositorySize.Update(size);
            return RedirectToAction(nameof(Index));
        }

        // GET: SizeController/Delete/5
        public ActionResult Delete(int id)
        {
            repositorySize.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
