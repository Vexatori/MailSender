﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

using MailSender.Views;
using MailSender.Windows;

using Xceed.Wpf.Toolkit;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click( object sender, RoutedEventArgs e )
        {
            tcTabs.SelectedIndex = tcTabs.Items.IndexOf( tiScheduler );
        }

        private void TabChanger_OnLeft( object sender, EventArgs e )
        {
            if ( tcTabs.SelectedIndex > 0 )
            {
                tcTabs.SelectedIndex--;
            }
        }

        private void TabChanger_OnRight( object sender, EventArgs e )
        {
            if ( tcTabs.SelectedIndex < tcTabs.Items.Count )
            {
                tcTabs.SelectedIndex++;
            }
        }

        private void MenuItem_Click( object sender, RoutedEventArgs e )
        {
            this.Close();
        }

        private void BtnSendWithOwnParametrs_Click( object sender, RoutedEventArgs e )
        {
            SendWithOwnDataWindow sendWithOwnData = new SendWithOwnDataWindow();
            sendWithOwnData.ShowDialog();
        }
    }
}