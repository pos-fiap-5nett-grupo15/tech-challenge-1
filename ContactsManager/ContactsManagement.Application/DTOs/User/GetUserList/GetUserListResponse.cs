using ContactsManagement.Application.DTOs.User.GetUser;

namespace ContactsManagement.Application.DTOs.User.GetUserList
{
    public class GetUserListResponse
    {
        public IEnumerable<GetUserResponse> Users { get; set; }
    }
}
