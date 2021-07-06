using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

using MailSender.lib.Data;
using MailSender.lib.MVVM;
using MailSender.lib.Services;

namespace MailSender.ViewModel
{
    public class SendWithOwnDataWindowViewModel : ViewModelBase
    {
        private string _messageText = String.Empty;
        private string _messageTopic = String.Empty;
        private string _messageSender = String.Empty;
        private string _messageGetter = String.Empty;
        private int _smtpPort = 25;
        private string _smtpServer = String.Empty;
        private SecureString _senderPassword = new SecureString();

        public string MessageText { get => _messageText; set => _messageText = value; }
        public string MessageTopic { get => _messageTopic; set => _messageTopic = value; }
        public string MessageSender { get => _messageSender; set => _messageSender = value; }
        public string MessageGetter { get => _messageGetter; set => _messageGetter = value; }
        public int SMTPPort { get => _smtpPort; set => _smtpPort = 25; }
        public string SMTPServer { get => _smtpServer; set => _smtpServer = value; }
        public SecureString SenderPassword { get => _senderPassword; set => _senderPassword = value; }

        public ICommand SendMailCommand { get; }

        private bool CanSendMailCommandExecute( object parametr ) => true;

        private async void OnSendMailCommandExecute( object parametr )
        {
            var passwordBox = parametr as PasswordBox;
            _senderPassword = passwordBox.SecurePassword;
            _smtpServer = $"smtp.{MessageSender.Split( '@' ).Last()}";
            using ( MailMessage msg = new MailMessage( _messageSender, _messageGetter ) )
            {
                msg.From = new MailAddress( _messageSender );
                msg.To.Add( _messageGetter );

                msg.Subject = _messageTopic;
                msg.Body = _messageText;
                msg.IsBodyHtml = false;
                msg.Priority = MailPriority.High;

                using ( SmtpClient client = new SmtpClient( _smtpServer, _smtpPort ) )
                {
                    client.EnableSsl = true;

                    client.Credentials = new NetworkCredential( _messageSender, _senderPassword );
                    try
                    {
                        //client.SendAsync( msg, null );
                        await client.SendMailAsync( msg );
                    }
                    catch ( SmtpException )
                    {
                        MessageBox.Show( "Сообщение не отправлено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
                    }
                }
            }
        }

        public SendWithOwnDataWindowViewModel()
        {
            SendMailCommand = new LamdaCommand( OnSendMailCommandExecute, CanSendMailCommandExecute );
        }
    }
}