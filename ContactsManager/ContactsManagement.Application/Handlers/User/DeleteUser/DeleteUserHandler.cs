using ContactsManagement.Application.DTOs.User.DeleteUser;
using ContactsManagement.Application.Interfaces.User.DeleteUser;
using ContactsManagement.Domain.Repositories.User;

namespace ContactsManagement.Application.Handlers.User.DeleteUser
{
    public class DeleteUserHandler : IDeleteUserHandler
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<DeleteUserResponse> HandleAsync(DeleteUserRequest request)
        {
            await _userRepository.DeleteByIdAsync(request.Id);
            return new DeleteUserResponse();
        }
    }
}