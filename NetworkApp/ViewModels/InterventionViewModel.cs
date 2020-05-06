using Caliburn.Micro;
using NetworkApp.Library.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.ViewModels
{
    public class InterventionViewModel : Screen
    {

        private IInterventionEndPoint _interventionEndPoint;

        private IWindowManager _window;
        public InterventionViewModel(IInterventionEndPoint interventionEndPoint, IWindowManager window)
        {
            _interventionEndPoint = interventionEndPoint;
            _window = window;
        }


        protected override async void OnViewLoaded(object view)
        { // if loading incuident doesnt work we caatch an exception that stop progress bar and display a message with failure
            base.OnViewLoaded(view);
            var p = await _interventionEndPoint.GetAllIntervention();
        }
    }
}
