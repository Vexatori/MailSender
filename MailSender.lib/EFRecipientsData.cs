using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MailSender.lib.Data;
using MailSender.lib.Data.Context;
using MailSender.lib.Interfaces;

namespace MailSender.lib
{
    public class EFRecipientsData : IRecipientsData
    {
        private MailDatabaseContext _db;

        public EFRecipientsData( MailDatabaseContext db ) => _db = db;

        public IEnumerable<Recipient> GetAll() => _db.Recipients.AsEnumerable();

        public async Task<IEnumerable<Recipient>> GetAllAsync()
        {
            await Task.Yield();
            return _db.Recipients.AsEnumerable();
        }

        public Recipient GetById( int id )
        {
            return _db.Recipients.FirstOrDefault( r => r.Id == id );
        }

        public Task<Recipient> GetByIdAsync( int id )
        {
            return _db.Recipients.FirstOrDefaultAsync( r => r.Id == id );
        }

        public void AddNew( Recipient newItem )
        {
            _db.Recipients.Add( newItem );
        }

        public async Task AddNewAsync( Recipient newItem )
        {
            await Task.Yield();
            _db.Recipients.Add( newItem );
        }

        public void DeleteById( int id )
        {
            var recipient = GetById( id );
            if ( recipient is null ) return;
            _db.Recipients.Remove( recipient );
        }

        public async Task DeleteByIdAsync( int id )
        {
            var recipient = await GetByIdAsync( id );
            if ( recipient is null ) return;
            _db.Recipients.Remove( recipient );
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}