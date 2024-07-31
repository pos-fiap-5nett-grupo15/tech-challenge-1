namespace ContactsManagement.Infrastructure.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    void BeginTransaction();
    void Commit();
    void Rollback();
}
