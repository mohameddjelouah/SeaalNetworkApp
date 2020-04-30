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

        private ObservableCollection<Model> _fruits;

        public ObservableCollection<Model> Fruits
        {
            get { return _fruits; }
            set { _fruits = value;
                NotifyOfPropertyChange(() => Fruits);
            }
        }


        //public ObservableCollection<Model> Fruits { get; set; }



        private IDashboardEndPoint _dashboardEndPoint;

        public DashViewModel(IDashboardEndPoint dashboardEndPoint)
        {
            _dashboardEndPoint = dashboardEndPoint;

            



        }


        
        protected override async void OnViewLoaded(object view)
        {


            IncidentChart = new ObservableCollection<IncidentChartModel>((await _dashboardEndPoint.GetDashboard()).IncidentChart);

            this.Fruits = new ObservableCollection<Model>();

            Fruits.Add(new Model() { FruitName = "Apple", People = 27 });
            Fruits.Add(new Model() { FruitName = "Orange", People = 33 });
            Fruits.Add(new Model() { FruitName = "Grapes", People = 15 });
            Fruits.Add(new Model() { FruitName = "Banana", People = 5 });
            Fruits.Add(new Model() { FruitName = "Blueberry", People = 20 });

        }

        public class Model
        {
            public double People { get; set; }

            public string FruitName { get; set; }
        }









    }
}
