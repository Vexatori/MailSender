﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender.Views
{
    /// <summary>
    /// Логика взаимодействия для RecipientEditor.xaml
    /// </summary>
    public partial class RecipientEditor : UserControl
    {
        public RecipientEditor() { InitializeComponent(); }

        private void Validation_OnError( object sender, ValidationErrorEventArgs e )
        {
            if ( !( sender is Control control) ) return;
            if ( e.Action == ValidationErrorEventAction.Added ) { control.ToolTip = e.Error.ErrorContent.ToString(); }
            else { control.ToolTip = null; }
        }
    }
}