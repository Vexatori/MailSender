using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data
{
    public class MailsList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Mail> Mails { get; set; }
    }
}
