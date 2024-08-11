using ContactsManagement.Application.DTOs.Contact.DeleteContactById;
using ContactsManagement.Application.Handlers.Contact.DeleteContactById;
using ContactsManagement.Infrastructure.UnitOfWork;
using Moq;

namespace TestesUnitarios.Handlers
{
    public class DeleteContactByIdTest
    {

        private readonly DeleteContactByIdHandler deleteContactByIdHandler;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public DeleteContactByIdTest() 
        {
            _unitOfWork = new Mock<IUnitOfWork>();
           deleteContactByIdHandler = new DeleteContactByIdHandler(_unitOfWork.Object);
        }

        [Fact]
        public async void DeleteContactByIdSucess()
        {
            DeleteContactByIdRequest request = new DeleteContactByIdRequest
            {
                Id = 1
            };

            var result = await deleteContactByIdHandler.HandleAsync(request);

            Assert.True(result.ErrorDescription == null);
        }

        [Fact]
        public async void DeleteContactByIdError()
        {
            DeleteContactByIdRequest request = new DeleteContactByIdRequest
            {
                Id = 0
            };

            var result = await deleteContactByIdHandler.HandleAsync(request);

            Assert.True(result.ErrorDescription != null);
        }
    }
}
