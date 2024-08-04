using ContactsManagement.Application.DTOs.User.DeleteUser;

namespace ContactsManagement.Application.Interfaces.User.DeleteUser
{
    public interface IDeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
    }
}