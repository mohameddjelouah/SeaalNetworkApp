using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models.InterventionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Api
{
    public class InterventionEndPoint : IInterventionEndPoint
    {
        private IAPIHelper _apiHelper;
        public InterventionEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<List<InterventionModel>> GetAllIntervention()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/Intervention"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<InterventionModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);

                }
            }
        }

        public async Task AddIntervention(StoreInterventionModel intervention)
        {

            HttpResponseMessage response = null;

            try
            {
                response = await _apiHelper.ApiClient.PostAsJsonAsync($"api/Intervention", intervention);
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
    }
}
