using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Infrastructure.Crypto
{
    public interface ICryptoService
    {
        public (string, string) GenerateCryptKeys();
        public string Encrypt(string plainText);
        public string Decrypt(string cipherText);
    }
}