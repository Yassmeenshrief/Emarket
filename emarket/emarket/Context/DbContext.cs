using emarket.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace emarket.Context
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> cart { get; set; }

        public StoreContext()
            : base("store")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}