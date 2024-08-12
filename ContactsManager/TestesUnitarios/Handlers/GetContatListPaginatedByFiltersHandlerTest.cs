using ContactsManagement.Application.DTOs.Contact.GetContatListPaginatedByFilters;
using ContactsManagement.Application.Handlers.Contact.GetContatListPaginatedByFilters;
using ContactsManagement.Domain.Entities;
using ContactsManagement.Infrastructure.Services.Contact;
using ContactsManagement.Infrastructure.UnitOfWork;
using Moq;

namespace TestesUnitarios.Handlers
{
    public class GetContatListPaginatedByFiltersHandlerTest
    {
        private readonly GetContatListPaginatedByFiltersHandler getContatListPaginatedByFiltersHandler;
        private readonly Mock<IContactService> _contactService;


        public GetContatListPaginatedByFiltersHandlerTest()
        {
            _contactService = new Mock<IContactService>();
            getContatListPaginatedByFiltersHandler = new GetContatListPaginatedByFiltersHandler(_contactService.Object);
        }

        [Fact]
        public async void GetContatListPaginatedByFiltersSucess()
        {
            //set
            GetContatListPaginatedByFiltersRequest filter = new GetContatListPaginatedByFiltersRequest
            {
                CurrentPage = 1,
                PageSize = 10,
                Ddd = 11
            };


            this._contactService.Setup(x => x.CreateAsync(It.IsAny<ContactEntity>()))
                            .Returns(Task.CompletedTask);


            //act
            var result = await getContatListPaginatedByFiltersHandler.HandleAsync(filter);

            //assert
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
