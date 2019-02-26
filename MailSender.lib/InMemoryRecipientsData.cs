using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Interfaces;

namespace MailSender.lib
{
    public class InMemoryRecipientsData : IRecipientsData
    {
        private readonly List<Recipient> _recipients = new List<Recipient>
        {
                new Recipient { Id = 0, Name = "Иванов", Address = "ivanov@yandex.ru" },
                new Recipient { Id = 1, Name = "Петров", Address = "petrov@yandex.ru" },
                new Recipient { Id = 2, Name = "Сидоров", Address = "sidorov@yandex.ru" },
        };

        public IEnumerable<Recipient> GetAll()
        {
            return _recipients;
        }

        public Task<IEnumerable<Recipient>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Recipient GetById( int id )
        {
            return _recipients.FirstOrDefault( r => r.Id == id );
        }

        public Task<Recipient> GetByIdAsync( int id )
        {
            throw new NotImplementedException();
        }

        public void AddNew( Recipient newRecipient )
        {
            if ( _recipients.Contains( newRecipient ) ) return;
            newRecipient.Id = _recipients.Max( r => r.Id ) + 1;
            _recipients.Add( newRecipient );
        }

        public Task AddNewAsync( Recipient newItem )
        {
            throw new NotImplementedException();
        }

        public void DeleteById( int id )
        {
            var recipient = GetById( id );
            if ( recipient == null ) return;
            _recipients.Remove( recipient );
        }

        public Task DeleteByIdAsync( int id )
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {

        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}