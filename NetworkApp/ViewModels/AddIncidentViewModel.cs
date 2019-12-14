﻿using Caliburn.Micro;
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
            }
        }

        private DateTime? _ClotureDate = null;

        public DateTime? ClotureDate
        {
            get { return _ClotureDate; }
            set {
                
                _ClotureDate = value;
                NotifyOfPropertyChange(() => ClotureDate);
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

        private IIncidentDataEndPoint _incidentDataEndPoint;
        private IIncidentEndPoint _incidentEndPoint;
        public AddIncidentViewModel(IIncidentDataEndPoint incidentDataEndPoint,IIncidentEndPoint incidentEndPoint)
        {
            _incidentDataEndPoint = incidentDataEndPoint;
            _incidentEndPoint = incidentEndPoint;

            
        }

        protected override async void OnViewLoaded(object view)
        { // if loading incuident doesnt work we caatch an exception that stop progress bar and display a message with failure
            base.OnViewLoaded(view);

            await LoadData();


            

        }
        private async Task LoadData()
        {

            Data = await _incidentDataEndPoint.GetDirections();
            Directions = new BindableCollection<DirectionModel>(Data.Directions);
            Nature = new BindableCollection<NatureModel>(Data.Natures);
            Origin = new BindableCollection<OriginModel>(Data.Origins);
            Operateur = new BindableCollection<OperateurModel>(Data.Operateurs);
             
        }


        public bool CanAddIncident
        {
            get
            {

                //bool output = false;

                //if ()
                //{
                //    output = true;
                //}
                return true;


            }

        }

        public void AddIncident()
        {
            IncidentModel incident = new IncidentModel()
            {
                IncidentDate = IncidentDate,
                Direction = SelectedDirection,
                Site = SelectedSite,
                Nature = SelectedNature,
                Origin = SelectedOrigin,
                Operateur = SelectedOperateur,
                isClotured = CanSolution,
                Solution = Solution,
                ClotureDate = ClotureDate,
                AddBy = WindowsIdentity.GetCurrent().Name

            };

            _incidentEndPoint.AddIncident(incident);

        }
        //**************************************************************************************************************



    }
}
