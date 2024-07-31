﻿using ContactsManagement.Application.DTOs.Contact.GetContactBydId;
using ContactsManagement.Application.Interfaces.Contact.GetContactBydId;
using ContactsManagement.Domain.Entities;
using ContactsManagement.Domain.Repositories;

namespace ContactsManagement.Application.Handlers.Contact.GetContactBydId;

public class GetContactBydIdHandler : IGetContactBydIdHandler
{
    private readonly IContactRepository _contactRepository;

    public GetContactBydIdHandler(IContactRepository contactRepository) =>
        _contactRepository = contactRepository;

    public async Task<GetContactBydIdResponse> HandleAsync(GetContactBydIdRequest request)
    {
        var contact = await _contactRepository.GetByIdAsync(int.Parse(request.Id));

        return Mapper(contact);
    }

    static public GetContactBydIdResponse? Mapper(ContactModel? model) =>
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
