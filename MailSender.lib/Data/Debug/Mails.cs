using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.Debug
{
    public class Mails : IMailsData
    {
        private ObservableCollection<Mail> _items = new ObservableCollection<Mail>();

        public ObservableCollection<Mail> Items => _items;

        public IEnumerable<Mail> GetAll() { return _items; }

        public Mail GetByTopic( string topic ) { return _items.FirstOrDefault( m => m.Topic == topic ); }

        public void AddNew( string topic, string text )
        {
            var newMail = new Mail() { Text = text, Topic = topic };
            if ( _items.Contains( newMail ) ) return;
            _items.Add( newMail );
        }

        public void AddNew( Mail newMail )
        {
            if ( _items.Contains( newMail ) ) return;
            _items.Add( newMail );
        }

        public void DeleteByTopic( string topic )
        {
            var mail = _items.FirstOrDefault( m => m.Topic == topic );
            if ( !_items.Contains( mail ) ) return;
            _items.Remove( mail );
        }

        public void SaveMail( string topic, string text )
        {
            var mail = _items.FirstOrDefault( m => m.Topic == topic );
            if ( _items.Contains( mail ) )
            {
                mail.Topic = topic;
                mail.Text = text;
            }
            else { AddNew( topic, text ); }
        }

        public void SaveMail( Mail changedMail )
        {
            var mail = _items.FirstOrDefault( m => m.Topic == changedMail.Topic );
            if ( _items.Contains( mail ) )
            {
                mail.Topic = changedMail.Topic;
                mail.Text = changedMail.Text;
            }
            else { AddNew( changedMail ); }
        }
    }

    public class Mail
    {
        public string Topic { get; set; }
        public string Text { get; set; }
    }
}