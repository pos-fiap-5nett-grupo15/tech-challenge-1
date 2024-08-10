using ContactsManagement.Application.DTOs.Auth;
using ContactsManagement.Application.DTOs.User.GetUser;
using ContactsManagement.Application.Interfaces.Auth;
using ContactsManagement.Application.Interfaces.User.ValidateUser;
using ContactsManagement.Domain.Entities;
using ContactsManagement.Infrastructure.Repositories.User;
using ContactsManagement.Infrastructure.UnitOfWork;


namespace ContactsManagement.Application.Handlers.User.ValidateUser
{
    public class ValidateUserHandler : IValidateUserHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private IPasswordHandler _passwordHandler;

        public ValidateUserHandler(IUnitOfWork unitOfWork, IPasswordHandler passwordHandler)
        {
            _unitOfWork = unitOfWork;
            _passwordHandler = passwordHandler;
        }

        public async Task<GetUserResponse?> HandleAsync(LoginRequest request)
        {
            var user = await this._unitOfWork.UserRepository.GetByNameAsync(request.Username);

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