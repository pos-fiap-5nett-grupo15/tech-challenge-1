using ContactsManagement.Application.DTOs.User.CreateUser;
using ContactsManagement.Application.DTOs.User.UpdateUser;
using ContactsManagement.Application.Interfaces.Auth;
using ContactsManagement.Application.Interfaces.User.UpdateUser;
using ContactsManagement.Domain.Repositories.User;

namespace ContactsManagement.Application.Handlers.User.UpdateUser
{
    public class UpdateUserHandler : IUpdateUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHandler _passwordHandler;

        public UpdateUserHandler(IUserRepository contactRepository, IPasswordHandler passwordHandler)
        {
            _userRepository = contactRepository;
            _passwordHandler = passwordHandler;
        }

        public async Task<UpdateUserResponse> HandleAsync(UpdateUserRequest request)
        {
            if (!string.IsNullOrEmpty(request.Password))
            {
                var user = await _userRepository.GetByIdAsync(request.Id.Value);
                request.Password = _passwordHandler.CreatePassword(new CreateUserRequest()
                {
                    UserName = user.Username,
                    UserType = user.UserType,
                    Password = request.Password
                });
            }

            await _userRepository.UpdateByIdAsync(request.Id.Value, request.Username, request.Password, (int)request.UserType);
            return new UpdateUserResponse();
        }
    }
}