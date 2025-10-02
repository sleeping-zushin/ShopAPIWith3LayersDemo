using AutoMapper;
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
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
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
            var newProduct = _mapper.Map<Product>(product);

            //var newProduct = new Product
            //{
            //    Name = product.Name,
            //    Price = product.Price,
            //    Stock = product.Stock
            //};
            await _productRepository.AddNewAsync(newProduct);
        }


        public async Task<List<ProductVM>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();

            var productListVM = _mapper.Map<List<ProductVM>>(products);

            return productListVM;

            //return products.Select(p => new ProductVM
            //{
            //    ProductId = p.ProductId,
            //    Name = p.Name,
            //    Price = p.Price,
            //    Stock = p.Stock
            //}).ToList();
        }

        public async Task<ProductVM> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }
            var productVM = _mapper.Map<ProductVM>(product);
            
            return productVM;

            //return new ProductVM
            //{
            //    ProductId = product.ProductId,
            //    Name = product.Name,
            //    Price = product.Price,
            //    Stock = product.Stock
            //};
        }

        public async Task<bool> DeleteProductByIdAsync(int id)
        {
            var itemToDelete = await _productRepository.GetByIdAsync(id);

            if (itemToDelete == null)
            {
                throw new Exception("Product not found.");
            }

            return await _productRepository.DeleteByIdAsync(id);
        }
        public async Task UpdateProductAsync(ProductVM product)
        {
            var existingItem = await _productRepository.GetByIdAsync(product.ProductId);
            if (existingItem == null)
            {
                throw new Exception("Product not found.");
            }

            if (existingItem.Name != null)
            {
                existingItem.Name = product.Name;
            }
            existingItem.Price = product.Price;
            existingItem.Stock = product.Stock;
            await _productRepository.UpdateAsync(existingItem);
        }
    }
}
