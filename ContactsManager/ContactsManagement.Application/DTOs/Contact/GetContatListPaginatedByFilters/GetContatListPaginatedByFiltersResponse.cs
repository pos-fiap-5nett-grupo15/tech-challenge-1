using ContactsManagement.Application.DTOs.Contact.GetContactBydId;

namespace ContactsManagement.Application.DTOs.Contact.GetContatListPaginatedByFilters;

public class GetContatListPaginatedByFiltersResponse : BaseReponse
{
    public IEnumerable<GetContactBydIdResponse> Contacts { get; set; } = [];
}
