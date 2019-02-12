using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data.Debug
{
    public static class MailBoxes
    {
        public static List<MailBox> Items = new List<MailBox>()
        {
                new MailBox()
                {
                        Id = 1,
                        Address = "@yandex.ru"
                },
                new MailBox()
                {
                        Id = 2,
                        Address = "@mail.ru"
                },
                new MailBox()
                {
                        Id = 3,
                        Address = "@gmail.com"
                }
        };
    }

    public class MailBox
    {
        public int Id { get; set; }
        public string Address { get; set; }
    }
}
