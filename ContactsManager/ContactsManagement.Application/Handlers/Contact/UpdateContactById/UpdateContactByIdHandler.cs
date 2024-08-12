using ContactsManagement.Application.DTOs.Contact.UpdateContactById;
using ContactsManagement.Application.DTOs.Validations;
using ContactsManagement.Application.Interfaces.Contact.UpdateContactById;
using ContactsManagement.Infrastructure.Services.Contact;

namespace ContactsManagement.Application.Handlers.Contact.UpdateContactById;

public class UpdateContactByIdHandler : IUpdateContactByIdHandler
{
    private readonly IContactService _contactService;

    public UpdateContactByIdHandler(IContactService contactService) =>
        _contactService = contactService;

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
            await this._contactService.UpdateByIdAsync(request.Id.Value, request.Nome, request.Email, request.Ddd, request.Telefone);
            return new UpdateContactByIdResponse();
        }

    }
}
