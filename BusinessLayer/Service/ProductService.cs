using BusinessLayer.IService;
using DataAccessLayer.IRepository;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddNewProductAsync(ProductAddVM product)
        {
            if (product.Price <= 0)
            {
                throw new Exception("Price must be greater than zero.");
            }
            if (product.Stock < 0)
            {
                throw new Exception("Stock cannot be negative.");
            }

            var newProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
            await _productRepository.AddNewAsync(newProduct);
        }

        public Task<bool> DeleteProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductVM>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return products.Select(p => new ProductVM
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            }).ToList();
        }

        public Task<ProductVM> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(ProductVM product)
        {
            throw new NotImplementedException();
        }
    }
}
