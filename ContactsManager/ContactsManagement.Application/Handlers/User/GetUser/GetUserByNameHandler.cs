using ContactsManagement.Application.DTOs.User.GetUser;
using ContactsManagement.Application.Interfaces.User.GetUser;
using ContactsManagement.Domain.Entities;
using ContactsManagement.Domain.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Application.Handlers.User.GetUser
{
    public class GetUserByNameHandler : IGetUserByNameHandler
    {
        private readonly IUserRepository _userRepository;

        public GetUserByNameHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<GetUserResponse?> HandleAsync(GetUserByNameRequest request)
        {
            var user = await _userRepository.GetByNameAsync(request.Username);

            if (user != null)
                return GetUserByIdHandler.Mapper(user);
            else
                return null;
        }
    }
}
