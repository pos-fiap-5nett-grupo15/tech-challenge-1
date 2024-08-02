using ContactsManagement.Application.DTOs.Contact.CreateContact;
using FluentValidation;

namespace ContactsManagement.Domain.Entities.Validations
{
    public class ContactValidation : AbstractValidator<CreateContactRequest>
    {
        public ContactValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Ddd.ToString())
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Telefone.ToString())
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecida");
        }
    }
}
