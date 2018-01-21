using Rawela.Models;
using Rawela.Services;
using Rawela.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rawela.Controllers
{
    public class HomeController : Controller
    {
        private RawelaRepository _repo;

        public HomeController()
        {
            _repo = new RawelaRepository();
        }
        public ActionResult Index()
        {
            var model = _repo.GetSomeProducts().ToList();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _repo.GetProduct(id);

            return PartialView("_DetailsView", model);
        }

        public ActionResult DetailsView(int id)
        {
            var model = _repo.GetProduct(id);

            return PartialView("_DetailsView", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Products()
        {
            var model = _repo.GetAll().ToList();
            return View(model);
        }

        
    }
}