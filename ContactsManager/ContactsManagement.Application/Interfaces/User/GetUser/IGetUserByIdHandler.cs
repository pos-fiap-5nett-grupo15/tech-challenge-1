using ContactsManagement.Application.DTOs.User.GetUser;

namespace ContactsManagement.Application.Interfaces.User.GetUser
{
    public interface IGetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserResponse?>
    {
    }
}