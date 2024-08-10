using ContactsManagement.Application.DTOs.Contact.GetContactBydId;
using ContactsManagement.Application.DTOs.Validations;
using ContactsManagement.Application.Interfaces.Contact.GetContactBydId;
using ContactsManagement.Domain.Entities;
using ContactsManagement.Infrastructure.Repositories.Contact;
using ContactsManagement.Infrastructure.UnitOfWork;

namespace ContactsManagement.Application.Handlers.Contact.GetContactBydId;

public class GetContactBydIdHandler : IGetContactBydIdHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetContactBydIdHandler(IUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<GetContactBydIdResponse> HandleAsync(GetContactBydIdRequest request)
    {

        var validator = new GetContactByIdValidation();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            return Mapper(null);

        }
        else
        {
            var contact = await this._unitOfWork.ContactRepository.GetByIdAsync(request.Id);

            return Mapper(contact);
        }
    }

    static public GetContactBydIdResponse? Mapper(ContactEntity? model) =>
        model is null
        ? null
        : new GetContactBydIdResponse
        {
            Id = model.Id,
            Nome = model.Nome,
            Email = model.Email,
            Ddd = model.Ddd,
            Telefone = model.Telefone,
        };
}
