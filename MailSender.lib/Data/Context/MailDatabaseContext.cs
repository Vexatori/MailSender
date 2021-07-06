using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MailSender.lib.Migrations;

namespace MailSender.lib.Data.Context
{
    public class MailDatabaseContext : DbContext
    {
        static MailDatabaseContext()
        {
            System.Data.Entity.Database.SetInitializer( new MigrateDatabaseToLatestVersion<MailDatabaseContext, Configuration>() );
        }

        public MailDatabaseContext() : base( "name=MailDatabaseContext" ) { }

        //public MailDatabaseContext( string ConnectionStr ) : base( ConnectionStr ) { }

        public DbSet<Mail> Mails { get; set; }

        public DbSet<Sender> Senders { get; set; }

        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<SendingList> SendingLists { get; set; }

        public DbSet<MailsList> MailsLists { get; set; }

        public DbSet<SchedulerTask> SchedulerTasks { get; set; }

        public DbSet<Server> Servers { get; set; }
    }
}