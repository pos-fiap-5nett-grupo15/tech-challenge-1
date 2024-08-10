using ContactsManagement.Application.DTOs.User.CreateUser;
using ContactsManagement.Application.DTOs.User.UpdateUser;
using ContactsManagement.Application.Interfaces.Auth;
using ContactsManagement.Application.Interfaces.User.UpdateUser;
using ContactsManagement.Infrastructure.Repositories.User;
using ContactsManagement.Infrastructure.UnitOfWork;

namespace ContactsManagement.Application.Handlers.User.UpdateUser
{
    public class UpdateUserHandler : IUpdateUserHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHandler _passwordHandler;

        public UpdateUserHandler(IUnitOfWork unitOfWork, IPasswordHandler passwordHandler)
        {
            _unitOfWork = unitOfWork;
            _passwordHandler = passwordHandler;
        }

        public async Task<UpdateUserResponse> HandleAsync(UpdateUserRequest request)
        {
            if (!string.IsNullOrEmpty(request.Password))
            {
                var user = await this._unitOfWork.UserRepository.GetByIdAsync(request.Id.Value);
                request.Password = _passwordHandler.CreatePassword(new CreateUserRequest()
                {
                    UserName = user.Username,
                    UserType = user.UserType,
                    Password = request.Password
                });
            }

            await this._unitOfWork.UserRepository.UpdateByIdAsync(request.Id.Value, request.Username, request.Password, request.UserType);
            return new UpdateUserResponse();
        }
    }
}