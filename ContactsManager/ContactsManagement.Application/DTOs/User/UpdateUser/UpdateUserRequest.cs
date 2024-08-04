using ContactsManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
