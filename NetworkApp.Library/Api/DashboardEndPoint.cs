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
    public class DashboardEndPoint : IDashboardEndPoint
    {




        private IAPIHelper _apiHelper;
        public DashboardEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<DashboardModel> GetDashboard()
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/Dashboard"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<DashboardModel>();
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
