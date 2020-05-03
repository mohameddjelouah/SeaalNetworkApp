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

        private ObservableCollection<Last4WeeksChartModel> _last4WeeksChart;

        public ObservableCollection<Last4WeeksChartModel> Last4WeeksChart
        {
            get { return _last4WeeksChart; }
            set { 
                _last4WeeksChart = value;
                NotifyOfPropertyChange(() => Last4WeeksChart);
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




        private IDashboardEndPoint _dashboardEndPoint;

        public DashViewModel(IDashboardEndPoint dashboardEndPoint)
        {
            _dashboardEndPoint = dashboardEndPoint;

            



        }


        
        protected override async void OnViewLoaded(object view)
        {

            Dash = await _dashboardEndPoint.GetDashboard();
            
            
            
            //d.IncidentTotal.IncidentTotal
            IncidentChart = new ObservableCollection<IncidentChartModel>(Dash.IncidentChart);
            Last4WeeksChart = new ObservableCollection<Last4WeeksChartModel>(Dash.Last4WeeksChart);
            
           
        }

        









    }
}
