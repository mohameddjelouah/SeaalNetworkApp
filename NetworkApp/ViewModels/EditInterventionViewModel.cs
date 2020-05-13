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
    public class EditInterventionViewModel : Screen
    {
        private InterventionModel _intervention = new InterventionModel();

        public InterventionModel Intervention
        {
            get { return _intervention; }
            set { 
                _intervention = value;
                NotifyOfPropertyChange(() => Intervention);
            }
        }


        private AddInterventionModel _interventionData;

        public AddInterventionModel InterventionData
        {
            get { return _interventionData; }
            set {
                _interventionData = value;
                NotifyOfPropertyChange(() => InterventionData);
            }
        }


        private DateTime? _interventionDate;

        public DateTime? InterventionDate
        {
            get { return _interventionDate; }
            set
            {
                _interventionDate = value;
                NotifyOfPropertyChange(() => InterventionDate);
                NotifyOfPropertyChange(() => CanEditIntervention);
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
                NotifyOfPropertyChange(() => CanEditIntervention);

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
                NotifyOfPropertyChange(() => CanEditIntervention);

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
            set
            {
                _selectedIdentification = value;
                NotifyOfPropertyChange(() => SelectedIdentification);
                NotifyOfPropertyChange(() => CanEditIntervention);
            }
        }

        private EquipementModel _selectedEquipement;

        public EquipementModel SelectedEquipement
        {
            get { return _selectedEquipement; }
            set
            {
                _selectedEquipement = value;
                NotifyOfPropertyChange(() => SelectedEquipement);
                NotifyOfPropertyChange(() => CanEditIntervention);
            }
        }


        private ActionModel _selectedAction;

        public ActionModel SelectedAction
        {
            get { return _selectedAction; }
            set
            {
                _selectedAction = value;
                NotifyOfPropertyChange(() => SelectedAction);
                NotifyOfPropertyChange(() => CanEditIntervention);
            }
        }

        private string _rapport;

        public string Rapport
        {
            get { return _rapport; }
            set
            {
                _rapport = value;
                NotifyOfPropertyChange(() => Rapport);
                NotifyOfPropertyChange(() => CanEditIntervention);
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
        private bool _addProg = false;

        public bool AddProg
        {
            get { return _addProg; }
            set
            {
                _addProg = value;
                NotifyOfPropertyChange(() => AddProg);

            }
        }
        //**************************************************************************************************************
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

        private bool _isEdit = false;

        public bool isEdit
        {
            get { return _isEdit; }
            set
            {
                _isEdit = value;
                NotifyOfPropertyChange(() => isEdit);
            }
        }


        private IWindowManager _window;
        private IInterventionDataEndPoint _interventionDataEndPoint;
        private IInterventionEndPoint _interventionEndPoint;
        public EditInterventionViewModel(IWindowManager window, IInterventionDataEndPoint interventionDataEndPoint, IInterventionEndPoint interventionEndPoint)
        {
            _window = window;
            _interventionDataEndPoint = interventionDataEndPoint;
            _interventionEndPoint = interventionEndPoint;
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

        private async Task LoadData()
        {


            InterventionData = await _interventionDataEndPoint.GetInterventionData();
            Directions = new BindableCollection<DirectionModel>(InterventionData.Directions);
            Identifications = new BindableCollection<IdentificationModel>(InterventionData.Identifications);
            Equipements = new BindableCollection<EquipementModel>(InterventionData.Equipements);
            Actions = new BindableCollection<ActionModel>(InterventionData.Actions);

            InterventionDate = Intervention.InterventionDate;
            SelectedDirection = Directions.SingleOrDefault(x => (x.Id == Intervention.Direction.Id));
            SelectedSite = SelectedDirection.Sites.SingleOrDefault(x => x.Id == Intervention.Site.Id);
            SelectedIdentification = Identifications.SingleOrDefault(x => (x.Id == Intervention.Identification.Id));
            SelectedEquipement = Equipements.SingleOrDefault(x => (x.Id == Intervention.Equipement.Id));
            SelectedAction = Actions.SingleOrDefault(x => (x.Id == Intervention.Action?.Id));
            Rapport = Intervention.Rapport;
            





        }



        public bool CanEditIntervention
        {
            get
            {


                return CheckInputs();


            }

        }



        public async Task EditIntervention()
        {


            var Confirme = IoC.Get<DeleteIncidentViewModel>();
            Transition = true;
            var result = _window.ShowDialog(Confirme, null, null);
            Transition = false;



            if (result.HasValue && result.Value)
            {
                AddProg = true;
                try
                {
                    int Id = Intervention.Id;
                    SelectedDirectionModel sd = new SelectedDirectionModel()
                    {
                        Id = SelectedDirection.Id,
                        Direction = SelectedDirection.Direction
                    };
                    Intervention = new InterventionModel()
                    {
                        Id = Id,
                        InterventionDate = InterventionDate,
                        Direction = sd,
                        Site = SelectedSite,
                        Identification = SelectedIdentification,
                        Equipement = SelectedEquipement,
                        Action = SelectedAction,
                        Rapport = Rapport,      
                        AddBy = System.Environment.UserName

                    };

                    StoreInterventionModel storeIntervention = new StoreInterventionModel()
                    {
                        Id = Id,
                        InterventionDate = InterventionDate,
                        DirectionId = sd.Id,
                        SiteId = SelectedSite.Id,
                        IdentificationId = SelectedIdentification.Id,
                        EquipemenetId = SelectedEquipement.Id,
                        ActionId = SelectedAction.Id,
                        Rapport = Rapport,
                        AddBy = System.Environment.UserName


                    };

                    await _interventionEndPoint.EditIntervention(storeIntervention);
                    isEdit = true;
                    AddProg = false;
                    var secces = IoC.Get<SeccesDialogViewModel>();
                    Transition = true;
                    _window.ShowDialog(secces, null, null);
                    Transition = false;
                    TryClose();
                }
                catch (Exception)
                {
                    AddProg = false;
                    var faild = IoC.Get<FaildDialogViewModel>();
                    Transition = true;
                    _window.ShowDialog(faild, null, null);
                    Transition = false;
                }


            }


        }






        public bool CheckInputs()
        {


            if (InterventionDate != null && SelectedDirection != null && SelectedSite != null && SelectedIdentification != null && SelectedEquipement != null && SelectedAction != null && !string.IsNullOrWhiteSpace(Rapport))
            {
                return true;
            }
            return false;
        }


        public void ExitApplication()
        {
            TryClose(false);
        }
    }
}
