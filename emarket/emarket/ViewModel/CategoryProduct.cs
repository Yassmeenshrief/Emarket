using emarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emarket.ViewModel
{
    public class CategoryProduct
    {
        public IEnumerable<Category> categories { get; set; }
        public Product product { get; set; }
    }
}