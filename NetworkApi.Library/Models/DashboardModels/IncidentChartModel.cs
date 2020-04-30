using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApi.Library.Models.DashboardModels
{
    public class IncidentChartModel
    {
        public DateTime IncidentsDate { get; set; }
        
        public int IncidentCount { get; set; }
    }
}
