using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rawela.Models
{
    public class Product
    {
        public Product()
        {
            ItemImages = new List<Image>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name ="Titulo")]
        public string Title { get; set; }

        //[Required]
        [Display(Name = "Imagenes")]
        public IEnumerable<HttpPostedFileBase> files { get; set; }

        //[Required]
        [Display(Name = "Imagen Presentación")]
        public string file { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string description { get; set; }

        [Required]
        [StringLength(200)]
        public string Categoria { get; set; }
        
        public virtual ICollection<Image> Images { get; set; }

        public IList<Image> ItemImages { get; set; }
    }
}