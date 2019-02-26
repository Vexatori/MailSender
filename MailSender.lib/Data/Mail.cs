using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data
{
    public class Mail
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
    }
}
