using ContactsManagement.Application.DTOs.User.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Application.Interfaces.User.GetUser
{
    public interface IGetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserResponse?>
    {
    }
}
