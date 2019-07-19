using NetworkApi.Library.DataAccess;
using NetworkApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NetworkApi.Controllers
{
    [Authorize]
    public class IncidentController : ApiController
    {




        // GET: api/Incident
        public List<IncidentModel> Get()
        {
            IncidentData data = new IncidentData();

            return data.GetAllIncidents();
        }


        // GET: api/Incident/5
        public IncidentModel Get(int id)
        {
            IncidentData data = new IncidentData();

            return data.GetIncidentById(id);

            
        }

        // POST api/Incident
        public void Post([FromBody] IncidentModel incident)
        {
            // we have to use auto mapper to use it with mapping IncidentModel in the library with the post incident model in the âpi
            IncidentData data = new IncidentData();

            data.AddIncident(incident);


        }


    }
}
