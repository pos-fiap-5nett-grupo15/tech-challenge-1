using ContactsManagement.Domain.Entities;
using ContactsManagement.Domain.Enums;
using ContactsManagement.Infrastructure.Repositories.User;
using ContactsManagement.Infrastructure.UnitOfWork;
using Dapper;

namespace ContactsManagement.Infrastructure.Repositoriess.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ITech1Database _database;
        private const string TABLE_NAME = "ApiUser";
        private const string SCHEMA = "ContactsManagement";

        public UserRepository(ITech1Database database) => _database = database;

        public async Task CreateAsync(UserEntity model) =>
            await _database.Connection.ExecuteAsync(
                $@"INSERT INTO
                    [{SCHEMA}].[{TABLE_NAME}]
                         ({nameof(UserEntity.Username)},
                          {nameof(UserEntity.Password)},
                          {nameof(UserEntity.UserType)})
                    VALUES
                          ('{model.Username}',
                           '{model.Password}',
                           {(int)model.UserType});");

        public async Task DeleteByIdAsync(int id) =>
            await _database.Connection.QueryFirstOrDefaultAsync<UserEntity>(
                $"DELETE FROM [{SCHEMA}].[{TABLE_NAME}] WHERE {nameof(UserEntity.Id)} = {id};");

        public async Task<IEnumerable<UserEntity>> GetAllAsync() =>
            await _database.Connection.QueryAsync<UserEntity>(
                $@"SELECT * FROM [{SCHEMA}].[{TABLE_NAME}]");

        public async Task<UserEntity?> GetByIdAsync(int id) =>
            await _database.Connection.QueryFirstOrDefaultAsync<UserEntity>(
                $"SELECT * FROM [{SCHEMA}].[{TABLE_NAME}] WHERE {nameof(UserEntity.Id)} = {id};");

        public async Task<UserEntity?> GetByNameAsync(string username) =>
            await _database.Connection.QueryFirstOrDefaultAsync<UserEntity>(
                $"SELECT * FROM [{SCHEMA}].[{TABLE_NAME}] WHERE {nameof(UserEntity.Username)} = '{username}';");

        public async Task UpdateByIdAsync(int id, string? username, string? password, EUserType? userType)
        {
            var updateColumns = new List<string>();

            if (!string.IsNullOrEmpty(username))
                updateColumns.Add($"{nameof(UserEntity.Username)} = '{username}'");
            if (!string.IsNullOrEmpty(password))
                updateColumns.Add($"{nameof(UserEntity.Password)} = '{password}'");
            if (userType.HasValue)
                updateColumns.Add($"{nameof(UserEntity.UserType)} = {(int)userType.Value}");

            await _database.Connection.QueryFirstOrDefaultAsync<UserEntity>(
                $@"UPDATE [{SCHEMA}].[{TABLE_NAME}]
                   SET {string.Join(",", updateColumns)}
                   WHERE {nameof(UserEntity.Id)} = {id};");
        }
    }
}