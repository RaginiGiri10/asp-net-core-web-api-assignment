using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZensarProducts_Core_API.DBContext;
using ZensarProducts_Core_API.Models;

namespace ZensarProducts_Core_API.Repository
{
    public class ProductRepository : IProductRepository
    {
        ProductDbContext _productDbContext;
        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public Product AddProduct(Product product)
        {
            _productDbContext.Products.Add(product);
            _productDbContext.SaveChanges();
            return product;

        }

       

            public List<Product> GetAllProducts()
            {
            return _productDbContext.Products.ToList();
            }

       

        public bool UpdateProduct(int id, Product product)
        {
            {
                bool isProductUpdated = false;
                var productTobeUpdated = _productDbContext.Products.FirstOrDefault(p => p.Id == id);



                if (productTobeUpdated != null)
                {
                    productTobeUpdated.Name = product.Name;
                    productTobeUpdated.Description = product.Description;
                    productTobeUpdated.Amount = product.Amount;
                    _productDbContext.SaveChanges();
                    isProductUpdated = true;
                }
                return isProductUpdated;

            }

        }
        public bool DeleteProduct(int id)
        {
            {
                bool isProductRemoved = false;
                var productTobeRemoved = _productDbContext.Products.FirstOrDefault(p => p.Id == id);
                if (productTobeRemoved != null)
                {
                    _productDbContext.Products.Remove(productTobeRemoved);
                    _productDbContext.SaveChanges();
                    isProductRemoved = true;
                }
                return isProductRemoved;

            }
        }

        public List<Product> GetProductsByAmount(double amount)
        {
            var product = _productDbContext.Products.Where(p => p.Amount>amount).ToList();
            return product;
        }
    }
}
