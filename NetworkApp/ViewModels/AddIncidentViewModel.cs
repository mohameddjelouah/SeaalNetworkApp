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

//**********************************************************************************
        private AddIncidentModel _data;

        public AddIncidentModel Data
        {
            get { return _data; }
            set {
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
                NotifyOfPropertyChange(() => CanAddIncident);
            }
        }
//*******************************************************************************************
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
                NotifyOfPropertyChange(() => CanAddIncident);

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
                NotifyOfPropertyChange(() => CanAddIncident);

            }
        }
//**************************************************************************************************
        private BindableCollection<NatureModel> _Nature;

        public BindableCollection<NatureModel> Nature
        {
            get { return _Nature; }
            set { _Nature = value;


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
                NotifyOfPropertyChange(() => CanAddIncident);


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

        public  OriginModel SelectedOrigin
        {
            get { return _SelectedOrigin; }
            set
            {
                _SelectedOrigin = value;

                if (_SelectedOrigin.Origin == "externe")
                {
                    Externe = true;
                }
                else {
                    Externe = false;
                    SelectedOperateur = null;
                }

                NotifyOfPropertyChange(() => SelectedOrigin);
                NotifyOfPropertyChange(() => CanAddIncident);


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

        public  OperateurModel SelectedOperateur
        {
            get { return _SelectedOperateur; }
            set
            {
                _SelectedOperateur = value;


                NotifyOfPropertyChange(() => SelectedOperateur);
                NotifyOfPropertyChange(() => CanAddIncident);


            }
        }
//**********************************************************************************************************

        private bool _CanSolution = true;

        public bool CanSolution
        {
            get { return _CanSolution; }
            set {
                
                _CanSolution = value;
                NotifyOfPropertyChange(() => CanSolution);

            }
        }

        private string _Solution;

        public string Solution
        {
            get { return _Solution; }
            set {
                _Solution = value;
                NotifyOfPropertyChange(() => Solution);
                NotifyOfPropertyChange(() => CanAddIncident);
            }
        }

        private DateTime? _ClotureDate = null;

        public DateTime? ClotureDate
        {
            get { return _ClotureDate; }
            set {
                
                _ClotureDate = value;
                NotifyOfPropertyChange(() => ClotureDate);
                NotifyOfPropertyChange(() => CanAddIncident);
            }
        }


//**************************************************************************************************************

        private bool _isCloture = false;

        public bool isCloture
        {
            get { return _isCloture; }
            set {

                _isCloture = value;
                if (_isCloture)
                {
                    Solution = null;
                    ClotureDate = null;
                }
                CanSolution = !value;
                NotifyOfPropertyChange(() => isCloture);
                NotifyOfPropertyChange(() => CanAddIncident);

            }
        }


        //**************************************************************************************************************
        private bool _form = false;

        public bool Form
        {
            get { return _form; }
            set { 
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

        private IIncidentDataEndPoint _incidentDataEndPoint;
        private IIncidentEndPoint _incidentEndPoint;
        private IWindowManager _window;

        public AddIncidentViewModel(IIncidentDataEndPoint incidentDataEndPoint, IWindowManager window,IIncidentEndPoint incidentEndPoint)
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
             
        }


        public bool CanAddIncident
        {
            get
            {

                
                return CheckInputs();


            }

        }

        public void AddIncident()
        {

            
            StoreIncidentModel incident = new StoreIncidentModel()
            {
                
                IncidentDate = IncidentDate,
                Direction = SelectedDirection.Id,
                Site = SelectedSite.Id,
                Nature = SelectedNature.Id,
                Origin = SelectedOrigin.Id,
                Operateur = SelectedOperateur?.Id,
                isClotured = CanSolution,
                Solution = Solution,
                ClotureDate = ClotureDate,
                AddBy = WindowsIdentity.GetCurrent().Name

            };

            try
            {
                _incidentEndPoint.AddIncident(incident);
            }
            catch (Exception)
            {

                throw;
            }

           

        }
        //**************************************************************************************************************
        //**************************************************************************************************************
        

        public bool CheckInputs()
        {
            if (IncidentDate != null && SelectedDirection != null && SelectedSite != null && SelectedNature != null && SelectedOrigin != null)
            {
                if ((SelectedOrigin.Origin == "externe" && SelectedOperateur != null) || (SelectedOrigin.Origin == "interne"))
                {
                    if (isCloture == true || (isCloture == false && !string.IsNullOrEmpty(Solution) && ClotureDate !=null))
                    {
                        return true;
                    }
                }
                
            }

            return false;
        }

        //**************************************************************************************************************

    }
}
