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
        private static MailMessage message;
        private static string messageText;
        private static string messageTopic;
        private static string messageSender;
        private static string messageGetter;
        private static SecureString senderPassword;

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
                                              SecureString password )
        {
            messageText = text;
            messageTopic = topic;
            messageGetter = getter;
            messageSender = sender;
            senderPassword = password;
        }

        /// <summary>
        /// Метод отправляет письмо
        /// </summary>
        //public static void SendMail()
        //{
        //    using(message = new MailMessage())
        //    {
        //        message.From = new MailAddress(messageSender);
        //        message.To.Add(messageGetter);

        //        message.Subject = messageTopic;
        //        message.Body = messageText;
        //        message.IsBodyHtml = false;

        //        using(var client = new SmtpClient(MailYandex.SMTP, MailYandex.PORT))
        //        {
        //            client.EnableSsl = true;

        //            client.Credentials = new NetworkCredential(messageSender, senderPassword);
        //            client.Send(message);
        //        }
        //    }
        //}
    }
}
