using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.ViewModels
{
    public class FaildDialogViewModel : Screen
    {
        private string _message = "Operation Faild";

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }

        public FaildDialogViewModel()
        {

        }

        public void close()
        {
            TryClose();
        }
    }
}
