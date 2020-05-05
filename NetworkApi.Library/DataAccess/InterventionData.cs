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

        public async Task<List<DirectionModel>> GetAllDirections()
        {
            SqlDataAccess sql = new SqlDataAccess();
            var Directions = await sql.LoadDirections("dbo.spGettAllDirections", "SeaalNetworkDB");
            return Directions;
        }


        public async Task<List<IdentificationModel>> GetIdentifications()
        {
            SqlDataAccess sql = new SqlDataAccess();
            var Identification = await sql.LoadData<IdentificationModel, dynamic>("dbo.spGetIdentifications", new { }, "SeaalNetworkDB");
            return Identification;
        }

        public async Task<List<EquipementModel>> GetEquipements()
        {
            SqlDataAccess sql = new SqlDataAccess();
            var Equipement = await sql.LoadData<EquipementModel, dynamic>("dbo.spGetEquipements", new { }, "SeaalNetworkDB");
            return Equipement;
        }

        public async Task<List<ActionModel>> GetActions()
        {
            SqlDataAccess sql = new SqlDataAccess();
            var Action = await sql.LoadData<ActionModel, dynamic>("dbo.spGetActions", new { }, "SeaalNetworkDB");
            return Action;
        }

    }
}
