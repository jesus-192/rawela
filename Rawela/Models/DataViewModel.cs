using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rawela.Models
{
    public class DataViewModel
    {
        public int ProductId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int CategoryName { get; set; }

        public DateTime Date { get; set; }

        public int SupplierId { get; set; }

        public string SupplierName { get; set; }
    }
}