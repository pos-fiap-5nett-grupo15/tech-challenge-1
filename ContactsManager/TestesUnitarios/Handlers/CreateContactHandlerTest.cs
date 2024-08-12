using ContactsManagement.Application.DTOs.Contact.CreateContact;
using ContactsManagement.Application.Handlers.Contact.CreateContact;
using ContactsManagement.Domain.Entities;
using ContactsManagement.Infrastructure.Services.Contact;
using ContactsManagement.Infrastructure.UnitOfWork;
using Moq;

namespace TestesUnitarios.Handlers
{
    public class CreateContactHandlerTest
    {
        private readonly CreateContactHandler createContactHandler;
        private readonly Mock<IContactService> _contactService;

        public CreateContactHandlerTest()
        {
            _contactService = new Mock<IContactService>();
            createContactHandler = new CreateContactHandler(_contactService.Object);
        }

        [Fact]
        public async void CreateContactSucess()
        {

            //set
            CreateContactRequest Contact = new CreateContactRequest
            {
                Nome = "Antonia Mesquita",
                Ddd = 11,
                Email = "anto@teste.com",
                Telefone = 996578756
            };

            this._contactService.Setup(x => x.CreateAsync(It.IsAny<ContactEntity>()))
                            .Returns(Task.CompletedTask);

            //act
            var result = await createContactHandler.HandleAsync(Contact);

            //assert
            Assert.True(result.ErrorDescription == null);
        }

        [Fact]
        public async void CreateContactError()
        {
            CreateContactRequest Contact = new CreateContactRequest
            {
                Nome = null,
                Ddd = 0,
                Email = null,
                Telefone = 0
            };

            var result = await createContactHandler.HandleAsync(Contact);

            Assert.True(result.ErrorDescription != null);
        }

    }
}
