using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data
{
    public class Sender
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
