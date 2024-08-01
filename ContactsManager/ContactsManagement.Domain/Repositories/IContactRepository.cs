using ContactsManagement.Domain.Entities;

namespace ContactsManagement.Domain.Repositories
{
    public interface IContactRepository
    {
        Task CreateAsync(ContactEntity model);
        Task<ContactEntity?> GetByIdAsync(int id);
        Task DeleteByIdAsync(int id);
        Task UpdateByIdAsync(int id, string? nome, string? email, int? ddd, int? telefone);
        Task<IEnumerable<ContactEntity>> GetListPaginatedByFiltersAsync(int? ddd, int currentIndex, int pageSize);
    }
}
