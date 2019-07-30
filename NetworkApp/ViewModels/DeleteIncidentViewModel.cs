using Caliburn.Micro;
using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.ViewModels
{
    public class DeleteIncidentViewModel : Screen
    {

        private IIncidentEndPoint _incidentEndPoint;

        private int Id;

        public int ID
        {
            get { return Id; }
            set { Id = value;

                NotifyOfPropertyChange(() => ID);
            }
        }


        //private UIIncidentModel _incident;
        //public UIIncidentModel incident
        //{
        //    get { return _incident; }
        //    set {
        //        _incident = value;
                
        //        NotifyOfPropertyChange(() => incident);
        //        ;
        //    }
        //}

       
        public DeleteIncidentViewModel(IIncidentEndPoint incidentEndPoint)
        {
            //Console.WriteLine(oincident.Id.ToString());
            _incidentEndPoint = incidentEndPoint;
        }

        public async Task delete()
        {
           await _incidentEndPoint.DeleteIncident(ID);
            TryClose(true);
        }

        public void cancele()
        {
            TryClose(false);
        }
    }
}
