using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApi.Library.Models.DashboardModels
{
    public class Last4WeeksInterventionChartModel
    {
        public DateTime? Weekdebut { get; set; }
        public DateTime? Weekend { get; set; }
        public int _4WeeksInterventionCount { get; set; }
    }
}
