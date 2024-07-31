using ContactsManagement.Application.DTOs.Contact.GetContactBydId;

namespace ContactsManagement.Application.Interfaces.Contact.GetContactBydId;

public interface IGetContactBydIdHandler
    : IRequestHandler<GetContactBydIdRequest, GetContactBydIdResponse> { }
