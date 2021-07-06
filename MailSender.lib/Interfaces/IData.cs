using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Interfaces
{
    public interface IData<T>
    {
        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        T GetById( int id );

        Task<T> GetByIdAsync( int id );

        void AddNew( T newItem );

        Task AddNewAsync( T newItem );

        void DeleteById( int id );

        Task DeleteByIdAsync( int id );

        void SaveChanges(  );

        Task SaveChangesAsync();
    }
}
