using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MailSender.lib.Data.Debug;

namespace MailSender.lib.Interfaces
{
    public interface IMailsData
    {
        IEnumerable<Mail> GetAll();

        Mail GetByTopic( string topic );

        void AddNew( string topic, string text );

        void AddNew( Mail newMail );

        void DeleteByTopic( string topic );

        void SaveMail( string topic, string text );

        void SaveMail( Mail changedMail );
    }
}
