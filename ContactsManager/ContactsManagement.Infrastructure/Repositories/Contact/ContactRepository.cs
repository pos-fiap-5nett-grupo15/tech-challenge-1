using ContactsManagement.Domain.Entities;
using ContactsManagement.Infrastructure.Data;
using ContactsManagement.Infrastructure.UnitOfWork;
using Dapper;

namespace ContactsManagement.Infrastructure.Repositories.Contact
{
    public class ContactRepository : IContactRepository
    {
        private readonly ITech1Database _database;
        private const string TABLE_NAME = "Contact";
        private const string SCHEMA = "ContactsManagement";

        public ContactRepository(ITech1Database database) =>
            _database = database;

        public async Task CreateAsync(ContactEntity model) =>
            await _database.Connection.ExecuteAsync(
                $@"INSERT INTO
                    [{SCHEMA}].[{TABLE_NAME}]
                         ({nameof(ContactEntity.Nome)},
                          {nameof(ContactEntity.Email)},
                          {nameof(ContactEntity.Ddd)},
                          {nameof(ContactEntity.Telefone)})
                    VALUES
                          ('{model.Nome}',
                           '{model.Email}',
                           {model.Ddd},
                           {model.Telefone});");

        public async Task<ContactEntity?> GetByIdAsync(int id) =>
            await _database.Connection.QueryFirstOrDefaultAsync<ContactEntity>(
                $"SELECT * FROM [{SCHEMA}].[{TABLE_NAME}] WHERE {nameof(ContactEntity.Id)} = {id};");

        public async Task DeleteByIdAsync(int id) =>
            await _database.Connection.QueryFirstOrDefaultAsync<ContactEntity>(
                $"DELETE FROM [{SCHEMA}].[{TABLE_NAME}] WHERE {nameof(ContactEntity.Id)} = {id};");

        public async Task UpdateByIdAsync(int id, string? nome, string? email, int? ddd, int? telefone) =>
            await _database.Connection.QueryFirstOrDefaultAsync<ContactEntity>(
                $@"UPDATE [{SCHEMA}].[{TABLE_NAME}]
                   SET
                    {(string.IsNullOrWhiteSpace(nome)
                        ? string.Empty
                        : $"{nameof(ContactEntity.Nome)} = '{nome}'")}
                    {(string.IsNullOrWhiteSpace(email)
                        ? string.Empty
                        : $",{nameof(ContactEntity.Email)} = '{email}'")}
                    {(!ddd.HasValue
                        ? string.Empty
                        : $",{nameof(ContactEntity.Ddd)} = {ddd}")}
                    {(!telefone.HasValue
                        ? string.Empty
                        : $",{nameof(ContactEntity.Telefone)} = {telefone}")}
                   WHERE {nameof(ContactEntity.Id)} = {id};");

        public async Task<IEnumerable<ContactEntity>> GetListPaginatedByFiltersAsync(int? ddd, int currentIndex, int pageSize) =>
            await _database.Connection.QueryAsync<ContactEntity>(
                $@"SELECT * FROM [{SCHEMA}].[{TABLE_NAME}]
                   {(!ddd.HasValue
                        ? string.Empty
                        : $"WHERE {nameof(ContactEntity.Ddd)} = {ddd}")}
                   ORDER BY {nameof(ContactEntity.Id)} ASC
                   OFFSET {currentIndex} ROWS FETCH FIRST {pageSize} ROWS ONLY;");
    }
}
