using MyShop.Data;
using MyShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Models;
namespace MyShop.Services
{
    public class ProductService
    {
        private ShopDataContext _context;

        public ProductService() 
        {
         _context= new ShopDataContext();
        }
        public void Add(Product product, bool isSaveChanges = true)
        {
            _context.Products.Add(product);
            if(isSaveChanges)
            {
                _context.SaveChanges();
            }
            
        }

        public void Update(Product product, bool isSaveChanges= true)
        {
            var productEntity = _context.Products
                .FirstOrDefault(p => p.Id == product.Id);
            productEntity.Price = product.Price;
            productEntity.Description = product.Description;
            productEntity.CategoryId= product.CategoryId;
            productEntity.VendorId= product.VendorId;
            productEntity.Name= product.Name;
            productEntity.Discount= product.Discount;

            if(isSaveChanges)
            {
                _context.SaveChanges();
            }


                
        }

        public void Delete(int Id)
        {
            var productEntity = _context.Products
                .FirstOrDefault(p =>p.Id == Id);
            productEntity.IsDeleted = true;
            _context.SaveChanges();
        }

        public List<Product> GetByFilter(ProductFilterModel filter)
        {
            var products = _context.Products.
                Where(p=> !p.IsDeleted && (filter.CategoryId== null || p.CategoryId== filter.CategoryId)
                &&(filter.VendorId == null || p.VendorId == filter.VendorId)
                &&(!filter.FromPrice.HasValue || p.Price >=filter.FromPrice)
                &&(!filter.ToPrice.HasValue || p.Price<= filter.ToPrice)
                &&(!filter.HasDiscount || p.Discount.HasValue)
                &&(filter.Name == null || p.Name.ToLower().Contains(filter.Name.ToLower())))
                .ToList();
            return products;
            //if(filter.VendorId.HasValue)
            //{
            //    products = products.Where( p=>p.VendorId== filter.VendorId);
            //}
            //if(filter.CategoryId.HasValue)
            //{
            //    products = products.Where(p => p.CategoryId == filter.CategoryId);
            //}

        }

        public Product GetById(int Id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == Id);
        }
        public int CommitAllChanges()
        {
            return _context.SaveChanges();
        }
    }
}
