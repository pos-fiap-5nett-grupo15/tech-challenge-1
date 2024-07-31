using ContactsManagement.Domain.Entities;

namespace ContactsManagement.Domain.Repositories
{
    public interface IContactRepository
    {
        Task CreateAsync(ContactEntity model);
        Task<ContactEntity?> GetByIdAsync(int id);
        Task<IEnumerable<ContactEntity>> GetListPaginatedByFiltersAsync();
    }
}
