using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
        private IMailService _mailService;
        private IMailsData _mailsData;

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

        public MainWindowViewModel( IRecipientsData recipientsData, IMailsData mailsData, IMailService mailService )
        {
            UpdateRecipientsCommand = new RelayCommand(OnUpdateRecipientsCommandExecuted, CanUpdateRecipientsCommandExecuted);

            _recipientsData = recipientsData;

            NewMailCommand = new RelayCommand(OnNewMailCommandExecuted, CanNewMailCommandExecuted);

            _mailsData = mailsData;

            _mailService = mailService;
        }

        #region RecipientsCode

        public ObservableCollection<Recipient> Recipients { get; } = new ObservableCollection<Recipient>();

        public ICommand UpdateRecipientsCommand { get; }

        private bool CanUpdateRecipientsCommandExecuted() => true;

        private void OnUpdateRecipientsCommandExecuted()
        {
            Recipients.Clear();
            foreach(var recipient in _recipientsData.GetAll()) { Recipients.Add(recipient); }
        }

        private Recipient _currentRecipient;

        public Recipient CurrentRecipient { get => _currentRecipient; set => Set(ref _currentRecipient, value); }

        public ICommand SaveRecipientCommand { get; }

        #endregion



        #region MailsCode

        public ObservableCollection<Mail> MailsItems { get; } = new ObservableCollection<Mail>();

        private Mail _selectedMail = new Mail();

        public Mail SelectedMail
        {
            get => _selectedMail;
            set => Set(ref _selectedMail, value);
        }

        public ICommand NewMailCommand { get; }

        private bool CanNewMailCommandExecuted() => true;

        private void OnNewMailCommandExecuted()
        {
            string topic = _selectedMail.Topic;
            string text = _selectedMail.Text;
            var mail = new Mail() { Text = text, Topic = topic };
            _mailsData.AddNew(mail);
            MailsItems.Add(mail);
        }

        #endregion
    }
}