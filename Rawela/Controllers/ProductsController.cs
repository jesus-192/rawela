using Rawela.Models;
using Rawela.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rawela.Controllers
{
    public class ProductsController : Controller
    {
        private RawelaRepository _repo;
        private ApplicationDbContext db = new ApplicationDbContext();

        public ProductsController()
        {
            _repo = new RawelaRepository();
        }
        // GET: Products
        public ActionResult Index()
        {
            var model = _repo.GetAll();
            return View(model);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        //[HttpPost]
        //public ActionResult Create(Product model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (Request.Files.Count > 0)
        //            {
        //                HttpPostedFileBase file = Request.Files[0];
        //                if (file.ContentLength > 0)
        //                {
        //                    var fileName = Path.GetFileName(file.FileName);
        //                    var path = Path.Combine(
        //                        Server.MapPath("~/Content/Photo"), fileName);
        //                    file.SaveAs(path);
        //                    model.file = fileName;
        //                }
        //                _repo.Crear(model);

        //                return RedirectToAction("Index");
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return View(model);
        //}
        [HttpPost]
        public ActionResult Create(Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Request.Files.Count > 0)
                    {
                        HttpPostedFileBase file = Request.Files[0];
                        if (file.ContentLength > 0)
                        {

                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(
                            Server.MapPath("~/Content/Image"), fileName);
                            file.SaveAs(path);
                            model.file = fileName;
                            //foreach (var image in model.files)
                            //{
                            //    byte[] uploadFile = new byte[image.InputStream.Length];
                            //    image.InputStream.Read(uploadFile, 0, uploadFile.Length);
                            //    var fileName1 = Path.GetFileName(image.FileName);
                            //    var path1 = Path.Combine(
                            //        Server.MapPath("~/Content/Photo"), fileName1);
                            //    file.SaveAs(path1);
                            //    //model.file = image.FileName;
                            //}


                        }
                        _repo.Crear(model);

                        return RedirectToAction("Index");
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }

        public ActionResult AddImages(int id)
        {
            var model = _repo.GetProduct(id);
            model.Id = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddImages(Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Request.Files.Count > 0)
                    {
                        HttpPostedFileBase file = Request.Files[0];
                        if (file.ContentLength > 0)
                        {
                            foreach (var image in model.files)
                            {
                                byte[] uploadFile = new byte[image.InputStream.Length];
                                image.InputStream.Read(uploadFile, 0, uploadFile.Length);
                                var fileName1 = Path.GetFileName(image.FileName);
                                var path1 = Path.Combine(
                                    Server.MapPath("~/Content/Photo"), fileName1);
                                file.SaveAs(path1);
                                //model.file = image.FileName;
                            }


                        }
                        _repo.AddImages(model);

                        return RedirectToAction("Index");
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }
        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
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

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            var viewModel = new Product()
            {
                
            };
            return View(product);
        }

        // POST: Products/Delete/5
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
