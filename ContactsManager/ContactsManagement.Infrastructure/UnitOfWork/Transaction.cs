using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ContactsManagement.Infrastructure.UnitOfWork
{
    public class Transaction : ITransaction
    {
        private TransactionScope _transactionScope;

        public Transaction() {
            this._transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        }


        public Transaction(TransactionOptions transactionScopeOption)
        {
            this._transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionScopeOption, TransactionScopeAsyncFlowOption.Enabled);
        }

        public void Commit()
        {
            this._transactionScope.Complete();
        }

        public void Rollback()
        {
            this.Dispose();
        }

        #region IDisposible Support
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing) this._transactionScope.Dispose();
                this.disposedValue = true;
            }
        }

        public void Dispose() => this.Dispose(true);


        #endregion
    }
}
