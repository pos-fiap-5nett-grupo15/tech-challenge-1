using ContactsManagement.Application.DTOs.Auth;
using ContactsManagement.Application.DTOs.User.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Application.Interfaces.User.ValidateUser
{
    public interface IValidateUserHandler : IRequestHandler<LoginRequest, GetUserResponse?>
    {
    }
}
