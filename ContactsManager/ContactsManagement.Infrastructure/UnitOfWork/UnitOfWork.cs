using ContactsManagement.Infrastructure.Repositories.Contact;
using ContactsManagement.Infrastructure.Repositories.User;
using ContactsManagement.Infrastructure.Repositoriess.User;
using System.Transactions;

namespace ContactsManagement.Infrastructure.UnitOfWork;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ITech1Database _tech1Dabase;

    public IContactRepository ContactRepository { get; }

    public IUserRepository UserRepository { get; }

    public UnitOfWork(ITech1Database database)
    {
        this._tech1Dabase = database;

        this.ContactRepository = new ContactRepository(this._tech1Dabase);
        this.UserRepository = new UserRepository(this._tech1Dabase);
    }

    #region Transaction methods:
    public ITransaction BeginTransaction()
    {
        var tx = new Transaction();
        this._tech1Dabase.EnsureConnectionIdOpen();
        return tx;
    }

    public ITransaction BeginTransaction(TransactionOptions transactionOptions)
    {
        var tx = new Transaction(transactionOptions);
        this._tech1Dabase.EnsureConnectionIdOpen();
        return tx;
    }
    #endregion Transaction methods.

    #region IDispose Support
    public bool disposidedValue = false;

    void Dispose(bool disposing)
    {
        if (disposidedValue)
        {
            this._tech1Dabase.Dispose();
        }
        disposidedValue = true;
    }


    public void Dispose() => this.Dispose(true);

    #endregion


}
