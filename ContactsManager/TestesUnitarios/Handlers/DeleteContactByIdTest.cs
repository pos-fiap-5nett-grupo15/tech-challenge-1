using ContactsManagement.Application.DTOs.Contact.DeleteContactById;
using ContactsManagement.Application.Handlers.Contact.DeleteContactById;
using ContactsManagement.Domain.Entities;
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
            //set
            this._unitOfWork.Setup(x => x.ContactRepository.DeleteByIdAsync(It.IsAny<int>())
)                           .Returns(Task.CompletedTask);

            DeleteContactByIdRequest request = new DeleteContactByIdRequest
            {
                Id = 1
            };

            //act
            var result = await deleteContactByIdHandler.HandleAsync(request);

            //assert
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
