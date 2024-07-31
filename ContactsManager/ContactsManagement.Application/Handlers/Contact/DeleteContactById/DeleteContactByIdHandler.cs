using ContactsManagement.Application.DTOs.Contact.DeleteContactById;
using ContactsManagement.Application.Interfaces.Contact.DeleteContactById;
using ContactsManagement.Domain.Repositories;

namespace ContactsManagement.Application.Handlers.Contact.DeleteContactById;

public class DeleteContactByIdHandler : IDeleteContactByIdHandler
{
    private readonly IContactRepository _contactRepository;

    public DeleteContactByIdHandler(IContactRepository contactRepository) =>
        _contactRepository = contactRepository;

    public async Task<DeleteContactByIdResponse> HandleAsync(DeleteContactByIdRequest request)
    {
        await _contactRepository.DeleteByIdAsync(request.Id);
        return new DeleteContactByIdResponse();
    }
}
