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
        private HttpClient _apiClient;

        public APIHelper()
        {
            InitializeClient();
        }

        public HttpClient ApiClient
        {
            get
            {
                return _apiClient;
            }
            
        }

        private void InitializeClient()
        {
            _apiClient = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true });
            _apiClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["api"]);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }
        //this is a test methode to talk to the api
        public async Task<string> authe(int id)
        {

            using (HttpResponseMessage response = await _apiClient.GetAsync($"api/Values/{id}"))
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
