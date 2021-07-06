using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data
{
    public class SendingList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Recipient> Recipients { get; set; }
    }
}
