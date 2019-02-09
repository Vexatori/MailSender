using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.MVVM;

namespace MailSender.ViewModels
{
    public class TestViewModel : ViewModel
    {
        private string _text = "TestValue";

        public string Text
        {
            get => _text;
            set => Set(ref _text, value);
        }
    }
}
