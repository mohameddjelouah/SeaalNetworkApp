using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Api
{
    public class IncidentDataEndPoint : IIncidentDataEndPoint
    {

        private IAPIHelper _apiHelper;
        public IncidentDataEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<AddIncidentModel> GetIncidentData()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/Directions"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AddIncidentModel>();
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
