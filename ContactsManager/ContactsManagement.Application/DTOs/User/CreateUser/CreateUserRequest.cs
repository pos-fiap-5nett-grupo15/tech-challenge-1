using ContactsManagement.Domain.Entities;
using ContactsManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Application.DTOs.User.CreateUser
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public EUserType UserType { get; set; }
    }
}
