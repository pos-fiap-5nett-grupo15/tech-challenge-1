using ContactsManagement.Application.DTOs.User.DeleteUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Application.Interfaces.User.DeleteUser
{
    public interface IDeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
    }
}
