using System;

namespace ContactsManagement.Infrastructure.UnitOfWork
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
