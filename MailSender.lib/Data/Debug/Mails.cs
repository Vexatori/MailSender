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
        private static List<Mail> _items = new List<Mail>();

        public static List<Mail> Items => _items;
    }

    public class Mail
    {
        public string Topic { get; set; }
        public string Text { get; set; }
    }
}