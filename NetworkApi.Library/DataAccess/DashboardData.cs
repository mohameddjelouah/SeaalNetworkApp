using NetworkApi.Library.Internal.DataAccess;
using NetworkApi.Library.Models;
using NetworkApi.Library.Models.DashboardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApi.Library.DataAccess
{
    public class DashboardData
    {

        public  async Task<DashboardModel> GetDashboard()
        {
            SqlDataAccess sql = new SqlDataAccess();
            
            List<IncidentChartModel> IncidentDashboard = await sql.LoadData<IncidentChartModel,dynamic>("dbo.spGetIncidentCountLastYear", new { }, "SeaalNetworkDB");
            DashboardModel dashboard = new DashboardModel()
            {
                IncidentChart = IncidentDashboard
            };
            return dashboard;





        }
    }
}
