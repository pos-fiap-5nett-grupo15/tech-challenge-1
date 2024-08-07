using ContactsManagement.Application.DTOs.User.CreateUser;
using ContactsManagement.Domain.Entities;

namespace ContactsManagement.Application.Interfaces.Auth
{
    public interface IPasswordHandler
    {
        public string CreatePassword(CreateUserRequest user);
        public bool ValidatePassword(UserEntity user, string password);
    }
}