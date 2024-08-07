using ContactsManagement.Application.DTOs.Contact.DeleteContactById;
using ContactsManagement.Application.Handlers.Contact.DeleteContactById;
using ContactsManagement.Domain.Repositories;
using Moq;


namespace TestesUnitarios.Handlers
{
    public class DeleteContactByIdTest
    {

        private readonly DeleteContactByIdHandler deleteContactByIdHandler;
        private readonly Mock<IContactRepository> _contactRepository;

        public DeleteContactByIdTest() 
        {
           _contactRepository = new Mock<IContactRepository>();
           deleteContactByIdHandler = new DeleteContactByIdHandler(_contactRepository.Object);
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
