using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

using MailSender.lib.Interfaces;

namespace MailSender.Infrastructure
{
    internal class DebugMailSender : IMailSender
    {
        private readonly string _address;
        private readonly int _port;
        private readonly bool _ssl;
        private readonly string _login;
        private readonly SecureString _password;

        public DebugMailSender( string address,
                                int port,
                                bool ssl,
                                string login,
                                SecureString password )
        {
            _address = address;
            _port = port;
            _ssl = ssl;
            _login = login;
            _password = password;
        }

        public void Dispose() { }

        public void Send( string SenderAddress, string RecipientAddress, string Subject, string Body )
        {
            Trace.TraceInformation( $"Отправка сообщения через сервер {_address}:{_port} (ssl:{_ssl})" +
                             $"\r\n  Login:{_login}" + $"\r\n  Отправитель:{SenderAddress}" +
                             $"\r\n  Получатель:{RecipientAddress}" + $"\r\n  Тема:{Subject}" + $"\r\n  Текст:{Body}" );
        }

        public void SendAsync( string SenderAddress, string RecipientAddress, string Subject, string Body ) { }

        public void Send( string SenderAddress,
                          IEnumerable<string> RecipientsAddresses,
                          string Subject,
                          string Body ) { }

        public void SendAsync( string SenderAddress,
                               IEnumerable<string> RecipientsAddresses,
                               string Subject,
                               string Body ) { }
    }
}