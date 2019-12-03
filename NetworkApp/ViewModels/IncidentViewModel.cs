using Caliburn.Micro;
using NetworkApp.EventModels;
using NetworkApp.Helper;
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
        private IEventAggregator _events;
        public IncidentViewModel(IIncidentEndPoint incidentEndPoint, IWindowManager window, IEventAggregator events)
        {
            _incidentEndPoint = incidentEndPoint;
            _window = window;
            _events = events;


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
                _search = value.ToLower();

                var list = listofincidents.Where(x => 
                                                    x.Direction.Direction.ToLower().Contains(_search) || 
                                                    x.AddBy.ToLower().Contains(_search) || 
                                                    x.Site.Site.ToLower().Contains(_search) ||
                                                    x.Nature.Nature.ToLower().Contains(_search) ||
                                                    x.Origin.Origin.ToLower().Contains(_search) ||
                                                    
                                                    x.IncidentDate.ToString().Contains(_search)


                                                ).ToList();
               
              
                dataincident = new BindableCollection<IncidentModel>(list);

            }
        }

        public async Task Delete(IncidentModel incident)
        {
            //delete incident
            var Delete = IoC.Get<DeleteIncidentViewModel>();
            Transition = true;
            var result = _window.ShowDialog(Delete, null, null);
            Transition = false;
            if (result.HasValue && result.Value)
            {
                await _incidentEndPoint.DeleteIncident(incident.Id);
                listofincidents.Remove(incident);
                dataincident.Remove(incident);
            }
            
        }

        
        
        public void Edit(IncidentModel incident)
        {
            var Edit = IoC.Get<EditIncidentViewModel>();
            Edit.Incident = incident;
            Transition = true;
            var result = _window.ShowDialog(Edit, null, null);
            Transition = false;
            if (Edit.isEdit)
            {

                Replace.ReplaceItem(listofincidents, incident, Edit.Incident);


                dataincident = new BindableCollection<IncidentModel>(listofincidents);

            }

        }


        public void AddIncident()
        {
            _events.PublishOnUIThread(new AddIncidentEvent());
        }










    }
    }

