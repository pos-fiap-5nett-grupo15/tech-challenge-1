using ContactsManagement.Application.DTOs.Contact.DeleteContactById;
using ContactsManagement.Application.Handlers.Contact.DeleteContactById;
using ContactsManagement.Infrastructure.Services.Contact;
using Moq;

namespace TestesUnitarios.Handlers
{
    public class DeleteContactByIdTest
    {

        private readonly DeleteContactByIdHandler deleteContactByIdHandler;
        private readonly Mock<IContactService> _contactService;

        public DeleteContactByIdTest() 
        {
            _contactService = new Mock<IContactService>();
           deleteContactByIdHandler = new DeleteContactByIdHandler(_contactService.Object);
        }

        [Fact]
        public async void DeleteContactByIdSucess()
        {
            //set
            this._contactService.Setup(x => x.DeleteByIdAsync(It.IsAny<int>())
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
