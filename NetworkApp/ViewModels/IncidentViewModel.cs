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

        public List<UIIncidentModel> listofincidents { get; set; }
       
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
        

        private BindableCollection<UIIncidentModel> _dataincident;

        public BindableCollection<UIIncidentModel> dataincident
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
            
             listofincidents = await _incidentEndPoint.GetAllIncident();
            dataincident =new BindableCollection<UIIncidentModel>(listofincidents);
            
            
        }

        private string _search;
        public string search
        {
            get { return _search; }
            set
            {
                _search = value;

                var list = listofincidents.Where(x => (x.Direction.Contains(value) || x.AddBy.Contains(value) || x.Site.Contains(value))).ToList();
              
                dataincident = new BindableCollection<UIIncidentModel>(list);

            }
        }

        public async Task Delete(UIIncidentModel incident)
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

        
        
        public void Edit(UIIncidentModel incident)
        {
           //edit incident

        }



        private async Task PostIncidents(int i)
        {

           await _incidentEndPoint.AddIncident(new UIIncidentModel {

               IncidentDate = DateTime.Now,
                Direction = $"add the incident {i}",
                Site = "add the incident",
                Nature = "add the incident",
                Operateur = "add the incident",
                isClotured = true,
                Solution = "add the incident",
                ClotureDate = DateTime.Now,
                AddBy = WindowsIdentity.GetCurrent().Name,


            } );


        }








    }
    }

