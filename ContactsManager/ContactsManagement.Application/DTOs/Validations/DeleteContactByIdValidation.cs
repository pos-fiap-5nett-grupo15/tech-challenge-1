using ContactsManagement.Application.DTOs.Contact.DeleteContactById;
using FluentValidation;

namespace ContactsManagement.Application.DTOs.Validations
{
    public class DeleteContactByIdValidation : AbstractValidator<DeleteContactByIdRequest>
    {
        public DeleteContactByIdValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
