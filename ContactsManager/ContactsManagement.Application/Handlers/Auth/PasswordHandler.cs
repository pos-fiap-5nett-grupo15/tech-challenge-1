using ContactsManagement.Application.DTOs.User.CreateUser;
using ContactsManagement.Application.Interfaces.Auth;
using ContactsManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ContactsManagement.Application.Handlers.Auth
{
    public class PasswordHandler : IPasswordHandler
    {
        private readonly PasswordHasher<UserEntity> _passwordHandler;

        public PasswordHandler()
        {
            _passwordHandler = new PasswordHasher<UserEntity>();
        }

        public string CreatePassword(CreateUserRequest userData)
        {
            var user = new UserEntity()
            {
                Username = userData.UserName,
                UserType = userData.UserType,
            };

            return _passwordHandler.HashPassword(user, userData.Password);
        }
        public bool ValidatePassword(UserEntity user, string password)
        {
            var validationResult = _passwordHandler.VerifyHashedPassword(user, user.Password, password);
            return validationResult.Equals(PasswordVerificationResult.Success);
        }
    }
}
