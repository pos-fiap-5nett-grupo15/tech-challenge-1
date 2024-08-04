using ContactsManagement.Application.DTOs.Auth;
using ContactsManagement.Application.DTOs.User.GetUser;
using ContactsManagement.Application.Interfaces.Auth;
using ContactsManagement.Application.Interfaces.User.ValidateUser;
using ContactsManagement.Domain.Entities;
using ContactsManagement.Domain.Repositories.User;

namespace ContactsManagement.Application.Handlers.User.ValidateUser
{
    public class ValidateUserHandler : IValidateUserHandler
    {
        private IUserRepository _userRepository;
        private IPasswordHandler _passwordHandler;

        public ValidateUserHandler(IUserRepository userRepository, IPasswordHandler passwordHandler)
        {
            _userRepository = userRepository;
            _passwordHandler = passwordHandler;
        }

        public async Task<GetUserResponse?> HandleAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByNameAsync(request.Username);

            if (user != null && _passwordHandler.ValidatePassword(user, request.Password))
            {
                return Mapper(user);
            }

            return null;
        }

        private static GetUserResponse Mapper(UserEntity model) =>
            new()
            {
                Id = model.Id,
                Username = model.Username,
                UserType = model.UserType.ToString(),
            };
    }
}