using Caliburn.Micro;
using NetworkApp.Helper;
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
using System.Windows.Input;

namespace NetworkApp.ViewModels
{
    public class IncidentViewModel : Screen
    {
        public BindableCollection<UIIncidentModel> dataincident { get; set; }

        private UIIncidentModel _selectedIncident;
        
        private RelayCommand<dynamic> _commandStart;

        public UIIncidentModel SelectedIncident
        {
            get { return _selectedIncident; }
            set {
                _selectedIncident = value;

            }
        }




        private IIncidentEndPoint _incidentEndPoint;

        public IncidentViewModel(IIncidentEndPoint incidentEndPoint)
        {
            _incidentEndPoint = incidentEndPoint;

           

        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadIncidents();
            //await PostIncidents();
        }


        private async Task  LoadIncidents ()
        {
            
            var listofincidents = await _incidentEndPoint.GetAllIncident();
            dataincident =new BindableCollection<UIIncidentModel>(listofincidents);
            NotifyOfPropertyChange(() => dataincident);
            
        }
        public ICommand deleteIncident
        {


            get
                 {
                if (_commandStart == null)
                {

                    _commandStart = new RelayCommand<dynamic>(param => delete());
                }
                return _commandStart;
            }

        }
        public void delete()
        {
            
            Console.WriteLine(SelectedIncident.Id.ToString());
        }

        public void edit()
        {
            Console.WriteLine(SelectedIncident.Id.ToString());
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

