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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender.Controls
{
    /// <summary>
    /// Логика взаимодействия для TabChanger.xaml
    /// </summary>
    public partial class TabChanger : UserControl
    {
        public event EventHandler Left;

        public event EventHandler Right;

        public TabChanger()
        {
            InitializeComponent();
        }

        private void BtnLeft_Click( object sender, RoutedEventArgs e )
        {
            Left?.Invoke( this, EventArgs.Empty );
        }

        private void BtnRight_Click( object sender, RoutedEventArgs e )
        {
            Right?.Invoke(this, EventArgs.Empty);
        }
    }
}
