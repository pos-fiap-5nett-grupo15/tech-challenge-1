using ContactsManagement.Application.DTOs.Contact.DeleteContactById;

namespace ContactsManagement.Application.Interfaces.Contact.DeleteContactById;

public interface IDeleteContactByIdHandler
    : IRequestHandler<DeleteContactByIdRequest, DeleteContactByIdResponse> { }
