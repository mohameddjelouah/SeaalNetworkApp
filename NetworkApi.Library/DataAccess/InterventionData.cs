using NetworkApi.Library.Internal.DataAccess;
using NetworkApi.Library.Models;
using NetworkApi.Library.Models.InterventionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApi.Library.DataAccess
{
    public class InterventionData
    {

        


        public async Task<List<InterventionModel>> GatAllInterventions()
        {
            SqlDataAccess sql = new SqlDataAccess();

            List<InterventionModel> listofInterventions = await sql.LoadAllInterventions("dbo.spGetAllInterventions", "SeaalNetworkDB");

            return listofInterventions;
        }

        public async Task AddIntervention(StoreInterventionModel intervention)
        {
            SqlDataAccess sql = new SqlDataAccess();
            await sql.SaveData("dbo.spInsertIntervention", intervention, "SeaalNetworkDB");
        }

        public async Task DeleteIntervention(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new { Id = id };
            await sql.DeleteData("dbo.spDeleteIntervention", p, "SeaalNetworkDB");
        }

        public async Task EditIncident(StoreInterventionModel intervention)
        {
            SqlDataAccess sql = new SqlDataAccess();            
            await sql.SaveData("dbo.spEditIntervention", intervention, "SeaalNetworkDB");

        }


        
    }
}
