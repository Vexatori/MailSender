using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MailSender.lib.Data.Debug;
using MailSender.lib.Interfaces;

namespace MailSender.lib
{
    public class InMemoryMailsData : IMailsData
    {
        public IEnumerable<Mail> GetAll() => Mails.Items;

        public Mail GetById( int id ) { return Mails.Items.FirstOrDefault( m => m.Id == id ); }

        public void AddNew( Mail newMail )
        {
            if ( Mails.Items.Contains( newMail ) ) return;
            if ( Mails.Items.Count == 0 )
            {
                newMail.Id = 1;
                Mails.Items.Add( newMail );
            }
            else
            {
                newMail.Id = Mails.Items.Max( m => m.Id ) + 1;
                Mails.Items.Add( newMail );
            }
        }

        public void DeleteById( int id )
        {
            var mailItem = GetById( id );
            if ( !Mails.Items.Contains( mailItem ) ) return;
            Mails.Items.Remove( mailItem );
        }

        public void Save( Mail changedMail )
        {
            var mail = Mails.Items.FirstOrDefault( m => m.Id == changedMail.Id );
            if ( Mails.Items.Contains( mail ) )
            {
                mail.Id = changedMail.Id;
                mail.Topic = changedMail.Topic;
                mail.Text = changedMail.Text;
            }
            else { AddNew( changedMail ); }
        }
    }
}