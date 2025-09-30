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
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ShopDbContext _dbContext;
        public OrderDetailRepository(ShopDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
 