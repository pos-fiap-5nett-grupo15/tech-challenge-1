using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Infrastructure.Settings
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public int TokenExpiresInMinutes { get; set; } = 5;
    }
}