using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models.ListDesSiteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Api
{
    public class SiteEndPoint : ISiteEndPoint
    {

        private IAPIHelper _apiHelper;
        public SiteEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }



        public async Task<List<FullSiteModel>> GetAllSites()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/Site"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<FullSiteModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);

                }
            }
        }

        public async Task AddSite(StoreFullSiteModel site)
        {

            HttpResponseMessage response = null;

            try
            {
                response = await _apiHelper.ApiClient.PostAsJsonAsync($"api/Site", site);
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

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------delete site --------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------

        public async Task DeleteSite(int id)
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.DeleteAsync($"api/Site/{id}"))
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


        //---------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------edit site ------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------

        public async Task EditSite(StoreFullSiteModel site)
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PutAsJsonAsync($"api/Site/{site.SiteDetail.Id}", site))
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
