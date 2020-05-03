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
            List<Last4WeeksChartModel> Last4Weeks = await sql.LoadData<Last4WeeksChartModel, dynamic>("dbo.spGetLast4Weeks", new { }, "SeaalNetworkDB");
            DashboardModel dashboard = new DashboardModel()
            {
                IncidentChart = IncidentDashboard,
                Last4WeeksChart = Last4Weeks
                
            };
            return dashboard;





        }
    }
}
