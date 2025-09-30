using DataAccessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ShopDbContext _dbContext;

        public ProductRepository(ShopDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }

}
