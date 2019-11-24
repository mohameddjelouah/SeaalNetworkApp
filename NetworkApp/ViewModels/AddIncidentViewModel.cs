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
        List<DirectionModel> l = new List<DirectionModel>();
        private IIncidentDataEndPoint _incidentDataEndPoint;
        public AddIncidentViewModel(IIncidentDataEndPoint incidentDataEndPoint)
        {
            _incidentDataEndPoint = incidentDataEndPoint;

            
        }

        protected override async void OnViewLoaded(object view)
        { // if loading incuident doesnt work we caatch an exception that stop progress bar and display a message with failure
            base.OnViewLoaded(view);

            

            l = await LoadData(); 



        }
        private async Task<List<DirectionModel>> LoadData()
        {
            return await _incidentDataEndPoint.GetDirections();
        }
    }
}
