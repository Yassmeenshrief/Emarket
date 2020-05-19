using emarket.Context;
using emarket.Models;
using emarket.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace emarket.Controllers
{
    public class CartController : Controller
    {
        StoreContext DB = new StoreContext();
        // GET: Cart
        public ActionResult Addtocart(int id)
        {
            var product = DB.Products.SingleOrDefault(c => c.id == id);
            if (product == null)
                return HttpNotFound();

            var cart_list = DB.cart.SingleOrDefault(c => c.product_id == id);
            if (cart_list != null)
            {
                return RedirectToAction("Index", "Products");
            }
            else
            {
                Cart cart = new Cart();
                cart.product_id = id;
                cart.added_at = DateTime.Now;
                DB.cart.Add(cart);
                DB.SaveChanges();
            }
            return RedirectToAction("Index", "Products");
        }
        public ActionResult Remove(int id)
        {
            var product = DB.cart.Single(c => c.product_id == id);
            DB.cart.Remove(product);
            DB.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}
