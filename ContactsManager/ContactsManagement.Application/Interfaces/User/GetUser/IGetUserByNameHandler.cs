using ContactsManagement.Application.DTOs.User.GetUser;
using ContactsManagement.Application.Handlers.User.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Application.Interfaces.User.GetUser
{
    public interface IGetUserByNameHandler : IRequestHandler<GetUserByNameRequest, GetUserResponse?>
    {
    }
}
