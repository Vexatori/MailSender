using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using MailSender.lib.Data.Debug;

namespace MailSender.Windows
{
    /// <summary>
    /// Логика взаимодействия для SendWithOwnDataWindow.xaml
    /// </summary>
    public partial class SendWithOwnDataWindow : Window
    {
        public SendWithOwnDataWindow() { InitializeComponent(); }

        private void BtnCancel_Click( object sender, RoutedEventArgs e ) { this.Close(); }

        //private void BtnSend_Click( object sender, RoutedEventArgs e )
        //{
        //    string senderMail = tbxLogin.Text + ( cbSenderSMTP.SelectedItem as Server ).MailAddress;
        //    string recipientMail = tbxRecipient.Text + ( cbRecipientSMTP.SelectedItem as Server ).MailAddress;
        //    EmailSendServiceClass.GetMailProperties( tbxMailTopic.Text, 
        //                                             tbxMailText.Text, 
        //                                             recipientMail, 
        //                                             senderMail, 
        //                                             ( cbSenderSMTP.SelectedItem as Server ).Port, 
        //                                             ( cbSenderSMTP.SelectedItem as Server ).Address, 
        //                                             pbPassword.SecurePassword );

        //    try
        //    {
        //        EmailSendServiceClass.SendMail();
        //        MessageBox.Show( "Письмо отправлено" );
        //    }
        //    catch(Exception exc) { MessageBox.Show( "Письмо не отправлено" ); }
        //}
    }
}