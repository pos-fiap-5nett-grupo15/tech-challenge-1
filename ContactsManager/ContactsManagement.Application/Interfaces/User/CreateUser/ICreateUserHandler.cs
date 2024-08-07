using ContactsManagement.Application.DTOs.User.CreateUser;

namespace ContactsManagement.Application.Interfaces.User.CreateUser
{
    public interface ICreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
    }
}