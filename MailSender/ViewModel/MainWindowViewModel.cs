using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

using MailSender.lib.Data;
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
        private IServersData _serversData;

        public MainWindowViewModel( IRecipientsData recipientsData, IMailsData mailsData, IMailService mailService, IServersData serversData )
        {
            UpdateRecipientsCommand = new RelayCommand(OnUpdateRecipientsCommandExecuted, CanUpdateRecipientsCommandExecuted);

            _recipientsData = recipientsData;

            NewMailCommand = new RelayCommand(OnNewMailCommandExecuted, CanNewMailCommandExecuted);

            _mailsData = mailsData;

            _mailService = mailService;

            _serversData = serversData;

            foreach ( var mail in _mailsData.GetAll() )
            {
                MailsItems.Add( mail );
            }

            foreach ( var server in _serversData.GetAll() )
            {
                Servers.Add( server );
            }
        }

        public ObservableCollection<Server> Servers { get; } = new ObservableCollection<Server>();

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
            string topic = String.Empty;
            string text = String.Empty;

            if ( string.IsNullOrEmpty( _selectedMail.Topic ) )
            {
                var index = MailsItems.Count == 0 ? 0 : MailsItems.Count(m => Regex.IsMatch(m.Topic, @"^Mail( \d+)?$")) + 1;
                topic = index == 0 ? "Mail" : $"Mail {index}";
            }
            else
            {
                topic = _selectedMail.Topic;
            }

            if ( _selectedMail.Text == String.Empty ) { text = "Mail body"; }
            else { text = _selectedMail.Text; }

            var mail = new Mail() { Text = text, Topic = topic };
            _mailsData.AddNew( mail );
            MailsItems.Add( mail );
        }

        #endregion
    }
}