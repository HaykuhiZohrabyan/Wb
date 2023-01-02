using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wb.DAL.Entities;
namespace Wb.DAL.Repository
{
    public class DataContext:DbContext
    {
        public  DataContext(DbContextOptions<DataContext> options):base(options)
        { }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<VendorCountry> VendorCountries { get; set; }
        public DbSet<Vendor> Vendors { get; set; }


    }
}
