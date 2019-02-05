using System;
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

            Timer.Init( txtblStatus );
        }

        private void Button_Click( object sender, RoutedEventArgs e )
        {
            tcTabs.SelectedIndex = 1;
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
    }
}