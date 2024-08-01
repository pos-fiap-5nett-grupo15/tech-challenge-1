using ContactsManagement.Application.DTOs.Contact.UpdateContactById;
using ContactsManagement.Application.Interfaces.Contact.UpdateContactById;
using ContactsManagement.Domain.Repositories;

namespace ContactsManagement.Application.Handlers.Contact.UpdateContactById;

public class UpdateContactByIdHandler : IUpdateContactByIdHandler
{
    private readonly IContactRepository _contactRepository;

    public UpdateContactByIdHandler(IContactRepository contactRepository) =>
        _contactRepository = contactRepository;

    public async Task<UpdateContactByIdResponse> HandleAsync(UpdateContactByIdRequest request)
    {
        await _contactRepository.UpdateByIdAsync(request.Id.Value, request.Nome, request.Email, request.Ddd, request.Telefone);
        return new UpdateContactByIdResponse();
    }
}
