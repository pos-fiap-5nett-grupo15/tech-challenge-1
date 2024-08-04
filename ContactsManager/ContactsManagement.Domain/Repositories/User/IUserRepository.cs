using ContactsManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Domain.Repositories.User
{
    public interface IUserRepository
    {
        Task CreateAsync(UserEntity model);
        Task DeleteByIdAsync(int id);
        Task UpdateByIdAsync(int id, string? username, string? password, int? userType);
        Task<UserEntity?> GetByIdAsync(int id);
        Task<UserEntity?> GetByNameAsync(string username);
        Task<IEnumerable<UserEntity>> GetAllAsync();
    }
}
