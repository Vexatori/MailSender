using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data
{
    public class Server
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public int Port { get; set; } = 25;

        public bool UseSSL { get; set; } = true;

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
