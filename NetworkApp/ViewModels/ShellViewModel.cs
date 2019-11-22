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
        private bool _resizeApp;

        public bool ResizeApp
        {
            get { return _resizeApp; }
            set {

                _resizeApp = value;
                NotifyOfPropertyChange(() => ResizeApp);
                
            }
        }


        public ShellViewModel()
        {
           
            


            ActivateItem(IoC.Get<DashViewModel>());
          
            
           
        }

        public void DisplayDashboard()
        {
            // when i click it give me a new instance of dashboared 
            ActivateItem(IoC.Get<DashViewModel>());
            
        }
        public void DisplayAllIncidents()
        {
            // when i click it give me a new instance of incident datagridview 
            ActivateItem(IoC.Get<IncidentViewModel>());
        }
       
        public void ExitApplication()
        {
            TryClose();
           
        }
         
        public void MinApplication()
        {
            App.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
        }
        public void MaxResApplication()
        {
            if (ResizeApp == true)
            {
                App.Current.MainWindow.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                App.Current.MainWindow.WindowState = System.Windows.WindowState.Normal;
            }
            
        }
        public void MinMax()
        {
            if (App.Current.MainWindow.WindowState == System.Windows.WindowState.Normal)
            {
                App.Current.MainWindow.WindowState = System.Windows.WindowState.Maximized;
                ResizeApp = true;
            }
            else
            {
                App.Current.MainWindow.WindowState = System.Windows.WindowState.Normal;
                ResizeApp = false;
               
            }
        }
        
    }
}
