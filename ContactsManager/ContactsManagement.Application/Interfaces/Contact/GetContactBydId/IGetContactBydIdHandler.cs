using ContactsManagement.Application.DTOs.Contact.GetContactBydId;

namespace ContactsManagement.Application.Interfaces.Contact.GetContactBydId;

public interface IGetContactBydIdHandler
{
    Task<GetContactBydIdResponse> HandleAsync(GetContactBydIdRequest request);
}
