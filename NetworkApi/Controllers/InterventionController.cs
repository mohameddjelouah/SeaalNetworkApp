using NetworkApi.Library.DataAccess;
using NetworkApi.Library.Models.InterventionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NetworkApi.Controllers
{
    public class InterventionController : ApiController
    {
        // GET: api/Intervention
        public async Task<List<InterventionModel>> Get()
        {
            InterventionData interventiondata = new InterventionData();
            return await interventiondata.GatAllInterventions();
        }

        
        // POST: api/Intervention
        public async Task Post([FromBody]StoreInterventionModel intervention)
        {
            InterventionData interventiondata = new InterventionData();

            await interventiondata.AddIntervention(intervention);
        }

        // PUT: api/Intervention/5
        public async Task Put(int id, [FromBody]StoreInterventionModel intervention)
        {
            InterventionData interventiondata = new InterventionData();
            await interventiondata.EditIncident(intervention);
        }

        // DELETE: api/Intervention/5
        public async Task Delete(int id)
        {
            InterventionData interventiondata = new InterventionData();
            await interventiondata.DeleteIntervention(id);
        }
    }
}
