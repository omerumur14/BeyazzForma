using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeyazzFormaWeb.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }
        [DisplayName("Ürün Fiyat")]
        public double Price { get; set; }
        [DisplayName("Ürün Fotoğraf")]
        public string Image { get; set; }
        [DisplayName("Ürün ShopierId")]
        public string ShopierId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}