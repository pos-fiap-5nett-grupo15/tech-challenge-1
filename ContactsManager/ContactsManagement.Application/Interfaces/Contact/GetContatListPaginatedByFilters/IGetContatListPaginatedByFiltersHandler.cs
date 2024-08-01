﻿using ContactsManagement.Application.DTOs.Contact.GetContatListPaginatedByFilters;

namespace ContactsManagement.Application.Interfaces.Contact.GetContatListPaginatedByFilters;

public interface IGetContatListPaginatedByFiltersHandler
    : IRequestHandler<GetContatListPaginatedByFiltersRequest, GetContatListPaginatedByFiltersResponse> { }
