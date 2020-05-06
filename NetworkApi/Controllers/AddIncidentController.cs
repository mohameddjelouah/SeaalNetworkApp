using NetworkApi.Library.Models;
using NetworkApi.Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NetworkApi.Controllers
{
    public class AddIncidentController : ApiController
    {
        // GET: api/AddIncident
        public async Task<AddIncidentModel> Get()
        {
            IncidentData data = new IncidentData();

            AddIncidentModel IncidentData = new AddIncidentModel
            {

                Directions = await data.GetAllDirections(),
                Natures = await data.GetNature(),
                Origins = await data.GetOrigin(),
                Operateurs = await data.GetOperateur()
            };
            return IncidentData;
        }

        // GET: api/AddIncident/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AddIncident
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AddIncident/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AddIncident/5
        public void Delete(int id)
        {
        }
    }
}
