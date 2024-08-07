using ContactsManagement.Domain.Enums;
using System.Text.Json.Serialization;

namespace ContactsManagement.Application.DTOs.User.UpdateUser
{
    public class UpdateUserRequest
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public EUserType? UserType { get; set; }
    }
}
