using ContactsManagement.Application.DTOs.User.GetUser;
using ContactsManagement.Application.Interfaces.User.GetUser;
using ContactsManagement.Infrastructure.Repositories.User;
using ContactsManagement.Infrastructure.UnitOfWork;

namespace ContactsManagement.Application.Handlers.User.GetUser
{
    public class GetUserByNameHandler : IGetUserByNameHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByNameHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<GetUserResponse?> HandleAsync(GetUserByNameRequest request)
        {
            var user = await this._unitOfWork.UserRepository.GetByNameAsync(request.Username);

            if (user != null)
                return GetUserByIdHandler.Mapper(user);
            else
                return null;
        }
    }
}