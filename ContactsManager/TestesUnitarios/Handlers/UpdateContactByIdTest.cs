using ContactsManagement.Application.DTOs.Contact.UpdateContactById;
using ContactsManagement.Application.Handlers.Contact.UpdateContactById;
using ContactsManagement.Infrastructure.UnitOfWork;
using Moq;

namespace TestesUnitarios.Handlers
{
    public class UpdateContactByIdTest
    {
        private readonly UpdateContactByIdHandler updateContactByIdHandler;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public UpdateContactByIdTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            updateContactByIdHandler = new UpdateContactByIdHandler(_unitOfWork.Object);
        }

        [Fact]
        public async void UpdateContactByIdSucess()
        {
            UpdateContactByIdRequest Contact = new UpdateContactByIdRequest
            {
                Nome = "Antonia Mesquita",
                Ddd = 11,
                Email = "anto@teste.com",
                Telefone = 996578756
            };

            var result = await updateContactByIdHandler.HandleAsync(Contact);

            Assert.True(result.ErrorDescription == null);
        }

        [Fact]
        public async void UpdateContactByIdError()
        {
            UpdateContactByIdRequest Contact = new UpdateContactByIdRequest
            {
                Nome = null,
                Ddd = 0,
                Email = null,
                Telefone = 0
            };

            var result = await updateContactByIdHandler.HandleAsync(Contact);

            Assert.True(result.ErrorDescription != null);
        }
    }
}
