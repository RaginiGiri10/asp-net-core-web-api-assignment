using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZensarProducts_Core_API.Models;

namespace ZensarProducts_Core_API.Repository
{
    public interface IProductRepository
    {
        Product AddProduct(Product product);
        List<Product> GetAllProducts();
        
        bool UpdateProduct(int id, Product product);
        bool DeleteProduct(int id);
        List<Product> GetProductsByAmount(double amount);



    }
}
