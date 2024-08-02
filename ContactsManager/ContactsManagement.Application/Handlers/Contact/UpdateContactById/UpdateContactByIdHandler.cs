using ContactsManagement.Application.DTOs.Contact.CreateContact;
using ContactsManagement.Application.DTOs.Contact.UpdateContactById;
using ContactsManagement.Application.DTOs.Validations;
using ContactsManagement.Application.Interfaces.Contact.UpdateContactById;
using ContactsManagement.Domain.Entities.Validations;
using ContactsManagement.Domain.Repositories;

namespace ContactsManagement.Application.Handlers.Contact.UpdateContactById;

public class UpdateContactByIdHandler : IUpdateContactByIdHandler
{
    private readonly IContactRepository _contactRepository;

    public UpdateContactByIdHandler(IContactRepository contactRepository) =>
        _contactRepository = contactRepository;

    public async Task<UpdateContactByIdResponse> HandleAsync(UpdateContactByIdRequest request)
    {
        var validator = new UpdateByIdValidation();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var erroMensagem = "";

            foreach (var error in result.Errors)
            {
                erroMensagem += error.ErrorMessage + " ";
            }

            var retorno = new UpdateContactByIdResponse();
            retorno.ErrorDescription = erroMensagem;

            return retorno;

        }
        else
        {
            await _contactRepository.UpdateByIdAsync(request.Id.Value, request.Nome, request.Email, request.Ddd, request.Telefone);
            return new UpdateContactByIdResponse();
        }

    }
}
