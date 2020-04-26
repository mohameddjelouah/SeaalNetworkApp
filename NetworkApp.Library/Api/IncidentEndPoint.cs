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

        public async Task<List<IncidentModel>> GetAllIncident(bool isCloture)
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/Incident/{isCloture}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<IncidentModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);

                }
            }


        }
        //***********************************************************************************************************
        public async Task<IncidentModel> GetIncident(int id)
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/Incident/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<IncidentModel>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);

                }
            }


        }

        //*********************************************************************************************************************

        
        //----------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------
        public async Task AddIncident(StoreIncidentModel incident)
        {


            HttpResponseMessage response = null;

            try
            {
                response = await _apiHelper.ApiClient.PostAsJsonAsync($"api/Incident", incident);     
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (response != null)
                {
                    response.Dispose();
                }
            }


        }

        //*********************************************************************************************************************

        public async Task DeleteIncident(int id)
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.DeleteAsync($"api/Incident/{id}"))
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


        //*********************************************************************************************************************

        public async Task EditIncident(StoreIncidentModel incident)
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PutAsJsonAsync($"api/Incident/{incident.Id}", incident))
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
