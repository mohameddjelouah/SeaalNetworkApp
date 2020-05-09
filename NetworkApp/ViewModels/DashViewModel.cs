using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using NetworkApp.Library.Api;
using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models;
using NetworkApp.Library.Models.DashbordModels;

namespace NetworkApp.ViewModels
{
    public class DashViewModel : Screen
    {
        private ObservableCollection<IncidentChartModel> _incidentChart;

        public ObservableCollection<IncidentChartModel> IncidentChart
        {
            get { return _incidentChart; }
            set { 
                _incidentChart = value;
                NotifyOfPropertyChange(() => IncidentChart);
            }
        }


        private ObservableCollection<InterventionChartModel> _interventionChart;

        public ObservableCollection<InterventionChartModel> InterventionChart
        {
            get { return _interventionChart; }
            set
            {
                _interventionChart = value;
                NotifyOfPropertyChange(() => InterventionChart);
            }
        }


        private ObservableCollection<Last4WeeksChartModel> _last4WeeksIncidentChart;

        public ObservableCollection<Last4WeeksChartModel> Last4WeeksIncidentChart
        {
            get { return _last4WeeksIncidentChart; }
            set {
                _last4WeeksIncidentChart = value;
                NotifyOfPropertyChange(() => Last4WeeksIncidentChart);
            }
        }


        private ObservableCollection<Last4WeeksInterventionChartModel> _last4WeeksInterventionChart;

        public ObservableCollection<Last4WeeksInterventionChartModel> Last4WeeksInterventionChart
        {
            get { return _last4WeeksInterventionChart; }
            set
            {
                _last4WeeksInterventionChart = value;
                NotifyOfPropertyChange(() => Last4WeeksInterventionChart);
            }
        }


        private DashboardModel _dash;

        public DashboardModel Dash
        {
            get { return _dash; }
            set {
                _dash = value;
                NotifyOfPropertyChange(() => Dash);
            }
        }

        //**************************************************************************************************************
        private bool _form = false;

        public bool Form
        {
            get { return _form; }
            set
            {
                _form = value;
                NotifyOfPropertyChange(() => Form);
            }
        }

        //**************************************************************************************************************
        private bool _dataBaseError = false;

        public bool DataBaseError
        {
            get { return _dataBaseError; }
            set
            {
                _dataBaseError = value;
                NotifyOfPropertyChange(() => DataBaseError);

            }
        }

        //**************************************************************************************************************

        //**************************************************************************************************************
        private bool _prog = true;

        public bool Prog
        {
            get { return _prog; }
            set
            {
                _prog = value;
                NotifyOfPropertyChange(() => Prog);

            }
        }
        //**************************************************************************************************************

        private bool _transition = false;

        public bool Transition
        {
            get { return _transition; }
            set
            {
                _transition = value;
                NotifyOfPropertyChange(() => Transition);

            }
        }
        //**************************************************************************************************************

        private IDashboardEndPoint _dashboardEndPoint;
        private IWindowManager _window;
        public DashViewModel(IDashboardEndPoint dashboardEndPoint, IWindowManager window)
        {
            _dashboardEndPoint = dashboardEndPoint;
            _window = window;

        }


        
        protected override async void OnViewLoaded(object view)
        {

        retry1: try
            {

                await LoadData();
                Prog = false;
                Form = true;

            }
            catch (Exception e)
            {

                // show a dialog with retry buton or exit the application

                Prog = false;
                //for example :
                var Error = IoC.Get<NetworkErrorViewModel>();
                Transition = true;
                var result = _window.ShowDialog(Error, null, null);
                Transition = false;
                if (result.HasValue && result.Value)
                {
                    Prog = true;
                    goto retry1;

                }
                else
                {

                    DataBaseError = true;
                    // here i have to make a panel for error connextion when i exit application
                }


            }



        }

        public async Task LoadData()
        {




            Dash = await _dashboardEndPoint.GetDashboard();



            IncidentChart = new ObservableCollection<IncidentChartModel>(Dash.IncidentChart);
            InterventionChart = new ObservableCollection<InterventionChartModel>(Dash.InterventionChart);
            Last4WeeksIncidentChart = new ObservableCollection<Last4WeeksChartModel>(Dash.Last4WeeksChart);
            Last4WeeksInterventionChart = new ObservableCollection<Last4WeeksInterventionChartModel>(Dash.Last4WeeksInterventionChart);





        }









    }
}
