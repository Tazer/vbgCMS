using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using vbgCMS.Infrastructure.CMS.Interfaces;
using vbgCMS.Infrastructure.CMS;
using vbgCMS.UI.Web.Code.Mvc.Helpers;
using vbgCMS.UI.Web.Code.Mvc.Controllers;
using vbgCMS.UI.Web.Code.Mvc.ActionFilters;

namespace vbgCMS.UI.Web.Areas.Admin.Controllers
{
    public class PageController : AdminController
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
            this.ZoneTemplates = new Dictionary<string, string>() { { "1 Column", "100" }, { "2 Column(50/50)", "48;48" }, { "2 Column(30/70)", "28;68" }, { "1 Column(100) + 2 Column(30/70)", "100;28;68" } };

            return View(new Page());
        } 

        //
        // POST: /Page/Create

        [HttpPost, TransactionPerRequest]
        public ActionResult Create([Bind(Exclude = "Id,Slug,Version")]Page page, string zoneTemplate)
        {
            if (!ModelState.IsValid)
                return View();

            page.Slug = page.Title.ToSlugString();
            page.AddZonesFromTemplateString(zoneTemplate);

            try
            {
                _pageRepository.Save(page);

                return RedirectToAction("Edit", new { id = page.Id });
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
            this.ZoneTemplates = new Dictionary<string, string>() { { "1 Column", "100" }, { "2 Column(50/50)", "48;48" }, { "2 Column(30/70)", "28;68" }, { "1 Column(100) + 2 Column(30/70)", "100;28;68" } };

            return View(_pageRepository.Get(id));
        }

        //
        // POST: /Page/Edit/5

        [HttpPost, TransactionPerRequest]
        public ActionResult Edit(int id, [Bind(Exclude = "Id,Version")]Page page)
        {
            if (!ModelState.IsValid)
                return View();

            var _page = _pageRepository.Load(id);

            _page.Title = page.Title;
            _page.Slug = page.Title.ToSlugString();

            //try
            //{
            //    _pageRepository.Save(_page);
 
                return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
