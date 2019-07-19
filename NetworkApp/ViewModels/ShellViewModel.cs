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
       
        
        public ShellViewModel()
        {
            // i should put here a check code for auth users in the domain if they aren't auth
            // i will show a box plz auth ur not auth to the domain and close the application
            


            ActivateItem(IoC.Get<DashViewModel>());
          
            
           
        }

        public void dash()
        {
            // when i click it give me a new instance of dashboared 
            ActivateItem(IoC.Get<DashViewModel>());
            
        }
        public void inci()
        {
            // when i click it give me a new instance of incident datagridview 
            ActivateItem(IoC.Get<IncidentViewModel>());
        }
    }
}
