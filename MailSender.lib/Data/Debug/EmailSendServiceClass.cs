using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data.Debug
{
    public static class EmailSendServiceClass
    {
        private static MailMessage _message;
        private static string _messageText;
        private static string _messageTopic;
        private static string _messageSender;
        private static string _messageGetter;
        private static int _smtpPort;
        private static string _smtpServer;
        private static SecureString _senderPassword;

        public static string MessageText { get => _messageText; set => _messageText = value; }
        public static string MessageTopic { get => _messageTopic; set => _messageTopic = value; }
        public static string MessageSender { get => _messageSender; set => _messageSender = value; }
        public static string MessageGetter { get => _messageGetter; set => _messageGetter = value; }
        public static int SMTPPort { get => _smtpPort; set => _smtpPort = value; }
        public static string SMTPServer { get => _smtpServer; set => _smtpServer = value; }
        public static SecureString SenderPassword { get => _senderPassword; set => _senderPassword = value; }

        /// <summary>
        /// Метод получает данные для отправки письма
        /// </summary>
        /// <param name="topic">Тема письма</param>
        /// <param name="text">Текст письма</param>
        /// <param name="getter">Получатель</param>
        /// <param name="sender">Логин отправителя</param>
        /// <param name="password">Пароль отправителя</param>
        public static void GetMailProperties( string topic,
                                              string text,
                                              string getter,
                                              string sender,
                                              int port,
                                              string smtp,
                                              SecureString password )
        {
            _messageText = text;
            _messageTopic = topic;
            _messageGetter = getter;
            _messageSender = sender;
            _smtpPort = port;
            _smtpServer = smtp;
            _senderPassword = password;
        }

        /// <summary>
        /// Метод отправляет письмо
        /// </summary>
        public static void SendMail()
        {
            using ( _message = new MailMessage() )
            {
                _message.From = new MailAddress( _messageSender );
                _message.To.Add( _messageGetter );

                _message.Subject = _messageTopic;
                _message.Body = _messageText;
                _message.IsBodyHtml = false;

                using ( var client = new SmtpClient( _smtpServer, _smtpPort ) )
                {
                    client.EnableSsl = true;

                    client.Credentials = new NetworkCredential( _messageSender, _senderPassword );
                    client.Send( _message );
                }
            }
        }
    }
}