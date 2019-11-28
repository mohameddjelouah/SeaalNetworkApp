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
    public class IncidentViewModel : Screen
    {

        public List<IncidentModel> listofincidents { get; set; }
       
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
        

        private BindableCollection<IncidentModel> _dataincident;

        public BindableCollection<IncidentModel> dataincident
        {
            get { return _dataincident; }
            set {
                _dataincident = value;
                NotifyOfPropertyChange(() => dataincident);
            
            }
        }

        IWindowManager _window;

        private IIncidentEndPoint _incidentEndPoint;

        public IncidentViewModel(IIncidentEndPoint incidentEndPoint, IWindowManager window)
        {
            _incidentEndPoint = incidentEndPoint;
            _window = window;
          


        }

        protected override async void OnViewLoaded(object view)
        { // if loading incuident doesnt work we caatch an exception that stop progress bar and display a message with failure
            base.OnViewLoaded(view);

            await LoadIncidents();
            
            Prog = false;
            Load = true;

        }


        private async Task  LoadIncidents ()
        {
            
             listofincidents = (await _incidentEndPoint.GetAllIncident());
            dataincident =new BindableCollection<IncidentModel>(listofincidents);
            
            
        }

        private string _search;
        public string search
        {
            get { return _search; }
            set
            {
                _search = value;

                var list = listofincidents.Where(x => x.Direction.Direction.Contains(value) || x.AddBy.ToLower().Contains(value.ToLower()) || x.Site.Site.Contains(value)).ToList();
              
                dataincident = new BindableCollection<IncidentModel>(list);

            }
        }

        public async Task Delete(IncidentModel incident)
        {
            //delete incident
            var u = IoC.Get<DeleteIncidentViewModel>();
            var result = _window.ShowDialog(u ,null, null);
            if (result.HasValue && result.Value)
            {
                await _incidentEndPoint.DeleteIncident(incident.Id);
                dataincident.Remove(incident);
            }
            
        }

        
        
        public void Edit(IncidentModel incident)
        {
           //edit incident

        }



        








    }
    }

