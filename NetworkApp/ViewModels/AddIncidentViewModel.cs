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


        private AddIncidentModel _data;

        public AddIncidentModel Data
        {
            get { return _data; }
            set {
                _data = value;
                NotifyOfPropertyChange(() => Data);
            }
        }


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

        private BindableCollection<NatureModel> _Nature;

        public BindableCollection<NatureModel> Nature
        {
            get { return _Nature; }
            set { _Nature = value;


                NotifyOfPropertyChange(() => Nature);


            }
        }

        private BindableCollection<OriginModel> _Origin;

        public BindableCollection<OriginModel> Origin
        {
            get { return _Origin; }
            set
            {
                _Origin = value;


                NotifyOfPropertyChange(() => Origin);


            }
        }


        private BindableCollection<OperateurModel> _Operateur;

        public BindableCollection<OperateurModel> Operateur
        {
            get { return _Operateur; }
            set
            {
                _Operateur = value;


                NotifyOfPropertyChange(() => Operateur);


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

            Data = await LoadData();

            Directions = new BindableCollection<DirectionModel>(Data.Directions) ;
            Nature = new BindableCollection<NatureModel>(Data.Natures) ;
            Origin = new BindableCollection<OriginModel>(Data.Origins) ;
            Operateur = new BindableCollection<OperateurModel>(Data.Operateurs) ;

            

        }
        private async Task<AddIncidentModel> LoadData()
        {
            return await _incidentDataEndPoint.GetDirections();
        }
    }
}
