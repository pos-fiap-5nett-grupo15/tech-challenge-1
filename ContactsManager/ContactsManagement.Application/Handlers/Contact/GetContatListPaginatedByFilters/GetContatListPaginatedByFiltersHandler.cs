using ContactsManagement.Application.DTOs.Contact.GetContactBydId;
using ContactsManagement.Application.DTOs.Contact.GetContatListPaginatedByFilters;
using ContactsManagement.Application.DTOs.Validations;
using ContactsManagement.Application.Interfaces.Contact.GetContatListPaginatedByFilters;
using ContactsManagement.Domain.Entities;
using ContactsManagement.Domain.Repositories;

namespace ContactsManagement.Application.Handlers.Contact.GetContatListPaginatedByFilters;

public class GetContatListPaginatedByFiltersHandler 
    : IGetContatListPaginatedByFiltersHandler
{
    private readonly IContactRepository _contactRepository;

    public GetContatListPaginatedByFiltersHandler(IContactRepository contactRepository) =>
        _contactRepository = contactRepository;

    public async Task<GetContatListPaginatedByFiltersResponse> HandleAsync(GetContatListPaginatedByFiltersRequest request)
    {
        var validator = new ContactListPaginatedValidation();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var erroMensagem = "";

            foreach (var error in result.Errors)
            {
                erroMensagem += error.ErrorMessage + " ";
            }

            var retorno = new GetContatListPaginatedByFiltersResponse();
            retorno.ErrorDescription = erroMensagem;

            return retorno;

        }
        else
        {
            var contacts = await _contactRepository.GetListPaginatedByFiltersAsync(request.Ddd, request.CurrentPage, request.PageSize);

            return new GetContatListPaginatedByFiltersResponse { Contacts = Mapper(contacts.ToList()) };
        }
    }

    static public IEnumerable<GetContactBydIdResponse> Mapper(List<ContactEntity> models) =>
        models.ConvertAll(x => new GetContactBydIdResponse
        {
            Id = x.Id,
            Nome = x.Nome,
            Email = x.Email,
            Ddd = x.Ddd,
            Telefone = x.Telefone,
        });
}
