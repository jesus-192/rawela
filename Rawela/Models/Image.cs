using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rawela.Models
{
    public class Image
    {

        public int ImageId { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

    }
}