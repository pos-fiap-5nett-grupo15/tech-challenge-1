using ContactsManagement.Application.DTOs.Auth;

namespace ContactsManagement.Application.Interfaces.Auth
{
    public interface ITokenHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
    }
}