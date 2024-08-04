using ContactsManagement.Application.DTOs.Contact.CreateContact;
using ContactsManagement.Application.DTOs.User.CreateUser;
using ContactsManagement.Application.Interfaces.Auth;
using ContactsManagement.Application.Interfaces.Contact.CreateContact;
using ContactsManagement.Application.Interfaces.User.CreateUser;
using ContactsManagement.Domain.Entities;
using ContactsManagement.Domain.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Application.Handlers.User.CreateUser
{
    public class CreateUserHandler : ICreateUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHandler _passwordHandler;

        public CreateUserHandler(IUserRepository userRepository, IPasswordHandler passwordHandler)
        {
            _userRepository = userRepository;
            _passwordHandler = passwordHandler;
        }

        public async Task<CreateUserResponse> HandleAsync(CreateUserRequest request)
        {
            request.Password = _passwordHandler.CreatePassword(request);

            await _userRepository.CreateAsync(Mapper(request));
            return new CreateUserResponse();
        }

        private static UserEntity Mapper(CreateUserRequest request) =>
            new(username: request.UserName,
                password: request.Password,
                userType: request.UserType);
    }
}
