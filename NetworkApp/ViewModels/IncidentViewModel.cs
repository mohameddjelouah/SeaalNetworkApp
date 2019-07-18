using Caliburn.Micro;
using NetworkApp.Library.Api;
using NetworkApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.ViewModels
{
    public class IncidentViewModel : Screen
    {
        public BindableCollection<UIIncidentModel> dataincident { get; set; } 
       


        
        private IIncidentEndPoint _incidentEndPoint;

        public IncidentViewModel(IIncidentEndPoint incidentEndPoint)
        {
            _incidentEndPoint = incidentEndPoint;

           

        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadIncidents();
        }


        private async Task  LoadIncidents ()
        {
            
            var listofincidents = await _incidentEndPoint.GetAllIncident();
            dataincident =new BindableCollection<UIIncidentModel>(listofincidents);
            NotifyOfPropertyChange(() => dataincident);
            
        }
       





      
    }
}

