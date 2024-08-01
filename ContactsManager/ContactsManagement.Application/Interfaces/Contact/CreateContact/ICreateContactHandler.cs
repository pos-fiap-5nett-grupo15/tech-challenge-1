using ContactsManagement.Application.DTOs.Contact.CreateContact;

namespace ContactsManagement.Application.Interfaces.Contact.CreateContact;

public interface ICreateContactHandler
    : IRequestHandler<CreateContactRequest, CreateContactResponse> { }