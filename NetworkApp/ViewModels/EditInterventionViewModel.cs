using Caliburn.Micro;
using NetworkApp.Library.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.ViewModels
{
    public class EditInterventionViewModel : Screen
    {

        private IWindowManager _window;
        private IInterventionDataEndPoint _interventionDataEndPoint;
        private IInterventionEndPoint _interventionEndPoint;
        public EditInterventionViewModel(IWindowManager window, IInterventionDataEndPoint interventionDataEndPoint, IInterventionEndPoint interventionEndPoint)
        {
            _window = window;
            _interventionDataEndPoint = interventionDataEndPoint;
            _interventionEndPoint = interventionEndPoint;
        }
    }
}
