using ContactsManagement.Application.DTOs.User.GetUser;
using ContactsManagement.Application.DTOs.User.GetUserList;
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
    public class GetUserListHandler : IGetUserListHandler
    {
        private readonly IUserRepository _userRepository;

        public GetUserListHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<GetUserListResponse?> HandleAsync(GetUserListRequest request)
        {
            var userList = await _userRepository.GetAllAsync();
            if (userList is null)
                return null;
            else
                return new GetUserListResponse { Users = Mapper(userList.ToList()) };
        }

        private static IEnumerable<GetUserResponse> Mapper(List<UserEntity> models) =>
            models.ConvertAll(m => GetUserByIdHandler.Mapper(m));
    }
}