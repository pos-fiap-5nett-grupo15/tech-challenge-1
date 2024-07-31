using ContactsManagement.Application.DTOs.Contact.CreateContact;
using ContactsManagement.Application.Interfaces.Contact.CreateContact;
using ContactsManagement.Domain.Entities;
using ContactsManagement.Domain.Repositories;

namespace ContactsManagement.Application.Handlers.Contact.CreateContact;

public class CreateContactHandler : ICreateContactHandler
{
    private readonly IContactRepository _contactRepository;

    public CreateContactHandler(IContactRepository contactRepository) =>
        _contactRepository = contactRepository;

    public async Task<CreateContactResponse> HandleAsync(CreateContactRequest request)
    {
        await _contactRepository.CreateAsync(Mapper(request));
        return new CreateContactResponse();
    }

    public static ContactModel Mapper(CreateContactRequest request) =>
        new(id: new Random().Next(0, int.MaxValue),
            nome: request.Nome ?? string.Empty,
            email: request.Email ?? string.Empty,
            ddd: request.Ddd,
            telefone: request.Telefone);
}
