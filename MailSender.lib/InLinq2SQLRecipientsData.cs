using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Interfaces;

namespace MailSender.lib
{
    public class InLinq2SQLRecipientsData : IRecipientsData
    {
        private MailDatabaseContext _database;

        public InLinq2SQLRecipientsData( MailDatabaseContext databaseContext )
        {
            _database = databaseContext;
        }

        public void AddNew( Recipient newRecipient )
        {
            newRecipient.Id = _database.Recipient.Max( r => r.Id ) + 1;
            _database.Recipient.InsertOnSubmit( newRecipient );
        }

        public void DeleteById( int id )
        {
            var recipient = GetById( id );
            if ( recipient == null ) return;
            _database.Recipient.DeleteOnSubmit( recipient );
        }

        public IEnumerable<Recipient> GetAll()
        {
            return _database.Recipient.AsEnumerable();
        }

        public Recipient GetById( int id )
        {
            return _database.Recipient.FirstOrDefault( r => r.Id == id );
        }

        public void Save()
        {
            _database.SubmitChanges();
        }
    }
}