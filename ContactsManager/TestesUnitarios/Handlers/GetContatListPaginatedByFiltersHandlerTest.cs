using ContactsManagement.Application.DTOs.Contact.GetContatListPaginatedByFilters;
using ContactsManagement.Application.Handlers.Contact.GetContatListPaginatedByFilters;
using ContactsManagement.Domain.Entities;
using ContactsManagement.Infrastructure.UnitOfWork;
using Moq;

namespace TestesUnitarios.Handlers
{
    public class GetContatListPaginatedByFiltersHandlerTest
    {
        private readonly GetContatListPaginatedByFiltersHandler getContatListPaginatedByFiltersHandler;
        private readonly Mock<IUnitOfWork> _unitOfWork;


        public GetContatListPaginatedByFiltersHandlerTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            getContatListPaginatedByFiltersHandler = new GetContatListPaginatedByFiltersHandler(_unitOfWork.Object);
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


            this._unitOfWork.Setup(x => x.ContactRepository.CreateAsync(It.IsAny<ContactEntity>()))
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
