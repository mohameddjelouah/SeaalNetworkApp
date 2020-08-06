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
    public class SiteController : ApiController
    {
        // GET: api/Site
        public async Task<List<FullSiteModel>> Get()
        {
            ListDeSiteData Sitedata = new ListDeSiteData();
            return await Sitedata.GetAllSites();
        }

        //GET: api/Site/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Site
        public async Task Post([FromBody]StoreFullSiteModel site)
        {
            ListDeSiteData Sitedata = new ListDeSiteData();

            await Sitedata.AddSite(site);
        }

        // PUT: api/Site/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Site/5
        public void Delete(int id)
        {
        }
    }
}
