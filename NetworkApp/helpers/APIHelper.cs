using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace NetworkApp.helpers
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
    }

}
