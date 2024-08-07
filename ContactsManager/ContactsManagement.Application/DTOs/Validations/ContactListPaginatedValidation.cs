using ContactsManagement.Application.DTOs.Contact.GetContatListPaginatedByFilters;
using FluentValidation;

namespace ContactsManagement.Application.DTOs.Validations
{
    public class ContactListPaginatedValidation : AbstractValidator<GetContatListPaginatedByFiltersRequest>
    {
        public ContactListPaginatedValidation()
        {
            RuleFor(c => c.CurrentPage)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.PageSize)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Ddd.ToString())
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
