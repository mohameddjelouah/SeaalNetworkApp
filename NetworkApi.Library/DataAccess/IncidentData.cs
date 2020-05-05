using NetworkApi.Library.Internal.DataAccess;
using NetworkApi.Library.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Newtonsoft.Json;

namespace NetworkApi.Library.DataAccess
{
    public class IncidentData
    {
        public async Task<List<PostIncidentModel>>   GetAllIncidents(bool isCloture)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new { isClotured = isCloture };
            List<PostIncidentModel> listofIncidents = await sql.LoadAllIncidents("dbo.spGetAllIncidents", p, "SeaalNetworkDB");
            return listofIncidents;          
        }

        public async Task<List<DirectionModel>>  GetAllDirections()
        {
            SqlDataAccess sql = new SqlDataAccess();
            var Directions = await sql.LoadDirections("dbo.spGettAllDirections",  "SeaalNetworkDB");
            return Directions;
        }

        public async Task<List<NatureModel>>  GetNature()
        {
            SqlDataAccess sql = new SqlDataAccess();
            var Nature =await sql.LoadData<NatureModel, dynamic>("dbo.spGetNature", new { }, "SeaalNetworkDB");        
            return Nature;
        }

        public async Task<List<OriginModel>>  GetOrigin()
        {
            SqlDataAccess sql = new SqlDataAccess();
            var Origin = await sql.LoadData<OriginModel, dynamic>("dbo.spGetOrigin", new { }, "SeaalNetworkDB");
            return Origin;
        }

        public async Task<List<OperateurModel>>  GetOperateur()
        {
            SqlDataAccess sql = new SqlDataAccess();
            var Operateur = await sql.LoadData<OperateurModel, dynamic>("dbo.spGetOperateur", new { }, "SeaalNetworkDB");
            return Operateur;
        }

        public async Task AddIncident(StoreIncidentModel incident)
        {                      
            SqlDataAccess sql = new SqlDataAccess();
            await sql.SaveData("dbo.spInsertIncident", incident, "SeaalNetworkDB");
        }

        public async Task DeleteIncident(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new { Id = id };
            await sql.DeleteData("dbo.spDeleteIncident", p, "SeaalNetworkDB");
        }

        public async Task EditIncident(StoreIncidentModel incident)
        {
            SqlDataAccess sql = new SqlDataAccess();          
            await sql.SaveData("dbo.spEditIncident", incident, "SeaalNetworkDB");
        }

       
    }
}
