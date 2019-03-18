namespace MailSender.lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataRestrictions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Mails", "Topic", c => c.String(nullable: false));
            AlterColumn("dbo.Mails", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Recipients", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Servers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Servers", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.Servers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Senders", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Senders", "Address", c => c.String());
            AlterColumn("dbo.Servers", "Password", c => c.String());
            AlterColumn("dbo.Servers", "Login", c => c.String());
            AlterColumn("dbo.Servers", "Address", c => c.String());
            AlterColumn("dbo.Recipients", "Address", c => c.String());
            AlterColumn("dbo.Mails", "Text", c => c.String());
            AlterColumn("dbo.Mails", "Topic", c => c.String());
        }
    }
}
