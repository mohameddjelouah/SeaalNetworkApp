using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.ViewModels
{
    public class SeccesDialogViewModel : Screen
    {
        private string _message = "Operation Effectué";

        public string Message
        {
            get { return _message; }
            set {
                _message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }

        public SeccesDialogViewModel()
        {

        }

        public void close()
        {
            TryClose();
        }
    }
}
