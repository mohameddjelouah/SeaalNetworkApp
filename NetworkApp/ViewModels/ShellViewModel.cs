﻿using System;
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

        private bool _isListDesSiteSelected = false;

        public bool isListDesSiteSelected
        {
            get { return _isListDesSiteSelected; }
            set
            {

                _isListDesSiteSelected = value;
                NotifyOfPropertyChange(() => isListDesSiteSelected);

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



        private bool _expendListDesSite = false;

        public bool ExpendListDesSite
        {
            get { return _expendListDesSite; }
            set { 
                _expendListDesSite = value;
                NotifyOfPropertyChange(() => ExpendListDesSite);
            
            }
        }


        private bool _isDisplayListDesSiteSelected = false;

        public bool isDisplayListDesSiteSelected
        {
            get { return _isDisplayListDesSiteSelected; }
            set
            {
                _isDisplayListDesSiteSelected = value;
                NotifyOfPropertyChange(() => isDisplayListDesSiteSelected);

            }
        }



        private bool _isAddSiteSelected = false;

        public bool isAddSiteSelected
        {
            get { return _isAddSiteSelected; }
            set
            {
                _isAddSiteSelected = value;
                NotifyOfPropertyChange(() => isAddSiteSelected);

            }
        }

        public void Handle(AddIncidentEvent message)
        {
            SelectItem("Incident", "AddIncident");
            ActivateItem(IoC.Get<AddIncidentViewModel>());
            
        }

        public void Handle(AddInterventionEvent message)
        {
            SelectItem("Intervention", "AddIntervention");
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



        public void ListDesSite()
        {
            SelectItem("ListDesSite", "DisplayListDesSite");
            ActivateItem(IoC.Get<ListDesSiteViewModel>());


        }

        public void AddSite()
        {
            SelectItem("ListDesSite", "DisplayAddSite");
            ActivateItem(IoC.Get<AddSiteViewModel>());
        }


        public void ResetSelected()
        {
           
           
            isDashSelected = false;
            isIncidentSelected = false;
            isInterventionSelected = false;
            isListDesSiteSelected = false;
           
        }

        
        
        
        public void SelectItem(string name,string SubItem)
        {
            switch (name)
            {
                case "Dashboard":

                    isIncidentSelected = false;
                    isInterventionSelected = false;
                    isListDesSiteSelected = false;
                    ExpendIncident = false;
                    ExpendIntervention = false;
                    ExpendListDesSite = false;
                    isDashSelected = true;
                    SelectSubItem(SubItem);
                    break;

                case "Incident":
                    
                    isInterventionSelected = false;
                    isListDesSiteSelected = false;
                    isDashSelected = false;
                    ExpendIntervention = false;
                    ExpendListDesSite = false;
                    isIncidentSelected = true;
                    SelectSubItem(SubItem);
                    break;

                case "Intervention":


                    isListDesSiteSelected = false;
                    isDashSelected = false;
                    isIncidentSelected = false;                
                    ExpendIncident = false;
                    ExpendListDesSite = false;
                    isInterventionSelected = true;
                    SelectSubItem(SubItem);
                    break;

               

                case "ListDesSite":


                    
                    isDashSelected = false;
                    isIncidentSelected = false;
                    isInterventionSelected = false;
                    ExpendIncident = false;
                    ExpendIntervention = false;
                    isListDesSiteSelected = true;
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
                    isDisplayListDesSiteSelected = false;
                    isAddSiteSelected = false;

                    break;

                case "DisplayIncident":

                    isAddIncidentSelected = false;
                    isClotureIncidentSelected = false;        
                    isAddInterventionSelected = false;
                    isDisplayInterventionSelected = false;
                    isDisplayListDesSiteSelected = false;
                    isAddSiteSelected = false;
                    isDisplayIncidentSelected = true;

                    break;


                case "ClotureIncident":

                    isAddIncidentSelected = false;           
                    isDisplayIncidentSelected = false;
                    isAddInterventionSelected = false;
                    isDisplayInterventionSelected = false;
                    isDisplayListDesSiteSelected = false;
                    isAddSiteSelected = false;
                    isClotureIncidentSelected = true;

                    break;


                case "AddIncident":

                    
                    isClotureIncidentSelected = false;
                    isDisplayIncidentSelected = false;
                    isAddInterventionSelected = false;
                    isDisplayInterventionSelected = false;
                    isDisplayListDesSiteSelected = false;
                    isAddSiteSelected = false;
                    isAddIncidentSelected = true;

                    break;



                case "DisplayIntervention":

                    isAddIncidentSelected = false;
                    isClotureIncidentSelected = false;
                    isDisplayIncidentSelected = false;
                    isAddInterventionSelected = false;
                    isDisplayListDesSiteSelected = false;
                    isAddSiteSelected = false;
                    isDisplayInterventionSelected = true;

                    break;

                case "AddIntervention":

                    isAddIncidentSelected = false;
                    isClotureIncidentSelected = false;
                    isDisplayIncidentSelected = false; 
                    isDisplayInterventionSelected = false;
                    isDisplayListDesSiteSelected = false;
                    isAddSiteSelected = false;
                    isAddInterventionSelected = true;

                    break;

                case "DisplayListDesSite":

                    isAddIncidentSelected = false;
                    isClotureIncidentSelected = false;
                    isDisplayIncidentSelected = false;
                    isDisplayInterventionSelected = false;
                    isAddSiteSelected = false;
                    isAddInterventionSelected = false;
                    isDisplayListDesSiteSelected = true;

                    break;

                case "DisplayAddSite":

                    isAddIncidentSelected = false;
                    isClotureIncidentSelected = false;
                    isDisplayIncidentSelected = false;
                    isDisplayInterventionSelected = false;
                    isDisplayListDesSiteSelected = false;
                    isAddInterventionSelected = false;
                    isAddSiteSelected = true;

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
