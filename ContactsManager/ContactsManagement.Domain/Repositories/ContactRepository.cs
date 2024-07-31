using ContactsManagement.Domain.Entities;
using ContactsManagement.Infrastructure.Data;
using Dapper;

namespace ContactsManagement.Domain.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DapperContext _session;
        private const string TABLE_NAME = "Contact";

        public ContactRepository(DapperContext session) =>
            _session = session;

        public async Task CreateAsync(ContactEntity model) =>
            await _session.Connection.ExecuteAsync(
                $@"INSERT INTO
                    [dbo].[{TABLE_NAME}]
                         ({nameof(ContactEntity.Nome)},
                          {nameof(ContactEntity.Email)},
                          {nameof(ContactEntity.Ddd)},
                          {nameof(ContactEntity.Telefone)})
                    VALUES
                          ('{model.Nome}',
                           '{model.Email}',
                           {model.Ddd},
                           {model.Telefone})",
                null,
                _session.Transaction);

        public async Task<ContactEntity?> GetByIdAsync(int id) =>
            await _session.Connection.QueryFirstOrDefaultAsync<ContactEntity>(
                $"SELECT * FROM [{TABLE_NAME}] WHERE {nameof(ContactEntity.Id)} = {id}",
                _session.Transaction);

        public async Task<IEnumerable<ContactEntity>> GetListPaginatedByFiltersAsync() =>
            await _session.Connection.QueryAsync<ContactEntity>(
                $"SELECT * FROM [{TABLE_NAME}]",
                null,
                _session.Transaction);
    }
}
