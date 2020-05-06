using Caliburn.Micro;
using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models;
using NetworkApp.Library.Models.InterventionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.ViewModels
{
    public class AddInterventionViewModel : Screen
    {

        private AddInterventionModel _data;

        public AddInterventionModel Data
        {
            get { return _data; }
            set
            {
                _data = value;
                NotifyOfPropertyChange(() => Data);
            }
        }

        private DateTime? _interventionDate;

        public DateTime? InterventionDate
        {
            get { return _interventionDate; }
            set {
                _interventionDate = value;
                NotifyOfPropertyChange(() => InterventionDate);
            
            }
        }


        private BindableCollection<DirectionModel> _directions;
        public BindableCollection<DirectionModel> Directions
        {
            get { return _directions; }
            set
            {
                _directions = value;
                NotifyOfPropertyChange(() => Directions);

            }
        }


        private DirectionModel _selectedDirection;

        public DirectionModel SelectedDirection
        {
            get { return _selectedDirection; }
            set
            {
                _selectedDirection = value;
                NotifyOfPropertyChange(() => SelectedDirection);
               // NotifyOfPropertyChange(() => CanAddIncident);

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
               // NotifyOfPropertyChange(() => CanAddIncident);

            }
        }



        private BindableCollection<IdentificationModel> _identifications;
        public BindableCollection<IdentificationModel> Identifications
        {
            get { return _identifications; }
            set
            {
                _identifications = value;
                NotifyOfPropertyChange(() => Identifications);

            }
        }




        private BindableCollection<EquipementModel> _equipements;
        public BindableCollection<EquipementModel> Equipements
        {
            get { return _equipements; }
            set
            {
                _equipements = value;
                NotifyOfPropertyChange(() => Equipements);

            }
        }


        private BindableCollection<ActionModel> _actions;
        public BindableCollection<ActionModel> Actions
        {
            get { return _actions; }
            set
            {
                _actions = value;
                NotifyOfPropertyChange(() => Actions);

            }
        }


        private IdentificationModel _selectedIdentification;

        public IdentificationModel SelectedIdentification
        {
            get { return _selectedIdentification; }
            set {
                _selectedIdentification = value;
                NotifyOfPropertyChange(() => SelectedIdentification);
            }
        }

        private EquipementModel _selectedEquipement;

        public EquipementModel SelectedEquipement
        {
            get { return _selectedEquipement; }
            set { 
                _selectedEquipement = value;
                NotifyOfPropertyChange(() => SelectedEquipement);
            }
        }


        private ActionModel _selectedAction;

        public ActionModel SelectedAction
        {
            get { return _selectedAction; }
            set {
                _selectedAction = value;
                NotifyOfPropertyChange(() => SelectedAction);
            }
        }

        private string _rapport;

        public string Rapport
        {
            get { return _rapport; }
            set { 
                _rapport = value;
                NotifyOfPropertyChange(() => Rapport);
            }
        }



        private IInterventionDataEndPoint _interventionDataEndPoint;
        private IInterventionEndPoint _interventionEndPoint;
        private IWindowManager _window;
        public AddInterventionViewModel(IInterventionDataEndPoint interventionDataEndPoint, IInterventionEndPoint interventionEndPoint, IWindowManager window)
        {
            _interventionDataEndPoint = interventionDataEndPoint;
            _interventionEndPoint = interventionEndPoint;
            _window = window;


        }


        protected override async void OnViewLoaded(object view)
        { // if loading incuident doesnt work we caatch an exception that stop progress bar and display a message with failure
            base.OnViewLoaded(view);

            await LoadData();
        }



        public async Task LoadData()
        {
            var p = await _interventionDataEndPoint.GetInterventionData();

            Data = await _interventionDataEndPoint.GetInterventionData();
            Directions = new BindableCollection<DirectionModel>(Data.Directions);
            Identifications = new BindableCollection<IdentificationModel>(Data.Identifications);
            Equipements = new BindableCollection<EquipementModel>(Data.Equipements);
            Actions = new BindableCollection<ActionModel>(Data.Actions);
        }


        public async Task AddIntervention()
        {

            StoreInterventionModel intervention = new StoreInterventionModel()
            {
                InterventionDate = InterventionDate,
                DirectionId = SelectedDirection.Id,
                SiteId = SelectedSite.Id,
                IdentificationId = SelectedIdentification.Id,
                EquipemenetId = SelectedEquipement.Id,
                ActionId = SelectedAction.Id,
                Rapport = Rapport,
                AddBy = System.Environment.UserName
            };

            await _interventionEndPoint.AddIntervention(intervention);

        }
    }
}