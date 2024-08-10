using ContactsManagement.Application.DTOs.User.DeleteUser;
using ContactsManagement.Application.Interfaces.User.DeleteUser;
using ContactsManagement.Infrastructure.Repositories.User;
using ContactsManagement.Infrastructure.UnitOfWork;

namespace ContactsManagement.Application.Handlers.User.DeleteUser
{
    public class DeleteUserHandler : IDeleteUserHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<DeleteUserResponse> HandleAsync(DeleteUserRequest request)
        {
            await this._unitOfWork.UserRepository.DeleteByIdAsync(request.Id);
            return new DeleteUserResponse();
        }
    }
}