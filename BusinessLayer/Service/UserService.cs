using AutoMapper;
using BusinessLayer.IService;
using BusinessLayer.Utils;
using DataAccessLayer.IRepository;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModels.User;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<List<UserVM>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserVM>>(users);
        }
        public async Task<UserVM> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserVM>(user);
        }
        public async Task<UserVM> AddAsync(UserAddVM userAddVM)
        {
            var user = _mapper.Map<User>(userAddVM);
            await _userRepository.AddNewAsync(user);
            return _mapper.Map<UserVM>(user);
        }

        public async Task<UserVM> UpdateAsync(int id, UserAddVM userAddVM)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }
            _mapper.Map(userAddVM, existingUser);
            await _userRepository.UpdateAsync(existingUser);
            return _mapper.Map<UserVM>(existingUser);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return false;
            }
            await _userRepository.DeleteByIdAsync(id);
            return true;
        }
        public async Task<LoginResponseVM> LoginAsync(LoginVM loginInfo)
        {
            var userList = await _userRepository.GetAllAsync();
            var user = userList.FirstOrDefault(u => u.Username == loginInfo.Username);
            //if (user == null || user.PasswordHash != HashPassword(loginInfo.Password))
            if (user == null || user.PasswordHash != loginInfo.Password)
            {
                throw new Exception("Invalid username or password");
            }
            var token = JWTUtils.GenerateJsonWebToken(user, _configuration["Jwt:Key"], _configuration);
            return new LoginResponseVM
            {
                User = _mapper.Map<UserVM>(user),
                Token = token
            };
        }

        private string HashPassword(string password)
        {
            // Simple hash for demonstration purposes. Use a stronger hashing algorithm in production.
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
