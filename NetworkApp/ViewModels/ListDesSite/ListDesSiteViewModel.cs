using Caliburn.Micro;
using NetworkApp.Helper;
using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models;
using NetworkApp.Library.Models.InterventionModels;
using NetworkApp.Library.Models.ListDesSiteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NetworkApp.ViewModels
{
    public class ListDesSiteViewModel : Screen
    {

        public List<FullSiteModel> listofsites { get; set; }

        private IncidentModel _SelectedFullSite;

        public IncidentModel SelectedFullSite
        {
            get { return _SelectedFullSite; }
            set
            {
                _SelectedFullSite = value;

                NotifyOfPropertyChange(() => SelectedFullSite);
                //NotifyOfPropertyChange(() => CanDelete);
                //NotifyOfPropertyChange(() => CanEdit);
            }
        }



        private BindableCollection<FullSiteModel> _fullsite = new BindableCollection<FullSiteModel>();

        public BindableCollection<FullSiteModel> fullsite
        {
            get { return _fullsite; }
            set
            {
                _fullsite = value;
                NotifyOfPropertyChange(() => fullsite);


            }
        }


        private bool _load = false;

        public bool Load
        {
            get { return _load; }
            set
            {
                _load = value;
                NotifyOfPropertyChange(() => Load);

            }
        }

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

        private IWindowManager _window;

        private ISiteEndPoint _siteEndPoint;
        public ListDesSiteViewModel(ISiteEndPoint siteEndPoint, IWindowManager window)
        {
            _siteEndPoint = siteEndPoint;
            _window = window;
        }


        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        retry1: try
            {
                await LoadData();
                //NotifyOfPropertyChange(() => CanExport);
                Prog = false;
                Load = true;
            }
            catch (Exception e)
            {
                Prog = false;
                // show a dialog with retry buton or exit the application


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

            listofsites = await _siteEndPoint.GetAllSites();
            fullsite = new BindableCollection<FullSiteModel>(listofsites);


        }


        public void Edit()
        {




        }


        public void ShowSiteEquipements(FullSiteModel site)
        {
            var ShowSiteEquipements = IoC.Get<NetworkDevicesViewModel>();
            ShowSiteEquipements.fullSite = site;
            ShowSiteEquipements.Equipements = new BindableCollection<SiteEquipementModel>(site.SiteEquipements);
            Transition = true;
            var result = _window.ShowDialog(ShowSiteEquipements, null, null);
            Transition = false;
            if (ShowSiteEquipements.isEdit)
            {

                //Replace.ReplaceItem(listofintervention, SelectedIntervention, Edit.Intervention);
                //dataintervention = new BindableCollection<InterventionModel>(listofintervention);

            }
        }

    }





}
