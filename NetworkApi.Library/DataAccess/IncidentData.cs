using NetworkApi.Library.Internal.DataAccess;
using NetworkApi.Library.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace NetworkApi.Library.DataAccess
{
    public class IncidentData
    {
        public List<IncidentModel>  GetAllIncidents()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<IncidentModel, dynamic>("dbo.spGetAllIncidents", new { }, "SeaalNetworkDB");

            return output;
        }


        public List<DirectionModel> GetAllDirections()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var Directions = sql.LoadData<DirectionModel, dynamic>("dbo.spGettAllDirections", new { }, "SeaalNetworkDB");

            foreach (var item in Directions)
            {
                var directionID = new { directionID = item.Id };
                var Sites = sql.LoadData<SiteModel, dynamic>("dbo.spGetSitesByDirectionId", directionID , "SeaalNetworkDB");
                item.Sites = Sites;
            }

            return Directions;
        }

        public IncidentModel GetIncidentById(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new { Id = id };
            var output = sql.LoadData<IncidentModel,dynamic>("dbo.spGetIncidentById", p, "SeaalNetworkDB").FirstOrDefault();

            return output;
        }

        //add incident to the database

        public void AddIncident(IncidentModel incident)
        {
            //add the incident to the database
            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveData("dbo.spInsertIncident", incident, "SeaalNetworkDB");
        }

        public void DeleteIncident(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new { Id = id };
            sql.DeleteData("dbo.spDeleteIncident", p, "SeaalNetworkDB");
        }

       
    }
}
