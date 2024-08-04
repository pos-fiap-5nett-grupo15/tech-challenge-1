using ContactsManagement.Application.DTOs.User.UpdateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Application.Interfaces.User.UpdateUser
{
    public interface IUpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
    }
}
