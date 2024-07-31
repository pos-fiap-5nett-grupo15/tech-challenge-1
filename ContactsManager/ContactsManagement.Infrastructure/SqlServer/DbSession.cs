using ContactsManagement.Infrastructure.Settings;
using System.Data;
using System.Data.SqlClient;

namespace ContactsManagement.Infrastructure.SqlServer;

public sealed class DbSession : IDisposable
{
    public IDbConnection Connection { get; }
    public IDbTransaction Transaction { get; set; }

    public DbSession(IAppSettings appSettings)
    {
        Connection = new SqlConnection(appSettings.ConnectionStrings);
        Connection.Open();
    }

    public void Dispose() => Connection?.Dispose();
}
