using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace MailSender.UtilityClasses
{
    public class Timer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime _now;

        public Timer()
        {
            _now = DateTime.Now;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan( 0, 0, 1 );
            timer.Tick += new EventHandler( timer_Tick );
            timer.Start();
        }

        public DateTime Now
        {
            get => _now;
            private set
            {
                _now = value;
                if ( PropertyChanged != null )
                    PropertyChanged( this, new PropertyChangedEventArgs( "Now" ) );
            }
        }

        void timer_Tick( object sender, EventArgs e )
        {
            Now = DateTime.Now;
        }
    }
}