using Rawela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rawela.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            this.Items = new List<Products>();
        }

        public IList<Products> Items { get; set; }
    }

    public class Products
    {
        public Products(Product product)
        {
            this.Images = new List<Image>();
            this.Id = product.Id;
            this.description = product.description;
        }
        
        public int Id { get; set; }

        public string Title { get; set; }

        public string photo { get; set; }

        public string description { get; set; }

        public string Categoria { get; set; }

        public IList<Image> Images { get; set; }
    }

    
}