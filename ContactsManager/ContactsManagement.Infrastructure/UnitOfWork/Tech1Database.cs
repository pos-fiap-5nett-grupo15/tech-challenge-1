using ContactsManagement.Infrastructure.Crypto;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Infrastructure.UnitOfWork
{
    public class Tech1Database : BaseConnection, ITech1Database
    {
        public Tech1Database(IConfiguration configuration, ICryptoService cryptoService) : base(configuration, cryptoService)
        {
            
        }
    }
}
