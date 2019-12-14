using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models;

namespace NetworkApp.ViewModels
{
    public class IncidentClotureViewModel : Screen
    {

        private IncidentModel _incident = new IncidentModel();

        public IncidentModel Incident
        {
            get { return _incident; }
            set
            {
                _incident = value;

                NotifyOfPropertyChange(() => Incident);

            }
        }

        private bool _isCloture = false;

        public bool isCloture
        {
            get { return _isCloture; }
            set
            {
                _isCloture = value;
                NotifyOfPropertyChange(() => isCloture);
            }
        }

        private string _Solution;

        public string Solution
        {
            get { return _Solution; }
            set
            {
                _Solution = value;
                NotifyOfPropertyChange(() => Solution);
                NotifyOfPropertyChange(() => CanCloturer);
            }
        }

        private DateTime? _ClotureDate = null;

        public DateTime? ClotureDate
        {
            get { return _ClotureDate; }
            set
            {

                _ClotureDate = value;
                NotifyOfPropertyChange(() => ClotureDate);
                NotifyOfPropertyChange(() => CanCloturer);
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
        
        private IIncidentEndPoint _incidentEndPoint;
        public IncidentClotureViewModel( IWindowManager window, IIncidentEndPoint incidentEndPoint)
        {

            _incidentEndPoint = incidentEndPoint;
            _window = window;

        }


        public bool CanCloturer
        {
            get
            {


                return CheckInputs();


            }

        }

        public async Task Cloturer()
        {
            var Confirme = IoC.Get<DeleteIncidentViewModel>();
            Transition = true;
            var result = _window.ShowDialog(Confirme, null, null);
            Transition = false;
            if (result.HasValue && result.Value)
            {
                
                Incident.Solution = Solution;
                Incident.ClotureDate = ClotureDate;
                Incident.isClotured = true;
                await _incidentEndPoint.EditIncident(Incident);
                isCloture = true;

            }
        }

        public bool CheckInputs()
        {

            if ( !string.IsNullOrEmpty(Solution) && ClotureDate != null)
            {

                    return true;

            }
            return false;
        }

        public void ExitApplication()
        {
            TryClose();
        }
    }
}
