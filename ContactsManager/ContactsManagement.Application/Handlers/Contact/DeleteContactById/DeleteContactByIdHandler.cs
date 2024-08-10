﻿using ContactsManagement.Application.DTOs.Contact.DeleteContactById;
using ContactsManagement.Application.DTOs.Validations;
using ContactsManagement.Application.Interfaces.Contact.DeleteContactById;
using ContactsManagement.Infrastructure.Repositories.Contact;
using ContactsManagement.Infrastructure.UnitOfWork;

namespace ContactsManagement.Application.Handlers.Contact.DeleteContactById;

public class DeleteContactByIdHandler : IDeleteContactByIdHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteContactByIdHandler(IUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<DeleteContactByIdResponse> HandleAsync(DeleteContactByIdRequest request)
    {
        var validator = new DeleteContactByIdValidation();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var erroMensagem = "";

            foreach (var error in result.Errors)
            {
                erroMensagem += error.ErrorMessage + " ";
            }

            var retorno = new DeleteContactByIdResponse();
            retorno.ErrorDescription = erroMensagem;

            return retorno;

        }
        else
        {
            await this._unitOfWork.ContactRepository.DeleteByIdAsync(request.Id);
            return new DeleteContactByIdResponse();
        }

    }
}
