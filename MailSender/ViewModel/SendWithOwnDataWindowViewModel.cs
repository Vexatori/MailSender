using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

using MailSender.lib.Data.Debug;
using MailSender.lib.MVVM;

namespace MailSender.ViewModel
{
    public class SendWithOwnDataWindowViewModel : ViewModelBase
    {
        //public string MessageText { get; set; }

        //public string MessageTopic { get; set; }

        //public string MessageSender { get; set; }

        //public string MessageGetter { get; set; }

        //public int SMTPPort => 25;

        //public string SMTPServer { get; set; }

        //public SecureString SenderPassword { get; set; }

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

        private bool CanSendMailCommandExecute(object parametr) => true;

        private void OnSendMailCommandExecute(object parametr)
        {
            var passwordBox = parametr as PasswordBox;
            var password = passwordBox.SecurePassword;
            string strSMTP = $"smtp.{MessageSender.Split( '@' ).Last()}";
            EmailSendServiceClass.GetMailProperties( _messageTopic, _messageText, _messageGetter, _messageSender, _smtpPort, strSMTP, password );
            EmailSendServiceClass.SendMail();
        }

        public SendWithOwnDataWindowViewModel()
        {
            SendMailCommand = new LamdaCommand( OnSendMailCommandExecute, CanSendMailCommandExecute );
        }
    }
}
