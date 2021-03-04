using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2} EUR", ApplyFormatInEditMode = false)]
        public double Price { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ICollection<Purchase> Purchases { get; set; }

        public string ProductFullName
        {
            get
            {
                return
                    ProductId + ", " 
                    + Brand + ", "
                    + Name + ", "
                    + Model;
            }
        }
    }
}