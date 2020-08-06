using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models.InterventionModels;
using NetworkApp.Library.Models.ListDesSiteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Api
{
    public class SiteDataEndPoint : ISiteDataEndPoint
    {

        private IAPIHelper _apiHelper;
        public SiteDataEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }




        public async Task<AddSiteDataModel> GetSiteData()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/AddSite"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AddSiteDataModel>();
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
