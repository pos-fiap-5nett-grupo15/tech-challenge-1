using ContactsManagement.Domain.Entities;
using ContactsManagement.Infrastructure.SqlServer;
using Dapper;

namespace ContactsManagement.Domain.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DbSession _session;
        private const string TABLE_NAME = "Contact";

        public ContactRepository(DbSession session) =>
            _session = session;

        public async Task CreateAsync(ContactModel model) =>
            await _session.Connection.ExecuteAsync(
                $@"INSERT INTO
                    [dbo].[{TABLE_NAME}]
                         ({nameof(ContactModel.Id)},
                          {nameof(ContactModel.Nome)},
                          {nameof(ContactModel.Email)},
                          {nameof(ContactModel.Ddd)},
                          {nameof(ContactModel.Telefone)})
                    VALUES
                          ({model.Id},
                           '{model.Nome}',
                           '{model.Email}',
                           {model.Ddd},
                           {model.Telefone})",
                null,
                _session.Transaction);

        public async Task<ContactModel?> GetByIdAsync(int id) =>
            await _session.Connection.QueryFirstOrDefaultAsync<ContactModel>(
                $"SELECT * FROM [{TABLE_NAME}] WHERE {nameof(ContactModel.Id)} = {id}",
                _session.Transaction);

        public async Task<IEnumerable<ContactModel>> GetListPaginatedByFiltersAsync() =>
            await _session.Connection.QueryAsync<ContactModel>(
                $"SELECT * FROM [{TABLE_NAME}]",
                null,
                _session.Transaction);
    }
}
