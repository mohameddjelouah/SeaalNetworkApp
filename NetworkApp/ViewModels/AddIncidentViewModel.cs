using Caliburn.Micro;
using NetworkApp.Library.Api;
using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models;
using NetworkApp.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.ViewModels
{
    public class AddIncidentViewModel : Screen
    {
        private BindableCollection<DirectionModel> _directions;
        public BindableCollection<DirectionModel> Directions
        {
            get { return _directions; }
            set {
                _directions = value;
                NotifyOfPropertyChange(() => Directions);

            }
        }

        

        private DirectionModel _selectedDirection;

        public DirectionModel SelectedDirection
        {
            get { return _selectedDirection; }
            set {
                _selectedDirection = value;
                NotifyOfPropertyChange(() => SelectedDirection);
               
            }
        }

        private SiteModel _selectedSite;
        public SiteModel SelectedSite
        {
            get { return _selectedSite; }
            set
            {
                _selectedSite = value;
                NotifyOfPropertyChange(() => SelectedSite);

            }
        }


       
        private IIncidentDataEndPoint _incidentDataEndPoint;
        public AddIncidentViewModel(IIncidentDataEndPoint incidentDataEndPoint)
        {
            _incidentDataEndPoint = incidentDataEndPoint;

            
        }

        protected override async void OnViewLoaded(object view)
        { // if loading incuident doesnt work we caatch an exception that stop progress bar and display a message with failure
            base.OnViewLoaded(view);



            Directions = new BindableCollection<DirectionModel>(await LoadData()) ; 



        }
        private async Task<List<DirectionModel>> LoadData()
        {
            return await _incidentDataEndPoint.GetDirections();
        }
    }
}
