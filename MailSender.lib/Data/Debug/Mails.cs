using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.Debug
{
    public class Mails
    {
        public static List<Mail> Items { get; } = new List<Mail>();
    }

    public class Mail
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
    }
}