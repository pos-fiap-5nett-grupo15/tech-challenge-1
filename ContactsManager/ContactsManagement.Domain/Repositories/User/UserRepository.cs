using ContactsManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Domain.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private static List<UserEntity> users = new List<UserEntity>
        {
            new UserEntity()
            {
                Username = "Admin",
                Password = "AQAAAAIAAYagAAAAEOfBHuLJJ4s110pLUc45x6L01aAm2wyViCiDqBq94o2DX5HG5TK1O9CHT94a+IZHBg==",
                UserType = Enums.EUserType.Administrator
            }
        };

        public async Task CreateAsync(UserEntity model)
        {
            users.Add(model);
        }

        public async Task DeleteByIdAsync(int id)
        {
            users.Remove(await GetByIdAsync(id));
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return users;
        }

        public async Task<UserEntity?> GetByIdAsync(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<UserEntity?> GetByNameAsync(string username)
        {
            return users.FirstOrDefault(u => u.Username == username);
        }

        public async Task UpdateByIdAsync(int id, string? username, string? password, int? userType)
        {

        }
    }
}