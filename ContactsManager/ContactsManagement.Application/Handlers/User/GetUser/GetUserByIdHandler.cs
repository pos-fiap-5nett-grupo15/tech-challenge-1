using ContactsManagement.Application.DTOs.User.GetUser;
using ContactsManagement.Application.Interfaces.User.GetUser;
using ContactsManagement.Domain.Entities;
using ContactsManagement.Infrastructure.Repositories.User;
using ContactsManagement.Infrastructure.UnitOfWork;

namespace ContactsManagement.Application.Handlers.User.GetUser
{
    public class GetUserByIdHandler : IGetUserByIdHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<GetUserResponse?> HandleAsync(GetUserByIdRequest request)
        {
            var user = await this._unitOfWork.UserRepository.GetByIdAsync(request.Id);

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