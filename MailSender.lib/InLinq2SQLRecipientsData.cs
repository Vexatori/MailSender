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

        public async Task AddNewAsync( Recipient newItem )
        {
            throw new NotImplementedException();
        }

        public void DeleteById( int id )
        {
            var recipient = GetById( id );
            if ( recipient == null ) return;
            _database.Recipient.DeleteOnSubmit( recipient );
        }

        public async Task DeleteByIdAsync( int id )
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _database.SubmitChanges();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipient> GetAll()
        {
            return _database.Recipient.AsEnumerable();
        }

        public Task<IEnumerable<Recipient>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Recipient GetById( int id )
        {
            return _database.Recipient.FirstOrDefault( r => r.Id == id );
        }

        public Task<Recipient> GetByIdAsync( int id )
        {
            throw new NotImplementedException();
        }
    }
}