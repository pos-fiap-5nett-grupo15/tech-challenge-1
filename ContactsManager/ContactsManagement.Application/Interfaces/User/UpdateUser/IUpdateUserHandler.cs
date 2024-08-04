using ContactsManagement.Application.DTOs.User.UpdateUser;

namespace ContactsManagement.Application.Interfaces.User.UpdateUser
{
    public interface IUpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
    }
}