using ContactsManagement.Infrastructure.Crypto;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ContactsManagement.Infrastructure.Data;

public sealed class DapperContext : IDisposable
{
    public IDbConnection Connection { get; }
    public IDbTransaction? Transaction { get; set; }

    public DapperContext(IConfiguration configuration, ICryptoService cryptoService)
    {
        var strconnection = configuration.GetConnectionString("DefaultConnection");

        if (!string.IsNullOrEmpty(strconnection))
            strconnection = cryptoService.Decrypt(strconnection);

        Connection = new SqlConnection(strconnection);
        Connection.Open();
    }

    public void Dispose() => Connection?.Dispose();
}
