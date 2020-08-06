using Caliburn.Micro;
using NetworkApp.Helper;
using NetworkApp.Library.Models.ListDesSiteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.ViewModels
{
    public class NetworkDevicesViewModel : Screen
    {


        private FullSiteModel  _fullSite = new FullSiteModel();

        public FullSiteModel fullSite
        {
            get { return _fullSite; }
            set { 
                _fullSite = value;

                NotifyOfPropertyChange(() => fullSite);
            }
        }


        private BindableCollection<SiteEquipementModel> _equipements ;

        public BindableCollection<SiteEquipementModel> Equipements
        {
            get { return _equipements; }
            set { 
                _equipements = value;
                NotifyOfPropertyChange(() => Equipements);
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

        private IWindowManager _window;
        public NetworkDevicesViewModel(IWindowManager window)
        {
            _window = window;
        }


        


        public void Ssh(SiteEquipementModel equipement)
        {
            Putty.puttySsh(equipement.EquipementIp);
        }


        public void Telnet(SiteEquipementModel equipement)
        {
            Putty.puttyTelnet(equipement.EquipementIp);
        }

        public void Ping()
        {

        }

        public void ExitApplication()
        {

            Putty.RemoveExitedProcess();
            if (Putty.Processes.Any())
            {
                var Delete = IoC.Get<ExitEquipementsDialogeViewModel>();
                Transition = true;
                var result = _window.ShowDialog(Delete, null, null);
                Transition = false;
                if (result.HasValue && result.Value)
                {
                    Putty.killProcess();

                }

                Putty.Processes.Clear();
            }

           
            TryClose();
        }

    }

    
}
