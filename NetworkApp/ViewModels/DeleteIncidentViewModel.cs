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

        


       
       
        public DeleteIncidentViewModel()
        {
            
            
        }

        public void delete()
        {
           
            TryClose(true);
        }

        public void cancele()
        {
            TryClose(false);
        }
    }
}
