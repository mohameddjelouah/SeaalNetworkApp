using NetworkApi.Library.DataAccess;
using NetworkApi.Library.Models.ListDesSiteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NetworkApi.Controllers
{
    public class AddSiteController : ApiController
    {
        // GET: api/AddSite
        public async Task<AddSiteDataModel> Get()
        {
            ListDeSiteData data = new ListDeSiteData();

            AddSiteDataModel SiteData = new AddSiteDataModel()
            {

                Directions = await data.GetAllDirections(),
                Operateurs = await data.GetOperateur(),
                Equipements = await data.GetEquipements(),
                DhcpServers = await data.GetDhcp()
            };
            return SiteData;
        }

        
    }
}
