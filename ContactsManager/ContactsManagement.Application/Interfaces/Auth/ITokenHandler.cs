using ContactsManagement.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Application.Interfaces.Auth
{
    public interface ITokenHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
    }
}