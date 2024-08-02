using ContactsManagement.Application.DTOs.Contact.CreateContact;
using ContactsManagement.Application.Interfaces.Contact.CreateContact;
using ContactsManagement.Domain.Entities;
using ContactsManagement.Domain.Entities.Validations;
using ContactsManagement.Domain.Repositories;
using FluentValidation;

namespace ContactsManagement.Application.Handlers.Contact.CreateContact;

public class CreateContactHandler : ICreateContactHandler
{
    private readonly IContactRepository _contactRepository;

    public CreateContactHandler(IContactRepository contactRepository) =>
        _contactRepository = contactRepository;
    
    public async Task<CreateContactResponse> HandleAsync(CreateContactRequest request)
    {
        var validator = new ContactValidation();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var erroMensagem = "";

            foreach (var error in result.Errors)
            {
                erroMensagem += error.ErrorMessage + " ";
            }

            var retorno = new CreateContactResponse();
            retorno.ErrorDescription = erroMensagem;

            return retorno;

        }
        else
        {
            await _contactRepository.CreateAsync(Mapper(request));
            return new CreateContactResponse();
        }
    }


    public static ContactEntity Mapper(CreateContactRequest request) =>
        new(nome: request.Nome ?? string.Empty,
            email: request.Email ?? string.Empty,
            ddd: request.Ddd,
            telefone: request.Telefone);
}
