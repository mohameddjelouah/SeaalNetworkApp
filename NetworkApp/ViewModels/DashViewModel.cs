using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using NetworkApp.Library.Api;
using NetworkApp.Library.Api.Interfaces;

namespace NetworkApp.ViewModels
{
    public class DashViewModel : Screen
    {
        private string _auth;
        private IIncidentEndPoint _incidentEndPoint;

        public DashViewModel(IIncidentEndPoint incidentEndPoint)
        {
            _incidentEndPoint = incidentEndPoint;
        }
        public string Auth
        {
            get { return _auth; }
            set { _auth = value; NotifyOfPropertyChange(() => Auth); }
        }

        private string _user;


        public string User
        {
            get { return _user; }
            set { _user = value; NotifyOfPropertyChange(() => User); }
        }



        public async Task  getinfo()
        {
            // User = WindowsIdentity.GetCurrent().Name;
            var incidentbyid = await _incidentEndPoint.GetIncident(2);

            var listofincidents = await _incidentEndPoint.GetAllIncident();

            User = listofincidents.Count().ToString();

           
            
        }



    }
}
