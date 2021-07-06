using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

using MailSender.lib.Interfaces;

namespace MailSender.Infrastructure
{
    internal class DebugMailService : IMailService
    {
        public IMailSender GetSender( string Address, int Port, bool SSL, string Login, SecureString Password )
        {
            return new DebugMailSender( Address, Port, SSL, Login, Password );
        }
    }
}