﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MailSender.lib.Interfaces;

namespace MailSender.lib
{
    public class MailService : IMailService
    {
        public IMailSender GetSender( string Address,
                                      int Port,
                                      bool SSL,
                                      string Login,
                                      SecureString Password )
        {
            return new MailSender( Address, Port, SSL, Login, Password );
        }
    }

    internal class MailSender : IMailSender
    {
        private readonly SmtpClient _client;

        public MailSender( string Address,
                           int Port,
                           bool SSl,
                           string Login,
                           SecureString Password )
        {
            _client = new SmtpClient(Address, Port)
            {
                    Credentials = new NetworkCredential(Login, Password),
                    EnableSsl = SSl
            };
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public void Send( string SenderAddress, string RecipientAddress, string Subject, string Body )
        {
            using ( var msg = new MailMessage(SenderAddress, RecipientAddress, Subject, Body) )
            {
                _client.Send( msg );
            }
        }

        public void SendAsync( string SenderAddress, string RecipientAddress, string Subject, string Body )
        {
            var thread = new Thread( () => Send( SenderAddress, RecipientAddress, Subject, Body ) );
            thread.Priority = ThreadPriority.BelowNormal;
            thread.IsBackground = true;
            thread.Start();
        }

        public void Send( string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body )
        {
            foreach ( var recipientAddress in RecipientsAddresses )
            {
                Send( SenderAddress, recipientAddress, Subject, Body );
            }
        }

        public void SendAsync( string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body )
        {
            foreach ( var recipientAddress in RecipientsAddresses ) { ThreadPool.QueueUserWorkItem( m => Send( SenderAddress, recipientAddress, Subject, Body ) ); }
        }
    }
}
