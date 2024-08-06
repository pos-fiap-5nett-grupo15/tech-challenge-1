using ContactsManagement.Domain.Entities;
using ContactsManagement.Domain.Enums;

namespace ContactsManagement.Domain.Repositories.User
{
    public interface IUserRepository
    {
        Task CreateAsync(UserEntity model);
        Task DeleteByIdAsync(int id);
        Task UpdateByIdAsync(int id, string? username, string? password, EUserType? userType);
        Task<UserEntity?> GetByIdAsync(int id);
        Task<UserEntity?> GetByNameAsync(string username);
        Task<IEnumerable<UserEntity>> GetAllAsync();
    }
}