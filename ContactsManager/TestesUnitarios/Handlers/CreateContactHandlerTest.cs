using ContactsManagement.Application.DTOs.Contact.CreateContact;
using ContactsManagement.Application.Handlers.Contact.CreateContact;
using ContactsManagement.Infrastructure.Repositories.Contact;
using Moq;


namespace TestesUnitarios.Handlers
{
    public class CreateContactHandlerTest
    {
        private readonly CreateContactHandler createContactHandler;
        private readonly Mock<IContactRepository> _contactRepository;

        public CreateContactHandlerTest()
        {
            _contactRepository = new Mock<IContactRepository>();
            createContactHandler = new CreateContactHandler(_contactRepository.Object);
        }

        [Fact]
        public async void CreateContactSucess()
        {
            CreateContactRequest Contact = new CreateContactRequest
            {
                Nome = "Antonia Mesquita",
                Ddd = 11,
                Email = "anto@teste.com",
                Telefone = 996578756
            };

            var result = await createContactHandler.HandleAsync(Contact);

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
