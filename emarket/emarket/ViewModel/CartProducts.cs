using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using emarket.Models;

namespace emarket.ViewModel
{
    public class CartProducts 
    {
            public IEnumerable<Cart> cart { get; set; }
         
            public IEnumerable<Product> Product { get; set; }
    }
}