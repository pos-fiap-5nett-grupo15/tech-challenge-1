using ContactsManagement.Application.DTOs.User.GetUserList;

namespace ContactsManagement.Application.Interfaces.User.GetUser
{
    public interface IGetUserListHandler : IRequestHandler<GetUserListRequest, GetUserListResponse?>
    {
    }
}