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
    public class GetUserByIdHandler : IGetUserByIdHandler
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<GetUserResponse?> HandleAsync(GetUserByIdRequest request)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user != null)
                return Mapper(user);
            else
                return null;
        }

        public static GetUserResponse Mapper(UserEntity model) =>
            new()
            {
                Id = model.Id,
                Username = model.Username,
                UserType = model.UserType.ToString()
            };
    }
}
