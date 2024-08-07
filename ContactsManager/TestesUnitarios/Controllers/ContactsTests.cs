using ContactsManagement.Api.Controllers;
using ContactsManagement.Application.DTOs.Contact.CreateContact;
using ContactsManagement.Application.DTOs.Contact.GetContatListPaginatedByFilters;
using ContactsManagement.Application.DTOs.Contact.UpdateContactById;
using ContactsManagement.Application.Interfaces.Contact.CreateContact;
using ContactsManagement.Application.Interfaces.Contact.DeleteContactById;
using ContactsManagement.Application.Interfaces.Contact.GetContactBydId;
using ContactsManagement.Application.Interfaces.Contact.GetContatListPaginatedByFilters;
using ContactsManagement.Application.Interfaces.Contact.UpdateContactById;
using Moq;

namespace TestesUnitarios.Controllers
{
    public class ContactsTests
    {
        private readonly ContactsController contactsController;
        private readonly Mock<ICreateContactHandler> _createContactHandler;
        private readonly Mock<IGetContactBydIdHandler> _getContactBydIdHandler;
        private readonly Mock<IDeleteContactByIdHandler> _deleteContactByIdHandler;
        private readonly Mock<IUpdateContactByIdHandler> _updateContactByIdHandler;
        private readonly Mock<IGetContactListPaginatedByFiltersHandler> _getContatListPaginatedByFiltersHandler;

        public ContactsTests()
        {
            _getContatListPaginatedByFiltersHandler = new Mock<IGetContactListPaginatedByFiltersHandler>();
            _updateContactByIdHandler = new Mock<IUpdateContactByIdHandler>();
            _deleteContactByIdHandler = new Mock<IDeleteContactByIdHandler>();
            _getContactBydIdHandler = new Mock<IGetContactBydIdHandler>();
            _createContactHandler = new Mock<ICreateContactHandler>();
           contactsController = new ContactsController(_createContactHandler.Object, _getContactBydIdHandler.Object, _deleteContactByIdHandler.Object, _updateContactByIdHandler.Object, _getContatListPaginatedByFiltersHandler.Object);
        }

        [Fact]
        public async void CreateContact()
        {
            CreateContactRequest Contact = new CreateContactRequest{
                Nome = "Antonia Mesquita",
                Ddd = 11,
                Email = "anto@teste.com",
                Telefone = 996578756
            };

            var result = await contactsController.CreateAsync(Contact);

            Assert.NotNull(result);
        }

        [Fact]
        public async void GetByIdAsync()
        {

            var result = await contactsController.GetByIdAsync(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async void GetListPaginatedByFiltersAsync()
        {
            GetContatListPaginatedByFiltersRequest filter = new GetContatListPaginatedByFiltersRequest
            {
                CurrentPage = 1,
                Ddd = 11,
                PageSize = 10
            };

            var result = await contactsController.GetListPaginatedByFiltersAsync(filter);

            Assert.NotNull(result);
        }

        [Fact]
        public async void UpdateByIdAsync()
        {
            UpdateContactByIdRequest Contact = new UpdateContactByIdRequest
            {
                Nome = "Antonia Mesquita",
                Ddd = 12,
                Email = "anto@teste.com",
                Telefone = 996578756
            };

            var result = await contactsController.UpdateByIdAsync(1, Contact);

            Assert.NotNull(result);
        }

    }
}
