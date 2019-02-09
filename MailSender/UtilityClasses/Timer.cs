using System;
using System.ComponentModel;
using System.Windows.Threading;
using GalaSoft.MvvmLight;

namespace MailSender.UtilityClasses
{
    public class Timer : ViewModelBase
    {
        private DateTime _now;

        public Timer()
        {
            _now = DateTime.Now;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        public DateTime Now
        {
            get => _now;
            private set => Set(ref _now, value);
        }

        void timer_Tick( object sender, EventArgs e )
        {
            Now = DateTime.Now;
        }
    }
}