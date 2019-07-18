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

        public IncidentModel GetIncidentById(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new { Id = id };
            var output = sql.LoadData<IncidentModel,dynamic>("dbo.spGetIncidentById", p, "SeaalNetworkDB").First();

            return output;
        }

       
    }
}
