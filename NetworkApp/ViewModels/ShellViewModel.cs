using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace NetworkApp.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private DashViewModel _dashvm;
        public ShellViewModel(DashViewModel dashvm)
        {
            // i should put here a check code for auth users in the domain if they aren't auth
            // i will show a box plz auth ur not auth to the domain and close the application
                _dashvm = dashvm;
                ActivateItem(_dashvm);
          
            
           
        }
    }
}
