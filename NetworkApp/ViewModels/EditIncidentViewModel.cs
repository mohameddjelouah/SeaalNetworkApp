using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models;

namespace NetworkApp.ViewModels
{
    public class EditIncidentViewModel : Screen
    {
        
        private IncidentModel _incident = new IncidentModel();

        public IncidentModel Incident
        {
            get { return _incident; }
            set
            {
                _incident = value;
                
                NotifyOfPropertyChange(() => Incident);
                
            }
        }


//**********************************************************************************
        private AddIncidentModel _data;

        public AddIncidentModel Data
        {
            get { return _data; }
            set
            {
                _data = value;
                NotifyOfPropertyChange(() => Data);
            }
        }
//*************************************************************************************
        private DateTime? _IncidentDate = null;

        public DateTime? IncidentDate
        {
            get { return _IncidentDate; }
            set
            {

                _IncidentDate = value;
                NotifyOfPropertyChange(() => IncidentDate);
                NotifyOfPropertyChange(() => CanEditIncident);
            }
        }
//*******************************************************************************************
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
                NotifyOfPropertyChange(() => CanEditIncident);

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
                NotifyOfPropertyChange(() => CanEditIncident);

            }
        }
//**************************************************************************************************
        private BindableCollection<NatureModel> _Nature;

        public BindableCollection<NatureModel> Nature
        {
            get { return _Nature; }
            set
            {
                _Nature = value;


                NotifyOfPropertyChange(() => Nature);


            }
        }

        private NatureModel _SelectedNature;

        public NatureModel SelectedNature
        {
            get { return _SelectedNature; }
            set
            {
                _SelectedNature = value;


                NotifyOfPropertyChange(() => SelectedNature);
                NotifyOfPropertyChange(() => CanEditIncident);


            }
        }
//*******************************************************************************************************

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


        private OriginModel _SelectedOrigin;

        public OriginModel SelectedOrigin
        {
            get { return _SelectedOrigin; }
            set
            {
                _SelectedOrigin = value;

                if (_SelectedOrigin.Origin == "externe")
                {
                    Externe = true;
                }
                else
                {
                    Externe = false;
                    SelectedOperateur = null;
                }

                NotifyOfPropertyChange(() => SelectedOrigin);
                NotifyOfPropertyChange(() => CanEditIncident);


            }
        }
//*****************************************************************************************************
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

        private OperateurModel _SelectedOperateur;

        public OperateurModel SelectedOperateur
        {
            get { return _SelectedOperateur; }
            set
            {
                _SelectedOperateur = value;


                NotifyOfPropertyChange(() => SelectedOperateur);
                NotifyOfPropertyChange(() => CanEditIncident);


            }
        }
//**********************************************************************************************************

        

        private string _Solution;

        public string Solution
        {
            get { return _Solution; }
            set
            {
                _Solution = value;
                NotifyOfPropertyChange(() => Solution);
                NotifyOfPropertyChange(() => CanEditIncident);
            }
        }

        private DateTime? _ClotureDate = null;

        public DateTime? ClotureDate
        {
            get { return _ClotureDate; }
            set
            {

                _ClotureDate = value;
                NotifyOfPropertyChange(() => ClotureDate);
                NotifyOfPropertyChange(() => CanEditIncident);
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





        private bool _Externe = false;

        public bool Externe
        {
            get { return _Externe; }
            set
            {
                _Externe = value;
                NotifyOfPropertyChange(() => Externe);

            }
        }

        //*************************************************************************************************

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
        //************************************************************************************************
        private bool _isEdit = false;

        public bool isEdit
        {
            get { return _isEdit ; }
            set {
                _isEdit  = value;
                NotifyOfPropertyChange(() => isEdit);
            }
        }

        //************************************************************************************************
        private IWindowManager _window;
        private IIncidentDataEndPoint _incidentDataEndPoint;
        private IIncidentEndPoint _incidentEndPoint;
        public EditIncidentViewModel(IIncidentDataEndPoint incidentDataEndPoint, IWindowManager window, IIncidentEndPoint incidentEndPoint)
        {
            _incidentDataEndPoint = incidentDataEndPoint;
            _incidentEndPoint = incidentEndPoint;
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

        private async Task LoadData()
        {

           
                Data = await _incidentDataEndPoint.GetIncidentData();
                Directions = new BindableCollection<DirectionModel>(Data.Directions);
                Nature = new BindableCollection<NatureModel>(Data.Natures);
                Origin = new BindableCollection<OriginModel>(Data.Origins);
                Operateur = new BindableCollection<OperateurModel>(Data.Operateurs);

                IncidentDate = Incident.IncidentDate;
                SelectedDirection = Directions.SingleOrDefault(x => (x.Id == Incident.Direction.Id));
                SelectedSite = SelectedDirection.Sites.SingleOrDefault(x => x.Id == Incident.Site.Id);
                SelectedNature = Nature.SingleOrDefault(x => (x.Id == Incident.Nature.Id));
                SelectedOrigin = Origin.SingleOrDefault(x => (x.Id == Incident.Origin.Id));
                SelectedOperateur = Operateur.SingleOrDefault(x => (x.Id == Incident.Operateur?.Id));
                Solution = Incident.Solution;
                ClotureDate = Incident.ClotureDate;
            

            
            

        }

        
        public bool CanEditIncident
        {
            get
            {


                return CheckInputs();


            }

        }

        

        public async Task EditIncident()
        {
            var Confirme = IoC.Get<DeleteIncidentViewModel>();
            Transition = true;
            var result = _window.ShowDialog(Confirme, null, null);
            Transition = false;
            if (result.HasValue && result.Value)
            {

                try
                {
                    int Id = Incident.Id;
                    bool isclotured = Incident.isClotured;
                    SelectedDirectionModel sd = new SelectedDirectionModel()
                    {
                        Id = SelectedDirection.Id,
                        Direction = SelectedDirection.Direction
                    };
                    Incident = new IncidentModel()
                    {
                        Id = Id,
                        IncidentDate = IncidentDate,
                        Direction = sd,
                        Site = SelectedSite,
                        Nature = SelectedNature,
                        Origin = SelectedOrigin,
                        Operateur = SelectedOperateur,
                        ClotureDate = ClotureDate,
                        Solution = Solution,
                        isClotured = isclotured,
                        AddBy = System.Environment.UserName

                    };

                    StoreIncidentModel storeIncident = new StoreIncidentModel()
                    {
                        Id = Id,
                        IncidentDate = IncidentDate,
                        Direction = sd.Id,
                        Site = SelectedSite.Id,
                        Nature = SelectedNature.Id,
                        Origin = SelectedOrigin.Id,
                        Operateur = SelectedOperateur?.Id,
                        ClotureDate = ClotureDate,
                        Solution = Solution,
                        isClotured = isclotured,
                        AddBy = System.Environment.UserName


                    };
                    
                    await _incidentEndPoint.EditIncident(storeIncident);
                    isEdit = true;
                    var secces = IoC.Get<SeccesDialogViewModel>();
                    Transition = true;
                    _window.ShowDialog(secces, null, null);
                    Transition = false;
                    TryClose();
                }
                catch (Exception)
                {

                    var faild = IoC.Get<FaildDialogViewModel>();
                    Transition = true;
                    _window.ShowDialog(faild, null, null);
                    Transition = false;
                }
                

            }
            
        }


        public bool CheckInputs()
        {
            
            
            if (IncidentDate !=null && SelectedDirection != null && SelectedSite != null && SelectedNature != null && SelectedOrigin != null && !string.IsNullOrEmpty(Solution) &&  ClotureDate != null)
            {

                if ((SelectedOrigin.Origin == "externe" && SelectedOperateur != null) || (SelectedOrigin.Origin == "interne"))
                {
                    
                        return true;
                    
                }

            }
            return false;
            
            
        }

        public void ExitApplication()
        {
            TryClose(false);
        }
    }
}
