using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using vbgCMS.Infrastructure.CMS.Interfaces;

namespace vbgCMS.UI.Web.Areas.Admin.Controllers
{
    public class PageController : Controller
    {
        private readonly IPageRepository _pageRepository;

        public PageController(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        //
        // GET: /Page/

        public ActionResult Index()
        {
            return View(_pageRepository.Get());
        }

        //
        // GET: /Page/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Page/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Page/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Page/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Page/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
