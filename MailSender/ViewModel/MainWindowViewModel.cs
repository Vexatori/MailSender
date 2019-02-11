using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Interfaces;
using MailSender.UtilityClasses;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IRecipientsData _recipientsData;

        //private ObservableCollection<Recipient> _recipients;

        private string _Title = "Рассыльщик почты";

        public string Title
        {
            get => _Title;
            set => Set( ref _Title, value );
        }

        private string _Status = "К спаму готов";

        public string Status
        {
            get => _Status;
            set => Set( ref _Status, value );
        }

        public DateTime StatusTime
        {
            get => new Timer().Now;
        }

        public ObservableCollection<Recipient> Recipients { get; } = new ObservableCollection<Recipient>();

        //public ObservableCollection<Recipient> Recipients
        //{
        //    get
        //    {
        //        if ( _recipients != null ) return _recipients;
        //        _recipients = new ObservableCollection<Recipient>(_recipientsData.GetAll());
        //        return _recipients;
        //    }
        //}

        public MainWindowViewModel( IRecipientsData recipientsData )
        {
            _recipientsData = recipientsData;
        }
    }
}