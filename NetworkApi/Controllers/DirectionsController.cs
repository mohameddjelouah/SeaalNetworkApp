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
    public class DirectionsController : ApiController
    {
        // GET: api/Directions
        public AddIncidentModel Get()
        {
            IncidentData data = new IncidentData();
            AddIncidentModel IncidentData = new AddIncidentModel
            {

                Directions = data.GetAllDirections(),
                Natures = data.GetNature(),
                Origins = data.GetOrigin(),
                Operateurs = data.GetOperateur()
            };
            return IncidentData;
        }

        // GET: api/Directions/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Directions
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Directions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Directions/5
        public void Delete(int id)
        {
        }
    }
}
