using ContactsManagement.Application.DTOs.Contact.UpdateContactById;
using FluentValidation;

namespace ContactsManagement.Application.DTOs.Validations
{
    public class UpdateByIdValidation : AbstractValidator<UpdateContactByIdRequest>
    {
        public UpdateByIdValidation()
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
