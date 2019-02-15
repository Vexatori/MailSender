using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

using MailSender.lib.Data.Debug;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Interfaces;
using MailSender.lib.MVVM;
using MailSender.UtilityClasses;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IRecipientsData _recipientsData;

        public ObservableCollection<Recipient> Recipients { get; } = new ObservableCollection<Recipient>();

        //private ObservableCollection<Recipient> _recipients;

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
            foreach ( var recipient in _recipientsData.GetAll() ) { Recipients.Add( recipient ); }
        }

        private Recipient _currentRecipient;

        public Recipient CurrentRecipient { get => _currentRecipient; set => Set( ref _currentRecipient, value ); }

        public ICommand SaveRecipientCommand { get; }

        public MainWindowViewModel( IRecipientsData recipientsData )
        {
            UpdateRecipientsCommand = new RelayCommand( OnUpdateRecipientsCommandExecuted, CanUpdateRecipientsCommandExecuted );

            _recipientsData = recipientsData;
        }
    }
}