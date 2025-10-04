using DataAccessLayer.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface IUserService
    {
        Task<List<UserVM>> GetAllAsync();
        Task<UserVM> GetByIdAsync(int id);
        Task<UserVM> AddAsync(UserAddVM userAddVM);
        Task<UserVM> UpdateAsync(int id, UserAddVM userAddVM);
        Task<bool> DeleteAsync(int id);
        Task<LoginResponseVM> LoginAsync(LoginVM loginInfo);
    }
}
