namespace ContactsManagement.Application.DTOs.Contact.GetContatListPaginatedByFilters;

public class GetContatListPaginatedByFiltersRequest
{
    public int? Ddd { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
}
