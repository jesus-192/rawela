using Rawela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rawela.Services
{
    public class RawelaRepository
    {
        public List<Product> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                var Products = db.Products.ToList();
                //foreach (var item in Products)
                //{
                //    var list = db.Images.Where(a =>  a.ProductId== item.Id).ToList();
                //    item.Images = list;
                //}
                return Products;
            }
        }

        public List<Image> GetAllImage()
        {
            using (var db = new ApplicationDbContext())
            {
                var Images = db.Images.ToList();
                
                return Images;
            }
        }

        public List<Product> GetSomeProducts()
        {
            using (var db = new ApplicationDbContext())
            {
                var Products = db.Products.Take(6).ToList();
                return Products;
            }
        }

        public Product GetProduct(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var Product = db.Products.Where(e=> e.Id == id).SingleOrDefault();
                Product.ItemImages = db.Images.Where(e => e.ProductId == id).ToList();
                return Product;
            }
        }

        internal void Crear(Product model)
        {
            using (var db = new ApplicationDbContext())
            {


                db.Products.Add(model);
                db.SaveChanges();
                //var id = db.Products.Where(e => e.Id == model.Id).Select(e => e.Id).FirstOrDefault();
                //Image uploadImage = new Image();


                //foreach (var item in model.files)
                //{
                //    byte[] uploadFile = new byte[item.InputStream.Length];
                //    item.InputStream.Read(uploadFile, 0, uploadFile.Length);

                //    uploadImage.Name = item.FileName;
                //    uploadImage.ProductId = id;

                //    db.Images.Add(uploadImage);
                //    db.SaveChanges();
                //}

            }
        }

        internal void AddImages(Product model)
        {
            using (var db = new ApplicationDbContext())
            {
                Image uploadImage = new Image();


                foreach (var item in model.files)
                {
                    byte[] uploadFile = new byte[item.InputStream.Length];
                    item.InputStream.Read(uploadFile, 0, uploadFile.Length);

                    uploadImage.Name = item.FileName;
                    uploadImage.ProductId = model.Id;

                    db.Images.Add(uploadImage);
                    
                }
                db.SaveChanges();

            }
        }

        internal void Delete(Product model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Products.Remove(model);
                db.SaveChanges();
            }
        }
    }
}