using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace emarket.Models
{
    public class Product
    {
        public int id { get; set; }

        [Display(Name = " Name")]
        public string name { get; set; }

        [Display(Name = "Image")]
        public string image { get; set; }

        [Display(Name = "Price")]
        public float price { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }
        public Category category { get; set; }
        [Column("category_id")]
        //[Required(ErrorMessage = "Please Enter Product Ctegory")]
        public int CategoryId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}