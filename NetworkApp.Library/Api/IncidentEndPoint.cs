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
    public class IncidentEndPoint : IIncidentEndPoint
    {
        private IAPIHelper _apiHelper;
        public IncidentEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<UIIncidentModel>> GetAllIncident()
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/Incident"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<UIIncidentModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);

                }
            }


        }
        //***********************************************************************************************************
        public async Task<UIIncidentModel> GetIncident(int id)
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/Incident/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<UIIncidentModel>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);

                }
            }


        }

        //*********************************************************************************************************************

        public async Task AddIncident(UIIncidentModel incident)
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync($"api/Incident",incident))
            {
                if (response.IsSuccessStatusCode)
                {
                    
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);

                }
            }


        }


    }
}
