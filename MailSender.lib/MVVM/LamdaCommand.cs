using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MailSender.lib.MVVM
{
    public class LamdaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private readonly Action<object> _onExecute;
        private readonly Func<object, bool> _canExecute;

        public LamdaCommand( Action<object> OnExecute, Func<object, bool> CanExecute = null )
        {
            _onExecute = OnExecute;
            _canExecute = CanExecute;
        }

        public bool CanExecute( object parameter )
        {
            return _canExecute?.Invoke( parameter ) ?? true;
        }

        public void Execute( object parameter )
        {
            _onExecute( parameter );
        }

        private readonly Action<object, object> _onExecuteMail;
        private readonly Func<object, object, bool> _canExecuteMail;

        public LamdaCommand( Action<object, object> OnExecute, Func<object, object, bool> CanExecute = null )
        {
            _onExecuteMail = OnExecute;
            _canExecuteMail = CanExecute;
        }

        public bool CanExecuteMail( object parametr1, object parametr2 ) { return _canExecuteMail?.Invoke( parametr1, parametr2 ) ?? true; }

        public void Execute( object parametr1, object parametr2 ) { _onExecuteMail( parametr1, parametr2 ); }
    }
}
