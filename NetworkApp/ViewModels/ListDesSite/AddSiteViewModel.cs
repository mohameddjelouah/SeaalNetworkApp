using Caliburn.Micro;
using NetworkApp.Library.Api;
using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models;
using NetworkApp.Library.Models.InterventionModels;
using NetworkApp.Library.Models.ListDesSiteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.ViewModels
{
    public class AddSiteViewModel : Screen
    {
        
        
        
        private AddSiteDataModel _data;

        public AddSiteDataModel Data
        {
            get { return _data; }
            set
            {
                _data = value;
                NotifyOfPropertyChange(() => Data);
            }
        }






        private BindableCollection<SiteEquipementModel> _equipementList = new BindableCollection<SiteEquipementModel>();

        public BindableCollection<SiteEquipementModel> EquipementList
        {
            get
            {
                return _equipementList;

            }

        }


        private BindableCollection<SiteOperateurModel> _operateurList = new BindableCollection<SiteOperateurModel>();

        public BindableCollection<SiteOperateurModel> OperateurList
        {
            get
            {
                return _operateurList;

            }

        }





        private BindableCollection<EquipementModel> _equipement = new BindableCollection<EquipementModel>();

        public BindableCollection<EquipementModel> Equipement
        {
            get { return _equipement; }
            set { 
                _equipement = value;
                NotifyOfPropertyChange(() => Equipement);
            }
        }

        private BindableCollection<OperateurModel> _operateur = new BindableCollection<OperateurModel>();

        public BindableCollection<OperateurModel> Operateur
        {
            get { return _operateur; }
            set
            {
                _operateur = value;
                NotifyOfPropertyChange(() => Operateur);
            }
        }

        private BindableCollection<DhcpModel> _dhcp = new BindableCollection<DhcpModel>();

        public BindableCollection<DhcpModel> Dhcp
        {
            get { return _dhcp; }
            set
            {
                _dhcp = value;
                NotifyOfPropertyChange(() => Dhcp);
            }
        }

        private DhcpModel _selectedDhcpServer;

        public DhcpModel SelectedDhcpServer
        {
            get { return _selectedDhcpServer; }
            set
            {
                _selectedDhcpServer = value;
                NotifyOfPropertyChange(() => SelectedDhcpServer);
                NotifyOfPropertyChange(() => CanAddSite);

            }
        }


        private EquipementModel _selectedEquipement;

        public EquipementModel SelectedEquipement
        {
            get { return _selectedEquipement; }
            set { 
                _selectedEquipement = value;
                NotifyOfPropertyChange(() => SelectedEquipement);
                NotifyOfPropertyChange(() => CanAddEquipement);
            
            }
        }

        private OperateurModel _selectedOperateur;

        public OperateurModel SelectedOperateur
        {
            get { return _selectedOperateur; }
            set {
                _selectedOperateur = value;
                NotifyOfPropertyChange(() => SelectedOperateur);
                NotifyOfPropertyChange(() => CanAddOperateur);
            }
        }

        private BindableCollection<DirectionModel> _directions = new BindableCollection<DirectionModel>();
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
                NotifyOfPropertyChange(() => CanAddSite);
                if (SelectedDirection != null)
                {
                    EnableSite = true;
                }
            }
        }

        private Library.Models.SiteModel _selectedSite;
        public Library.Models.SiteModel SelectedSite
        {
            get { return _selectedSite; }
            set
            {
                _selectedSite = value;
                NotifyOfPropertyChange(() => SelectedSite);
                NotifyOfPropertyChange(() => CanAddSite);

            }
        }



        private bool _enableSite = false;

        public bool EnableSite
        {
            get { return _enableSite; }
            set
            {
                _enableSite = value;
                NotifyOfPropertyChange(() => EnableSite);
            }
        }


        private string _address;

        public string Address
        {
            get { return _address; }
            set { 
                _address = value;
                NotifyOfPropertyChange(() => Address);
                NotifyOfPropertyChange(() => CanAddSite);
            }
        }

        private string _mask;

        public string Mask
        {
            get { return _mask; }
            set
            {
                _mask = value;
                NotifyOfPropertyChange(() => Mask);
                NotifyOfPropertyChange(() => CanAddSite);
            }
        }

        private string _equipementName;

        public string EquipementName
        {
            get { return _equipementName; }
            set
            {
                _equipementName = value;
                NotifyOfPropertyChange(() => EquipementName);
                NotifyOfPropertyChange(() => CanAddEquipement);
            }
        }

        private string _equipementIp;

        public string EquipementIp
        {
            get { return _equipementIp; }
            set
            {
                _equipementIp = value;
                NotifyOfPropertyChange(() => EquipementIp);
                NotifyOfPropertyChange(() => CanAddEquipement);
            }
        }

       


        private SiteEquipementModel _selectedEquipementObject;

        public SiteEquipementModel SelectedEquipementObject
        {
            get { return _selectedEquipementObject; }
            set {
                _selectedEquipementObject = value;
                NotifyOfPropertyChange(() => SelectedEquipementObject);
                NotifyOfPropertyChange(() => CanDeleteSelectedEquipement);
            }
        }


        private SiteOperateurModel _selectedOperateurObject;

        public SiteOperateurModel SelectedOperateurObject
        {
            get { return _selectedOperateurObject; }
            set {
                _selectedOperateurObject = value;
                NotifyOfPropertyChange(() => SelectedOperateurObject);
                NotifyOfPropertyChange(() => CanDeleteOperateur);
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

        //**************************************************************************************************************

        private ISiteDataEndPoint _siteDataEndPoint;
        private ISiteEndPoint _siteEndPoint;
        private IWindowManager _window;

        public AddSiteViewModel(ISiteEndPoint siteEndPoint ,ISiteDataEndPoint siteDataEndPoint,IWindowManager window)
        {
            _siteDataEndPoint = siteDataEndPoint;
            _window = window;
            _siteEndPoint = siteEndPoint;




        }


        protected override async void OnViewLoaded(object view)
        {
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

            
            Data = await _siteDataEndPoint.GetSiteData();
            Directions = new BindableCollection<DirectionModel>(Data.Directions);
            Operateur = new BindableCollection<OperateurModel>(Data.Operateurs);
            Equipement = new BindableCollection<EquipementModel>(Data.Equipements);
            Dhcp = new BindableCollection<DhcpModel>(Data.DhcpServers);
        }


        //Equipement listbox ----------------------------------------------------------------------------------------------------------
        public bool CanAddEquipement
        {
            get
            {
                bool output = false;
                if (SelectedEquipement != null && !string.IsNullOrWhiteSpace(EquipementName) && !string.IsNullOrWhiteSpace(EquipementIp) && ValidateIPv4(EquipementIp) && !EquipementList.Any(x => x.EquipementIp == EquipementIp))
                {
                    output = true;

                }
                return output;
            }
        }

        public void AddEquipement()
        {
            SiteEquipementModel e = new SiteEquipementModel { Equipement = SelectedEquipement, EquipementHostname = EquipementName, EquipementIp = EquipementIp };
            EquipementList.Add(e);
            EquipementIp = null;
            NotifyOfPropertyChange(() => CanAddSite);

        }

        public bool CanDeleteSelectedEquipement
        {
            get
            {
                bool output = false;
                if (SelectedEquipementObject != null)
                {
                    output = true;
                }
                return output;
            }
        }

        public void DeleteSelectedEquipement()
        {
            EquipementList.Remove(SelectedEquipementObject);
            NotifyOfPropertyChange(() => CanAddEquipement);
            NotifyOfPropertyChange(() => CanAddSite);

        }

        //End of Equipement listbox ----------------------------------------------------------------------------------------------------

        //Operateur listbox ------------------------------------------------------------------------------------------------------------
        public bool CanAddOperateur
        {
            get
            {
                bool output = false;
                if (SelectedOperateur != null && !OperateurList.Any(x => x.Operateur.Operateur == SelectedOperateur.Operateur))
                {
                    output = true;
                }
                return output;
            }
        }

        public void AddOperateur()
        {

            SiteOperateurModel so = new SiteOperateurModel { Operateur = SelectedOperateur };

            OperateurList.Add(so);
            SelectedOperateur = null;
            NotifyOfPropertyChange(() => CanAddSite);
        }

        public bool CanDeleteOperateur
        {
            get
            {
                bool output = false;
                if (SelectedOperateurObject != null)
                {
                    output = true;
                }
                return output;
            }
        }

        public void DeleteOperateur()
        {
            OperateurList.Remove(SelectedOperateurObject);
            NotifyOfPropertyChange(() => CanAddOperateur);
            NotifyOfPropertyChange(() => CanAddSite);

        }
        //End of Operateur listbox -----------------------------------------------------------------------------------------------------



        public bool CanAddSite
        {
            get
            {

                return CheckInputs();
            }
        }

        public async Task AddSite()
        {

            AddProg = true;

            try
            {
                StoreSiteDetail siteDetail = new StoreSiteDetail
                {
                    DirectionId = SelectedDirection.Id,
                    SiteId = SelectedSite.Id,
                    Address = Address,
                    Mask = Mask,
                    DhcpId = SelectedDhcpServer.Id
                };

                StoreFullSiteModel FullSite = new StoreFullSiteModel
                {

                    SiteDetail = siteDetail,
                    SiteEquipements = EquipementList.ToList(),
                    SiteOperateurs = OperateurList.ToList()

                };

                await _siteEndPoint.AddSite(FullSite);
                AddProg = false;
                var secces = IoC.Get<SeccesDialogViewModel>();
                Transition = true;
                _window.ShowDialog(secces, null, null);
                Transition = false;
                Mask = null;
                Address = null;
                SelectedDirection = null;
                SelectedDhcpServer = null;
                EquipementList.Clear();
                OperateurList.Clear();
                SelectedEquipement = null;
                SelectedOperateur = null;
                EquipementName = null;
                EquipementIp = null;
                EnableSite = false;
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



        public bool CheckInputs()
        {
            if (SelectedDirection != null && SelectedSite != null && !string.IsNullOrWhiteSpace(Address) && !string.IsNullOrWhiteSpace(Mask) && SelectedDhcpServer != null && OperateurList.Any() && EquipementList.Any())
            {
                if (ValidateIPv4(Address) && ValidateIPv4(Mask))
                {
                    return true;
                }
            }

            return false;
        }
        public bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }

    }

    
}
