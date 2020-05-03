using NetworkApi.Library.Models.DashboardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApi.Library.Models
{
    public class DashboardModel
    {
        public List<IncidentChartModel> IncidentChart { get; set; }
        public List<Last4WeeksChartModel> Last4WeeksChart { get; set; }
    }
}
