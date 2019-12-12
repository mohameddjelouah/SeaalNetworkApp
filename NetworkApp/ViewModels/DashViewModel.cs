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
        



        



    }
}
