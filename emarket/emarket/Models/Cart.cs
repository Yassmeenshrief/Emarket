using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace emarket.Models
{
    public class Cart
    {
        [Key, Column(Order = 1)]
        public DateTime added_at { get; set; }
        [Key, Column(Order = 2)]
        [ForeignKey("Product")]
        public int product_id { get; set; }
        public virtual Product Product { get; set; }
    }
}