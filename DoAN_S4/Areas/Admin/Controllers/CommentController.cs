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

    [Area("Admin")]
    public class CommentController : Controller
    {
        IRepositoryComment repositoryComment;

        public CommentController(IRepositoryComment repositoryComment)
        {
            this.repositoryComment = repositoryComment;
        }
        


        // GET: Comment
        public ActionResult Index(string name, int page = 1)
        {
            page = page < 1 ? 1 : page;
            if (string.IsNullOrEmpty(name))
            {
                long totalpage;
                var data = repositoryComment.Paging(page, 5, out totalpage);
                ViewBag.totalpage = totalpage;
                ViewBag.page = page;
                return View(data);
            }
            else
            {
                long totalpage;
                var data = repositoryComment.SearchPaging(name, page, 5, out totalpage);
                ViewBag.totalpage = totalpage;
                ViewBag.page = page;
                ViewBag.name = name;
                return View(data);
            }
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment)
        {
            try
            {
                // TODO: Add insert logic here
                repositoryComment.Insert(comment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(string id)
        {
            var c = repositoryComment.GetByID(id);
            return View(c);
        }

        // POST: Comment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Comment comment)
        {
            repositoryComment.Update(comment);
            return RedirectToAction(nameof(Index));
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(string id)
        {
            repositoryComment.Delete(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}