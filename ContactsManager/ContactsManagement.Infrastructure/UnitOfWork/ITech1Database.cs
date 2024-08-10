using System.Data;

namespace ContactsManagement.Infrastructure.UnitOfWork
{
    public interface ITech1Database : IDisposable
    {
        IDbConnection Connection { get; }

        void EnsureConnectionIdOpen();
    }
}
