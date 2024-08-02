using ContactsManagement.Application.DTOs.Contact.CreateContact;
using ContactsManagement.Application.DTOs.Contact.GetContatListPaginatedByFilters;
using ContactsManagement.Application.Handlers.Contact.CreateContact;
using ContactsManagement.Application.Handlers.Contact.GetContatListPaginatedByFilters;
using ContactsManagement.Domain.Repositories;
using Moq;

namespace TestesUnitarios.Handlers
{
    public class GetContatListPaginatedByFiltersHandlerTest
    {
        private readonly GetContatListPaginatedByFiltersHandler getContatListPaginatedByFiltersHandler;
        private readonly Mock<IContactRepository> _contactRepository;


        public GetContatListPaginatedByFiltersHandlerTest()
        {
            _contactRepository = new Mock<IContactRepository>();
            getContatListPaginatedByFiltersHandler = new GetContatListPaginatedByFiltersHandler(_contactRepository.Object);
        }

        [Fact]
        public async void GetContatListPaginatedByFiltersSucess()
        {
            GetContatListPaginatedByFiltersRequest filter = new GetContatListPaginatedByFiltersRequest
            {
                CurrentPage = 1,
                PageSize = 10,
                Ddd = 11
            };

            var result = await getContatListPaginatedByFiltersHandler.HandleAsync(filter);

            Assert.True(result.ErrorDescription == null);
        }

        [Fact]
        public async void GetContatListPaginatedByFiltersError()
        {
            GetContatListPaginatedByFiltersRequest filter = new GetContatListPaginatedByFiltersRequest
            {
                CurrentPage = 0,
                PageSize = 0,
                Ddd = 0
            };

            var result = await getContatListPaginatedByFiltersHandler.HandleAsync(filter);

            Assert.True(result.ErrorDescription != null);
        }

    }
}
