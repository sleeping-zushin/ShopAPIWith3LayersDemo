using DataAccessLayer.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface IProductService
    {
        Task<List<ProductVM>> GetAllProductsAsync();
        Task<ProductVM> GetProductByIdAsync(int id);
        Task AddNewProductAsync(ProductAddVM product);
        Task UpdateProductAsync(ProductVM product);
        Task<bool> DeleteProductByIdAsync(int id);

    }
}
