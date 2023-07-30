using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAN_S4.Areas.Admin.Models.BussinesModel.IRepository;
using DoAN_S4.Models.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAN_S4.Areas.Admin.Controllers
{
    public class DiscoutCodeController : Controller
    {
        IRepositoryDiscoutCode repositoryDiscoutCode;

        public DiscoutCodeController(IRepositoryDiscoutCode repositoryDiscoutCode)
        {
            this.repositoryDiscoutCode = repositoryDiscoutCode;
        }



        // GET: DiscoutCode
        public ActionResult Index(string name, int page = 1)
        {
            page = page < 1 ? 1 : page;
            if (string.IsNullOrEmpty(name))
            {
                long totalpage;
                var data = repositoryDiscoutCode.Paging(page, 5, out totalpage);
                ViewBag.totalpage = totalpage;
                ViewBag.page = page;
                return View(data);
            }
            else
            {
                long totalpage;
                var data = repositoryDiscoutCode.SearchPaging(name, page, 5, out totalpage);
                ViewBag.totalpage = totalpage;
                ViewBag.page = page;
                ViewBag.name = name;
                return View(data);
            }
        }

        // GET: DiscoutCode/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DiscoutCode/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiscoutCode/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Discout_Code discout)
        {
            try
            {
                // TODO: Add insert logic here
                repositoryDiscoutCode.Insert(discout);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiscoutCode/Edit/5
        public ActionResult Edit(string id)
        {
            var c = repositoryDiscoutCode.GetByID(id);
            return View(c);
        }

        // POST: Comment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Discout_Code discout)
        {
            repositoryDiscoutCode.Update(discout);
            return RedirectToAction(nameof(Index));
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(string id)
        {
            repositoryDiscoutCode.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}