using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data
{
    public static class Servers
    {
        public static List<Server> Items { get; } = new List<Server>
        {
                new Server
                {
                        Name = "Яндекс",
                        Address = "smtp.yandex.ru",
                        Port = 25,
                        UseSSL = true,
                        Login = "login",
                        Password = "password"
                },
                new Server
                {
                        Name = "Mail",
                        Address = "smtp.mail.ru",
                        Port = 25,
                        UseSSL = true,
                        Login = "login",
                        Password = "password"
                },
                new Server
                {
                        Name = "Google",
                        Address = "smtp.gmail.com",
                        Port = 25,
                        UseSSL = true,
                        Login = "login",
                        Password = "password"
                },
        };
    }
}