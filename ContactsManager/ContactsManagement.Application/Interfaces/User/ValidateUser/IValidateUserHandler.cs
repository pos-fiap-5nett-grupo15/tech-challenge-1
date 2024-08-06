using ContactsManagement.Application.DTOs.Auth;
using ContactsManagement.Application.DTOs.User.GetUser;

namespace ContactsManagement.Application.Interfaces.User.ValidateUser
{
    public interface IValidateUserHandler : IRequestHandler<LoginRequest, GetUserResponse?>
    {
    }
}