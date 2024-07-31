using ContactsManagement.Domain.Entities;

namespace ContactsManagement.Domain.Repositories
{
    public interface IContactRepository
    {
        Task CreateAsync(ContactModel model);
        Task<ContactModel?> GetByIdAsync(int id);
        Task<IEnumerable<ContactModel>> GetListPaginatedByFiltersAsync();
    }
}
