using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using NetworkApp.EventModels;

namespace NetworkApp.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<AddIncidentEvent>
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

        private IEventAggregator _events;
        public ShellViewModel(IEventAggregator events)
        {

            _events = events;
            _events.Subscribe(this);


            ActivateItem(IoC.Get<DashViewModel>());
          
            
           
        }


        private bool _isDashSelected = true;

        public bool isDashSelected
        {
            get { return _isDashSelected; }
            set {

               

                _isDashSelected = value;
                NotifyOfPropertyChange(() => isDashSelected);

            }
        }


        private bool _isIncidentSelected = false;

        public bool isIncidentSelected
        {
            get { return _isIncidentSelected; }
            set
            {

               
                _isIncidentSelected = value;
                NotifyOfPropertyChange(() => isIncidentSelected);

            }
        }

        private bool _isInterventionSelected = false;

        public bool isInterventionSelected
        {
            get { return _isInterventionSelected; }
            set
            {
               
                _isInterventionSelected = value;
                NotifyOfPropertyChange(() => isInterventionSelected);

            }
        }

        private bool _isStatSelected = false;

        public bool isStatSelected
        {
            get { return _isStatSelected; }
            set
            {
                
                _isStatSelected = value;
                NotifyOfPropertyChange(() => isStatSelected);

            }
        }



        public void Handle(AddIncidentEvent message)
        {
            ActivateItem(IoC.Get<AddIncidentViewModel>());
        }


        public void DisplayDashboard()
        {
            // when i click it give me a new instance of dashboared 
            ActivateItem(IoC.Get<DashViewModel>());
            
        }
        public void DisplayAllIncidents()
        {

            ResetSelected();
            isIncidentSelected = true;
            // when i click it give me a new instance of incident datagridview 
            ActivateItem(IoC.Get<IncidentViewModel>());
        }

        public void AddIncidents()
        {
            ResetSelected();
            isIncidentSelected = true;
            ActivateItem(IoC.Get<AddIncidentViewModel>());
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
        public void DisplayAllInterventions()
        {
            ResetSelected();
            isInterventionSelected = true;

        }


        public void AddInterventions()
        {
            ResetSelected();
            isInterventionSelected = true;

        }



        public void Stats()
        {

        }
        public void ResetSelected()
        {
            isDashSelected = false;
            isIncidentSelected = false;
            isInterventionSelected = false;
            isStatSelected = false;
           
        }
        
    }
}
