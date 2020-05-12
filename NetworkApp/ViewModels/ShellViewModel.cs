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
    public class ShellViewModel : Conductor<object>, IHandle<AddIncidentEvent>,IHandle<AddInterventionEvent>
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

        private bool _isDisplayIncidentSelected = false;

        public bool isDisplayIncidentSelected
        {
            get { return _isDisplayIncidentSelected; }
            set { 
                _isDisplayIncidentSelected = value;
                NotifyOfPropertyChange(() => isDisplayIncidentSelected);

            }
        }

        private bool _isClotureIncidentSelected = false;

        public bool isClotureIncidentSelected
        {
            get { return _isClotureIncidentSelected; }
            set { 
                _isClotureIncidentSelected = value;
                NotifyOfPropertyChange(() => isClotureIncidentSelected);

            }
        }

        private bool _isAddIncidentSelected = false;

        public bool isAddIncidentSelected
        {
            get { return _isAddIncidentSelected; }
            set { 
                _isAddIncidentSelected = value;
                NotifyOfPropertyChange(() => isAddIncidentSelected);

            }
        }


        private bool _isDisplayInterventionSelected = false;

        public bool isDisplayInterventionSelected
        {
            get { return _isDisplayInterventionSelected; }
            set { 
                _isDisplayInterventionSelected = value;
                NotifyOfPropertyChange(() => isDisplayInterventionSelected);

            }
        }


        private bool _isAddInterventionSelected = false;

        public bool isAddInterventionSelected
        {
            get { return _isAddInterventionSelected; }
            set { 
                _isAddInterventionSelected = value;
                NotifyOfPropertyChange(() => isAddInterventionSelected);

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

        public void Handle(AddInterventionEvent message)
        {
            ActivateItem(IoC.Get<AddInterventionViewModel>());

        }




        public void DisplayDashboard()
        {

            SelectItem("Dashboard", "ResetAll");
            ActivateItem(IoC.Get<DashViewModel>());
            

        }
        public void DisplayAllIncidents()
        {
            SelectItem("Incident", "DisplayIncident");
            ActivateItem(IoC.Get<IncidentViewModel>());
        }

        public void DisplayClotureIncidents()
        {
            SelectItem("Incident", "ClotureIncident");   
            ActivateItem(IoC.Get<ClotureViewModel>());
        }

        public void AddIncidents()
        {
            SelectItem("Incident", "AddIncident");
            ActivateItem(IoC.Get<AddIncidentViewModel>());
        }


        

        

        public void DisplayAllInterventions()
        {
            SelectItem("Intervention", "DisplayIntervention");
            ActivateItem(IoC.Get<InterventionViewModel>());
            
        }



        public void AddInterventions()
        {
            
            SelectItem("Intervention", "AddIntervention");
            ActivateItem(IoC.Get<AddInterventionViewModel>());

        }



        public void Stats()
        {
            SelectItem("Stat", "ResetAll");

        }

        public void ResetSelected()
        {
           
           
            isDashSelected = false;
            isIncidentSelected = false;
            isInterventionSelected = false;
            isStatSelected = false;
           
        }

        
        
        
        public void SelectItem(string name,string SubItem)
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
                    SelectSubItem(SubItem);
                    break;

                case "Incident":
                    
                    isInterventionSelected = false;
                    isStatSelected = false;
                    isDashSelected = false;
                    ExpendIntervention = false;
                    isIncidentSelected = true;
                    SelectSubItem(SubItem);
                    break;

                case "Intervention":

                    
                    isStatSelected = false;
                    isDashSelected = false;
                    isIncidentSelected = false;                
                    ExpendIncident = false; 
                    isInterventionSelected = true;
                    SelectSubItem(SubItem);
                    break;

                case "Stat":


                    
                    isDashSelected = false;
                    isIncidentSelected = false;
                    isInterventionSelected = false;
                    ExpendIncident = false;
                    ExpendIntervention = false;
                    isStatSelected = true;
                    SelectSubItem(SubItem);
                    break;


            }
            
            

        }

        public void SelectSubItem(string action)
        {
            switch (action)
            {
                case "ResetAll":

                    isAddIncidentSelected = false;
                    isClotureIncidentSelected = false;
                    isDisplayIncidentSelected = false;
                    isAddInterventionSelected = false;
                    isDisplayInterventionSelected = false;

                    break;

                case "DisplayIncident":

                    isAddIncidentSelected = false;
                    isClotureIncidentSelected = false;        
                    isAddInterventionSelected = false;
                    isDisplayInterventionSelected = false;
                    isDisplayIncidentSelected = true;

                    break;


                case "ClotureIncident":

                    isAddIncidentSelected = false;           
                    isDisplayIncidentSelected = false;
                    isAddInterventionSelected = false;
                    isDisplayInterventionSelected = false;
                    isClotureIncidentSelected = true;

                    break;


                case "AddIncident":

                    
                    isClotureIncidentSelected = false;
                    isDisplayIncidentSelected = false;
                    isAddInterventionSelected = false;
                    isDisplayInterventionSelected = false;
                    isAddIncidentSelected = true;

                    break;



                case "DisplayIntervention":

                    isAddIncidentSelected = false;
                    isClotureIncidentSelected = false;
                    isDisplayIncidentSelected = false;
                    isAddInterventionSelected = false;
                    isDisplayInterventionSelected = true;

                    break;

                case "AddIntervention":

                    isAddIncidentSelected = false;
                    isClotureIncidentSelected = false;
                    isDisplayIncidentSelected = false; 
                    isDisplayInterventionSelected = false;
                    isAddInterventionSelected = true;

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
