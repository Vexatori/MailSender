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

        T GetById( int id );

        void AddNew( T newItem );

        void DeleteById( int id );

        //void Save( T changedItem );
    }
}
