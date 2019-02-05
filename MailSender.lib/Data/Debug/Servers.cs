using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data.Debug
{
    public static class Servers
    {
        public static List<Server> Items = new List<Server>()
        {
                new Server()
                {
                        Id = 1,
                        Name = "Yandex",
                        Address = "smtp.yandex.ru",
                        Port = 25,
                        UseSSL = true
                },
                new Server()
                {
                        Id = 2,
                        Name = "Mail",
                        Address = "smtp.mail.ru",
                        Port = 25,
                        UseSSL = true
                },
                new Server()
                {
                        Id = 3,
                        Name = "Google",
                        Address = "smtp.gmail.com",
                        Port = 25,
                        UseSSL = true
                }
        };
    }

    public class Server
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Port { get; set; } = 25;
        public bool UseSSL { get; set; }
    }
}