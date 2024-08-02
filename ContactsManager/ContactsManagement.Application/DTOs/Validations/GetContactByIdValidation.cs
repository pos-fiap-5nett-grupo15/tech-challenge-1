using ContactsManagement.Application.DTOs.Contact.GetContactBydId;
using FluentValidation;

namespace ContactsManagement.Application.DTOs.Validations
{
    public class GetContactByIdValidation : AbstractValidator<GetContactBydIdRequest>
    {
        public GetContactByIdValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
