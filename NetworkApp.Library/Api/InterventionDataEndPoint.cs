using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models;
using NetworkApp.Library.Models.InterventionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Api
{
    public class InterventionDataEndPoint : IInterventionDataEndPoint
    {

        private IAPIHelper _apiHelper;
        public InterventionDataEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<AddInterventionModel> GetInterventionData()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/AddIntervention"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AddInterventionModel>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);

                }
            }
        }
    }
}
