using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Interfaces
{
    public interface IMailSender : IDisposable
    {
        void Send( string SenderAddress, string RecipientAddress, string Subject, string Body );

        void SendParallel( string SenderAddress, string RecipientAddress, string Subject, string Body );

        Task SendAsync( string SenderAddress, string RecipientAddress, string Subject, string Body );

        void Send( string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body );

        void SendParallel( string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body );

        Task SendAsync( string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body );
    }
}