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
    public class EFServersData : IServersData
    {
        private readonly MailDatabaseContext _db;

        public EFServersData( MailDatabaseContext db ) => _db = db;

        public IEnumerable<Server> GetAll() => _db.Servers.AsEnumerable();

        public async Task<IEnumerable<Server>> GetAllAsync()
        {
            await Task.Yield();
            return _db.Servers.AsEnumerable();
        }

        public Server GetById( int id )
        {
            return _db.Servers.FirstOrDefault( server => server.Id == id );
        }

        public Task<Server> GetByIdAsync( int id )
        {
            return _db.Servers.FirstOrDefaultAsync( server => server.Id == id );
        }

        public void AddNew( Server newItem )
        {
            _db.Servers.Add( newItem );
        }

        public async Task AddNewAsync( Server newItem )
        {
            await Task.Yield();
            _db.Servers.Add( newItem );
        }

        public void DeleteById( int id )
        {
            var item = GetById( id );
            if ( item is null ) return;
            _db.Servers.Remove( item );
        }

        public async Task DeleteByIdAsync( int id )
        {
            var item = await GetByIdAsync( id );
            if ( item is null ) return;
            _db.Servers.Remove( item );
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