using ContactsManagement.Application.DTOs.User.CreateUser;
using ContactsManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Application.Interfaces.Auth
{
    public interface IPasswordHandler
    {
        public string CreatePassword(CreateUserRequest user);
        public bool ValidatePassword(UserEntity user, string password);
    }
}