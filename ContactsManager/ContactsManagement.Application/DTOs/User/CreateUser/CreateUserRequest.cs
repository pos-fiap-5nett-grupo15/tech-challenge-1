using ContactsManagement.Domain.Enums;

namespace ContactsManagement.Application.DTOs.User.CreateUser
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public EUserType UserType { get; set; }
    }
}
