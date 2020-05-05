using NetworkApi.Library.DataAccess;
using NetworkApi.Library.Models;
using NetworkApi.Library.Models.InterventionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Http;

namespace NetworkApi.Controllers
{
    [Authorize]
    public class IncidentController : ApiController
    {




        // GET: api/Incident
        [HttpGet]
        [Route("api/Incident/{isCloture}")]
        public async Task<List<PostIncidentModel>>  Get(bool isCloture)
        {
            IncidentData data = new IncidentData();
            return await data.GetAllIncidents(isCloture);
        }
        // POST api/Incident
        [HttpPost]
        [Route("api/Incident")]
        public async Task Post([FromBody] StoreIncidentModel incident)
        {           
            IncidentData data = new IncidentData();
            await data.AddIncident(incident);          
        }

        // DELETE api/Incident/5
        [HttpDelete]
        [Route("api/Incident/{id}")]
        public async Task Delete(int id)
        {
            IncidentData data = new IncidentData();
            await data.DeleteIncident(id);

        }
        // PUT api/Incident/5
        [HttpPut]
        [Route("api/Incident/{id}")]
        public async Task Put(int id, [FromBody]StoreIncidentModel incident)
        {

            IncidentData data = new IncidentData();
            await data.EditIncident(incident);


        }


    }
}
