using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MailSender
{
    public static class Timer
    {
        private static TextBlock time;

        public static void Init(TextBlock txt)
        {
            time = txt;
            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private static void dispatcherTimer_Tick( object sender, EventArgs e )
        {
            time.Text = $"{DateTime.Now}";
        }
    }
}
