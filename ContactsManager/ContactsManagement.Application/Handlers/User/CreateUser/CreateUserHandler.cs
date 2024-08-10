using ContactsManagement.Application.DTOs.User.CreateUser;
using ContactsManagement.Application.Interfaces.Auth;
using ContactsManagement.Application.Interfaces.User.CreateUser;
using ContactsManagement.Domain.Entities;
using ContactsManagement.Infrastructure.Repositories.User;
using ContactsManagement.Infrastructure.UnitOfWork;

namespace ContactsManagement.Application.Handlers.User.CreateUser
{
    public class CreateUserHandler : ICreateUserHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHandler _passwordHandler;

        public CreateUserHandler(IUnitOfWork unitOfWork, IPasswordHandler passwordHandler)
        {
            _unitOfWork = unitOfWork;
            _passwordHandler = passwordHandler;
        }

        public async Task<CreateUserResponse> HandleAsync(CreateUserRequest request)
        {
            request.Password = _passwordHandler.CreatePassword(request);

            await this._unitOfWork.UserRepository.CreateAsync(Mapper(request));
            return new CreateUserResponse();
        }

        private static UserEntity Mapper(CreateUserRequest request) =>
            new(username: request.UserName,
                password: request.Password,
                userType: request.UserType);
    }
}