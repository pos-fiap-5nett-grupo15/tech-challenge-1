using ContactsManagement.Application.DTOs.User.DeleteUser;
using ContactsManagement.Application.Handlers.Contact.CreateContact;
using ContactsManagement.Application.Interfaces.User.DeleteUser;
using ContactsManagement.Domain.Repositories;
using ContactsManagement.Domain.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Application.Handlers.User.DeleteUser
{
    public class DeleteUserHandler : IDeleteUserHandler
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<DeleteUserResponse> HandleAsync(DeleteUserRequest request)
        {
            await _userRepository.DeleteByIdAsync(request.Id);
            return new DeleteUserResponse();
        }
    }
}
