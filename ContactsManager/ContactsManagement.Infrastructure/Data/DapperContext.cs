using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ContactsManagement.Infrastructure.Data;

public sealed class DapperContext : IDisposable
{
    public SqlConnection Connection { get; }
    public IDbTransaction? Transaction { get; set; }

    public DapperContext(IConfiguration configuration)
    {
        Connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection") ?? string.Empty);
        Connection.Open();
    }

    public void Dispose() => Connection?.Dispose();
}
