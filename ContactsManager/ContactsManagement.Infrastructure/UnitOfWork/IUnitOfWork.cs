using ContactsManagement.Infrastructure.Repositories.Contact;
using ContactsManagement.Infrastructure.Repositories.User;
using System.Transactions;

namespace ContactsManagement.Infrastructure.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IContactRepository ContactRepository { get; }
    IUserRepository UserRepository { get; }

    ITransaction BeginTransaction();
    ITransaction BeginTransaction(TransactionOptions transactionOptions);
}