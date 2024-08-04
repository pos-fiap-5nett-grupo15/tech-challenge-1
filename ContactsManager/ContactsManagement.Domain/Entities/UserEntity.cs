using ContactsManagement.Domain.Enums;

namespace ContactsManagement.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public EUserType UserType { get; set; }

        public UserEntity() { }
        public UserEntity(
            string username,
            string password,
            EUserType userType)
        {
            Username = username;
            Password = password;
            UserType = userType;
        }
    }
}