using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZensarProducts_Core_API.Models;
using ZensarProducts_Core_API.Repository;
using ZensarProducts_Core_API.ViewModels;

namespace ZensarProducts_Core_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddProduct([FromBody] AddProductViewModel addProductViewModel)
        {
            Product product = new Product
            {
                Name = addProductViewModel.Name,
                Description = addProductViewModel.Description,
                Amount = addProductViewModel.Amount
            };

            var addedProduct = _productRepository.AddProduct(product);
            return Ok(addedProduct);

        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetAllProducts();
            if (products == null)
            {
                NotFound("No Products Found!!!");
            }

            return Ok(products);
        }
       
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductViewModel updateProductViewModel)
        {
            Product product = new Product
            {
                Name = updateProductViewModel.Name,
                Description = updateProductViewModel.Description,
                Amount = updateProductViewModel.Amount
            };

            bool isProductUpdated = _productRepository.UpdateProduct(id, product);

            if (!isProductUpdated)
            {
                return NotFound($"Product with id = {id} is not found.");
            }
            return Ok($"Product with id = {id} is updated successfully.");

        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            bool isProductRemoved = _productRepository.DeleteProduct(id);
            if (!isProductRemoved)
            {
                return NotFound($"Product with id = {id} is not found.");
            }
            return Ok($"Product with id = {id} is removed successfully.");
        }
       [HttpGet("{amount}")]
       public IActionResult GetProductByAmount(double amount)
        {
            var product = _productRepository.GetProductsByAmount(amount);
            if (product == null)
            {
                return NotFound($"Product with amount>{amount} not found");
            }
            return Ok(product);
        }







    }
}
