using ContactsManagement.Application.DTOs.User.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Application.Interfaces.User.CreateUser
{
    public interface ICreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
    }
}