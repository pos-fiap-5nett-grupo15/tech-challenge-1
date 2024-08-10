using ContactsManagement.Application.DTOs.User.GetUser;
using ContactsManagement.Application.DTOs.User.GetUserList;
using ContactsManagement.Application.Interfaces.User.GetUser;
using ContactsManagement.Domain.Entities;
using ContactsManagement.Infrastructure.Repositories.User;
using ContactsManagement.Infrastructure.UnitOfWork;

namespace ContactsManagement.Application.Handlers.User.GetUser
{
    public class GetUserListHandler : IGetUserListHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserListHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<GetUserListResponse?> HandleAsync(GetUserListRequest request)
        {
            var userList = await this._unitOfWork.UserRepository.GetAllAsync();
            if (userList is null)
                return null;
            else
                return new GetUserListResponse { Users = Mapper(userList.ToList()) };
        }

        private static IEnumerable<GetUserResponse> Mapper(List<UserEntity> models) =>
            models.ConvertAll(m => GetUserByIdHandler.Mapper(m));
    }
}