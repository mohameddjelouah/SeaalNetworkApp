using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using NetworkApp.Library.Models;

namespace NetworkApp.Library.Api
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient apiClient;

        public APIHelper()
        {
            InitializeClient();
        }
        private void InitializeClient()
        {
            apiClient = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true });
            apiClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["api"]);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }

        public async Task<string> authe(int id)
        {

            using (HttpResponseMessage response = await apiClient.GetAsync($"api/Values/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<string>();
                    return result;
                }
                else
                {
                    return new Exception(response.ReasonPhrase).ToString();
                    
                }
            }


        }

        public async Task<UIIncidentModel> GetIncident(int id)
        {

            using (HttpResponseMessage response = await apiClient.GetAsync($"api/Incident/{id}"))
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


        public async Task<List<UIIncidentModel>> GetAllIncident()
        {

            using (HttpResponseMessage response = await apiClient.GetAsync($"api/Incident"))
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
    }

}
