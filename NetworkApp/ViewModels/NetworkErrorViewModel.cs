using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.ViewModels
{
    public class NetworkErrorViewModel : Screen
    {

        public NetworkErrorViewModel()
        {

        }

        public void ExitApplication()
        {
            TryClose(false);
        }

        public void retry()
        {
            TryClose(true);
        }
    }
}
