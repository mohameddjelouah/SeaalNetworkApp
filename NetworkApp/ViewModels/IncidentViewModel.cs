using Caliburn.Micro;
using NetworkApp.Library.Api;
using NetworkApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.ViewModels
{
    public class IncidentViewModel : Screen
    {
        public BindableCollection<UIIncidentModel> dataincident { get; set; } 
       


        private IAPIHelper _apiHelper;


        public IncidentViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;

            
        }
        


        public async Task  data ()
        {
            
            var listofincidents = await _apiHelper.GetAllIncident();
            dataincident =new BindableCollection<UIIncidentModel>(listofincidents);
            NotifyOfPropertyChange(() => dataincident);
            
        }
        public async Task loadincident()
        {
            await data();
        }





       /* async public Task<IncidentViewModel> BuildViewModelAsync()
        {
            BindableCollection<UIIncidentModel> tmpData = await data();
            return new IncidentViewModel(tmpData);
        }

        // private constructor called by the async method
        private IncidentViewModel(BindableCollection<UIIncidentModel> Data)
        {
            this.dataincident = Data;
        }*/
    }
}

