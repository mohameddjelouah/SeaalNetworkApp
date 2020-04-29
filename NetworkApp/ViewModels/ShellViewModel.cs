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

        private bool _expendIncident =false;

        public bool ExpendIncident
        {
            get { return _expendIncident; }
            set { 
                _expendIncident = value;
                NotifyOfPropertyChange(() => ExpendIncident);
            }
        }

        private bool _expendIntervention =false;

        public bool ExpendIntervention
        {
            get { return _expendIntervention; }
            set
            {
                _expendIntervention = value;
                NotifyOfPropertyChange(() => ExpendIntervention);
            }
        }


        public void Handle(AddIncidentEvent message)
        {
            ActivateItem(IoC.Get<AddIncidentViewModel>());
            
        }


       



        public void DisplayDashboard()
        {

            SelectItem("Dashboard");
            //ExpendIntervention = false;
            //ExpendIncident = false;
            //// when i click it give me a new instance of dashboared 
            ActivateItem(IoC.Get<DashViewModel>());
            

        }
        public void DisplayAllIncidents()
        {
            SelectItem("Incident");
            //ResetSelected();
            //isIncidentSelected = true;
            //ExpendIntervention = false;
            //// when i click it give me a new instance of incident datagridview 
            ActivateItem(IoC.Get<IncidentViewModel>());
        }

        public void AddIncidents()
        {
            SelectItem("Incident");
            //ResetSelected();
            //isIncidentSelected = true;
            //ExpendIntervention = false;
            ActivateItem(IoC.Get<AddIncidentViewModel>());
        }


        

        public void DisplayClotureIncidents()
        {
            SelectItem("Incident");
            //ResetSelected();
            //isIncidentSelected = true;
            //ExpendIntervention = false;
            //// when i click it give me a new instance of incident datagridview 
            ActivateItem(IoC.Get<ClotureViewModel>());
        }

        public void DisplayAllInterventions()
        {
            SelectItem("Intervention");
            //ResetSelected();
            //isInterventionSelected = true;
            //ExpendIncident = false;
            ActivateItem(IoC.Get<InterventionViewModel>());
            
        }



        public void AddInterventions()
        {
            SelectItem("Intervention");
            //ResetSelected();
            //isInterventionSelected = true;
            //ExpendIncident = false;
            ActivateItem(IoC.Get<AddInterventionViewModel>());

        }



        public void Stats()
        {
            SelectItem("Stat");
            //ExpendIncident = false;
            //ExpendIntervention = false;



        }

        public void ResetSelected()
        {
           
           
            isDashSelected = false;
            isIncidentSelected = false;
            isInterventionSelected = false;
            isStatSelected = false;
           
        }

        
        
        
        public void SelectItem(string name)
        {
            switch (name)
            {
                case "Dashboard":

                    isIncidentSelected = false;
                    isInterventionSelected = false;
                    isStatSelected = false;
                    ExpendIncident = false;
                    ExpendIntervention = false;
                    isDashSelected = true;
                    break;

                case "Incident":
                    
                    isInterventionSelected = false;
                    isStatSelected = false;
                    isDashSelected = false;
                    ExpendIntervention = false;
                    isIncidentSelected = true;
                    
                    break;

                case "Intervention":

                    
                    isStatSelected = false;
                    isDashSelected = false;
                    isIncidentSelected = false;                
                    ExpendIncident = false; 
                    isInterventionSelected = true;

                    break;

                case "Stat":


                    
                    isDashSelected = false;
                    isIncidentSelected = false;
                    isInterventionSelected = false;
                    ExpendIncident = false;
                    ExpendIntervention = false;
                    isStatSelected = true;
                    break;


            }
            
            

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
