using ContactsManagement.Infrastructure.Data;

namespace ContactsManagement.Infrastructure.UnitOfWork;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly DapperContext _session;

    public UnitOfWork(DapperContext session) => 
        _session = session;

    #region Transaction methods:
    public void BeginTransaction()
    {
        _session.Transaction = _session.Connection.BeginTransaction();
    }

    public void Commit()
    {
        _session.Transaction.Commit();
        Dispose();
    }

    public void Rollback()
    {
        _session.Transaction.Rollback();
        Dispose();
    }

    public void Dispose() => _session.Transaction?.Dispose();
    #endregion Transaction methods.
}
