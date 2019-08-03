using Caliburn.Micro;
using NetworkApp.Library.Api;
using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace NetworkApp.ViewModels
{
    public class IncidentViewModel : Screen
    {
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
        public BindableCollection<UIIncidentModel> dataincident { get; set; }
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
            //await PostIncidents();
            Prog = false;
            Load = true;

        }


        private async Task  LoadIncidents ()
        {
            
            var listofincidents = await _incidentEndPoint.GetAllIncident();
            dataincident =new BindableCollection<UIIncidentModel>(listofincidents);
            NotifyOfPropertyChange(() => dataincident);
            
        }
        
        public void Delete(UIIncidentModel incident)
        {
            //delete incident
            var u = IoC.Get<DeleteIncidentViewModel>();
            u.ID = incident.Id;
            var result = _window.ShowDialog(u ,null, null);
            if (result.HasValue && result.Value)
            {
                dataincident.Remove(incident);
            }
            
        }

        
        
        public void Edit(UIIncidentModel incident)
        {
           //edit incident

        }



        private async Task PostIncidents()
        {

           await _incidentEndPoint.AddIncident(new UIIncidentModel {

               IncidentDate = DateTime.Now,
                Direction = "add the incident",
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

