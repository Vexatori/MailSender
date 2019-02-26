using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data
{
    public static class Senders
    {
        public static List<Sender> Items = new List<Sender>()
        {
                new Sender()
                {
                        Id = 1,
                        Name = "Ivanov",
                        Address = "ivanov@yandex.ru",
                },
                new Sender()
                {
                        Id = 2,
                        Name = "Petrov",
                        Address = "petrov@mail.ru",
                },
                new Sender()
                {
                        Id = 3,
                        Name = "Sidorov",
                        Address = "sidorov@gmail.com",
                },
        };
    }
}
