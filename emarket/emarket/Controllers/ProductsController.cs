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
    public class ProductsController : Controller
    {
        StoreContext DB = new StoreContext();

        // GET: Products
        public ActionResult Index(string search)
        {
            var carts = DB.cart.ToList();
            var products = DB.Products.ToList();
            var categories = DB.Categories.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                Category x = DB.Categories
                    .Where(c => c.name == search).FirstOrDefault<Category>();
                if (x != null)
                {
                    products = DB.Products
                        .Where(s => s.CategoryId == x.id).ToList();
                }
                else
                {
                }
            }
                CartProducts productcart = new CartProducts()
            {
                cart = carts,
                Product = products
            };
            return View(productcart);
        }
            /*var products = db.products.Include(p => p.Cart).Include(p => p.category);
            return View(products.ToList());*/

            //public ActionResult Index()
            //{
            //    var products = DB.Products.Include(p => p.category);
            //    return View(products.ToList());
            //}

            public ActionResult Details(int ID)
        {
            var product = DB.Products.SingleOrDefault(x => x.id == ID);
            return View(product);
        }

     

        [HttpGet]
        public ActionResult Add()
        {
            CategoryProduct pc = new CategoryProduct();
            pc.categories = DB.Categories.ToList();
            return View("Add", pc);
        }

        
        [HttpPost]
        public ActionResult Add(CategoryProduct pd, HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                string path = "";
                if(imgFile.FileName.Length > 0)
                {
                    path = "~/Images/" + Path.GetFileName(imgFile.FileName);
                    imgFile.SaveAs(Server.MapPath(path));
                }
                pd.product.image = path;
               var categoryindb = DB.Categories.Single(c => c.id == pd.product.CategoryId);
                categoryindb.number_of_products++;
                DB.Products.Add(pd.product);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return Content("Done");
        }
      
        

        [HttpGet]
        public ActionResult Edit(int id)
        {

            CategoryProduct pc = new CategoryProduct()
            {
                categories = DB.Categories.ToList(),
                product = DB.Products.SingleOrDefault(c => c.id == id)
            };
                return View("Edit",pc);
        }

        
        [HttpPost]
        public ActionResult Edit(CategoryProduct CAPR, HttpPostedFileBase imgFile)
        {
            var entry = DB.Entry(CAPR.product);
            entry.State = EntityState.Modified;
            imgFile = Request.Files[0];
            var fileName = Path.GetFileName(imgFile.FileName);
            var ext = fileName.Split('.')[1];
            var absolyteDir = "~/Images/";
            
            var newfileName = CAPR.product.id.ToString() + '.' + ext;

            if (imgFile.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath(absolyteDir), newfileName);
                imgFile.SaveAs(path);
                CAPR.product.image = absolyteDir + '/' + newfileName;
                DB.SaveChanges();
            }
            return RedirectToAction("index");
        }

       // public ActionResult Delete(CategoryProduct pcc)
      //  {
          //  var entry = DB.Entry(pcc.product);
           // entry.State = EntityState.Modified;
           // DB.SaveChanges();

            // return RedirectToAction("Index");
    //    } 

    }
}