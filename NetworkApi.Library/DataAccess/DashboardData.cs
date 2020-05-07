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
            SqlDataAccess  sql = new SqlDataAccess();
            DashboardModel Dashboard = await sql.LoadDashboard("dbo.spGetDashboardData", "SeaalNetworkDB");
                           Dashboard.IncidentChart = await sql.LoadData<IncidentChartModel, dynamic>("dbo.spGetIncidentCountLastYear", new { }, "SeaalNetworkDB");
                           Dashboard.Last4WeeksChart = await sql.LoadData<Last4WeeksChartModel, dynamic>("dbo.spGetIncidentForLast4Weeks", new { }, "SeaalNetworkDB");
                           Dashboard.Last4WeeksInterventionChart = await sql.LoadData<Last4WeeksInterventionChartModel, dynamic>("dbo.spGetInterventionForLast4Weeks", new { }, "SeaalNetworkDB");
                    return Dashboard;





        }
    }
}
