using ContactsManagement.Domain.Entities;
using ContactsManagement.Domain.Enums;
using ContactsManagement.Infrastructure.Data;
using Dapper;

namespace ContactsManagement.Domain.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _session;
        private const string TABLE_NAME = "ApiUser";
        private const string SCHEMA = "ContactsManagement";

        public UserRepository(DapperContext session) => _session = session;

        public async Task CreateAsync(UserEntity model) =>
            await _session.Connection.ExecuteAsync(
                $@"INSERT INTO
                    [{SCHEMA}].[{TABLE_NAME}]
                         ({nameof(UserEntity.Username)},
                          {nameof(UserEntity.Password)},
                          {nameof(UserEntity.UserType)})
                    VALUES
                          ('{model.Username}',
                           '{model.Password}',
                           {(int)model.UserType});",
                _session.Transaction);

        public async Task DeleteByIdAsync(int id) =>
            await _session.Connection.QueryFirstOrDefaultAsync<UserEntity>(
                $"DELETE FROM [{SCHEMA}].[{TABLE_NAME}] WHERE {nameof(UserEntity.Id)} = {id};",
                _session.Transaction);

        public async Task<IEnumerable<UserEntity>> GetAllAsync() =>
            await _session.Connection.QueryAsync<UserEntity>(
                $@"SELECT * FROM [{SCHEMA}].[{TABLE_NAME}]");

        public async Task<UserEntity?> GetByIdAsync(int id) =>
            await _session.Connection.QueryFirstOrDefaultAsync<UserEntity>(
                $"SELECT * FROM [{SCHEMA}].[{TABLE_NAME}] WHERE {nameof(UserEntity.Id)} = {id};",
                _session.Transaction);

        public async Task<UserEntity?> GetByNameAsync(string username) =>
            await _session.Connection.QueryFirstOrDefaultAsync<UserEntity>(
                $"SELECT * FROM [{SCHEMA}].[{TABLE_NAME}] WHERE {nameof(UserEntity.Username)} = '{username}';",
                _session.Transaction);

        public async Task UpdateByIdAsync(int id, string? username, string? password, EUserType? userType)
        {
            var updateColumns = new List<string>();

            if (!string.IsNullOrEmpty(username))
                updateColumns.Add($"{nameof(UserEntity.Username)} = '{username}'");
            if (!string.IsNullOrEmpty(password))
                updateColumns.Add($"{nameof(UserEntity.Password)} = '{password}'");
            if (userType.HasValue)
                updateColumns.Add($"{nameof(UserEntity.UserType)} = {(int)userType.Value}");

            await _session.Connection.QueryFirstOrDefaultAsync<UserEntity>(
                $@"UPDATE [{SCHEMA}].[{TABLE_NAME}]
                   SET {string.Join(",", updateColumns)}
                   WHERE {nameof(UserEntity.Id)} = {id};",
                _session.Transaction);
        }
    }
}