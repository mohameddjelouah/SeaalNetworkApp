using NetworkApi.Library.Models.InterventionModels;
using NetworkApi.Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace NetworkApi.Controllers
{
    public class AddInterventionController : ApiController
    {
        // GET: api/AddIntervention
        public async Task<AddInterventionModel> Get()
        {
            InterventionData data = new InterventionData();

            AddInterventionModel InterventionData = new AddInterventionModel
            {

                Directions = await data.GetAllDirections(),
                 Identifications = await data.GetIdentifications(),
                Equipements = await data.GetEquipements(),
                Actions = await data.GetActions()
            };
            return InterventionData;
        }

        // GET: api/AddIntervention/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AddIntervention
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AddIntervention/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AddIntervention/5
        public void Delete(int id)
        {
        }
    }
}
