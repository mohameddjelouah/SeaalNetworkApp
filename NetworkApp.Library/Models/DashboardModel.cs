using NetworkApp.Library.Models.DashbordModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Models
{
    public class DashboardModel
    {
        public List<IncidentChartModel> IncidentChart { get; set; }
        public List<InterventionChartModel> InterventionChart { get; set; }
        public List<Last4WeeksChartModel> Last4WeeksChart { get; set; }
        public List<Last4WeeksInterventionChartModel> Last4WeeksInterventionChart { get; set; }
        public IncidentTotalModel IncidentTotal { get; set; }
        public IncidentThisYearModel IncidentThisYear { get; set; }
        public IncidentThisMonthModel IncidentThisMonth { get; set; }
        public IncidentLastYearModel IncidentLastYear { get; set; }
        public IncidentLastMonthModel IncidentLastMonth { get; set; }
        public int IncidentYesterday { get; set; }
        public InterventionDataModel InterventionData { get; set; }
        public int Sites { get; set; }
    }
}
