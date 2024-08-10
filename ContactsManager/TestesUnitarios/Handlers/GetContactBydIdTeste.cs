using ContactsManagement.Application.DTOs.Contact.GetContactBydId;
using ContactsManagement.Application.Handlers.Contact.GetContactBydId;
using ContactsManagement.Domain.Entities;
using ContactsManagement.Infrastructure.Repositories.Contact;
using Moq;

namespace TestesUnitarios.Handlers
{
    public class GetContactBydIdTeste
    {
        private readonly GetContactBydIdHandler getContatListPaginatedByFiltersHandlerTest;
        private readonly Mock<IContactRepository> _contactRepository;

        public GetContactBydIdTeste()
        {
            _contactRepository = new Mock<IContactRepository>();
            getContatListPaginatedByFiltersHandlerTest = new GetContactBydIdHandler(_contactRepository.Object);
        }

        [Fact]
        public async void GetContactBydIdSucess()
        {
            GetContactBydIdRequest request = new GetContactBydIdRequest
            {
               Id = 1
            };

            _contactRepository.Setup(x => x.GetByIdAsync(request.Id)).Returns(MockData.GetContact);

            var result = await getContatListPaginatedByFiltersHandlerTest.HandleAsync(request);

            Assert.True(result != null);
        }

        [Fact]
        public async void GetContactBydIdError()
        {
            GetContactBydIdRequest request = new GetContactBydIdRequest
            {
               Id = 0
            };

            var result = await getContatListPaginatedByFiltersHandlerTest.HandleAsync(request);

            Assert.True(result == null);
        }


        public static class MockData
        {
            public static async Task<ContactEntity> GetContact()
            {
                ContactEntity contact = new ContactEntity
                {
                    Id = 1,
                    Ddd = 11,
                    Email = "teste@teste.com",
                    Nome = "Oswaldo Siqueira",
                    Telefone = 987654567
                };

                var result = await Task.FromResult(contact);
                return contact;

            }

        }
    }
}
