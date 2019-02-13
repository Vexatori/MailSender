using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.Debug
{
    public static class Mails
    {
        private static ObservableCollection<Mail> _items = new ObservableCollection<Mail>();

        public static ObservableCollection<Mail> Items => _items;

        public static Mail GetByTopic( string topic ) { return _items.FirstOrDefault( i => i.Topic == topic ); }

        public static void AddNew( Mail newMail )
        {
            if ( _items.Contains( newMail ) ) return;
            _items.Add( newMail );
        }

        public static void Delete( string topic )
        {
            var mail = GetByTopic( topic );
            if ( !_items.Contains( mail ) ) return;
            _items.Remove( mail );
        }

        public static void Save( Mail changedMail )
        {
            int id = _items.IndexOf( changedMail );
            _items.RemoveAt( id );
            _items.Insert( id, changedMail );
        }
    }

    public class Mail
    {
        public string Topic { get; set; }
        public string Text { get; set; }
    }
}