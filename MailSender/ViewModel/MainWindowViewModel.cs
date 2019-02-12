using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Interfaces;
using MailSender.lib.MVVM;
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

        public ICommand UpdateRecipientsCommand { get; }

        private bool CanUpdateRecipientsCommandExecuted() => true;

        private void OnUpdateRecipientsCommandExecuted()
        {
            Recipients.Clear();
            foreach ( var recipient in _recipientsData.GetAll() )
            {
                Recipients.Add( recipient );
            }
        }

        public MainWindowViewModel( IRecipientsData recipientsData )
        {
            UpdateRecipientsCommand = new RelayCommand(OnUpdateRecipientsCommandExecuted, CanUpdateRecipientsCommandExecuted);

            _recipientsData = recipientsData;
        }
    }
}