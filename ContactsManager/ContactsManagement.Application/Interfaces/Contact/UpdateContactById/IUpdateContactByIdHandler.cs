using ContactsManagement.Application.DTOs.Contact.UpdateContactById;

namespace ContactsManagement.Application.Interfaces.Contact.UpdateContactById;

public interface IUpdateContactByIdHandler
    : IRequestHandler<UpdateContactByIdRequest, UpdateContactByIdResponse> { }
