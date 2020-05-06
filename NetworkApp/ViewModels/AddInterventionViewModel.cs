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
                NotifyOfPropertyChange(() => CanAddIntervention);
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
                NotifyOfPropertyChange(() => CanAddIntervention);

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
                NotifyOfPropertyChange(() => CanAddIntervention);

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
                NotifyOfPropertyChange(() => CanAddIntervention);
            }
        }

        private EquipementModel _selectedEquipement;

        public EquipementModel SelectedEquipement
        {
            get { return _selectedEquipement; }
            set { 
                _selectedEquipement = value;
                NotifyOfPropertyChange(() => SelectedEquipement);
                NotifyOfPropertyChange(() => CanAddIntervention);
            }
        }


        private ActionModel _selectedAction;

        public ActionModel SelectedAction
        {
            get { return _selectedAction; }
            set {
                _selectedAction = value;
                NotifyOfPropertyChange(() => SelectedAction);
                NotifyOfPropertyChange(() => CanAddIntervention);
            }
        }

        private string _rapport;

        public string Rapport
        {
            get { return _rapport; }
            set { 
                _rapport = value;
                NotifyOfPropertyChange(() => Rapport);
                NotifyOfPropertyChange(() => CanAddIntervention);
            }
        }

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
            var p = await _interventionDataEndPoint.GetInterventionData();

            Data = await _interventionDataEndPoint.GetInterventionData();
            Directions = new BindableCollection<DirectionModel>(Data.Directions);
            Identifications = new BindableCollection<IdentificationModel>(Data.Identifications);
            Equipements = new BindableCollection<EquipementModel>(Data.Equipements);
            Actions = new BindableCollection<ActionModel>(Data.Actions);
        }




        public bool CanAddIntervention
        {
            get
            {


                return CheckInputs();


            }

        }

        public async Task AddIntervention()
        {
            try
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

                var secces = IoC.Get<SeccesDialogViewModel>();
                Transition = true;
                _window.ShowDialog(secces, null, null);
                Transition = false;
                InterventionDate = null;
                SelectedDirection = null;
                SelectedIdentification = null;
                SelectedEquipement = null;
                SelectedAction = null;
                Rapport = null;
            }
            catch (Exception)
            {

                var faild = IoC.Get<FaildDialogViewModel>();
                Transition = true;
                _window.ShowDialog(faild, null, null);
                Transition = false;
            }
            
        }

        public bool CheckInputs()
        {


            if (InterventionDate != null && SelectedDirection != null && SelectedSite != null && SelectedIdentification != null && SelectedEquipement != null && SelectedAction != null && !string.IsNullOrEmpty(Rapport))
            {
                return true;
            }
            return false;
        }
    }
}