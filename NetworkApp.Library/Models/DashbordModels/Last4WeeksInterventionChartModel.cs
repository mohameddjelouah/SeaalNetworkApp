using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Models.DashbordModels
{
    public class Last4WeeksInterventionChartModel
    {
        public DateTime? Weekdebut { get; set; }
        public DateTime? Weekend { get; set; }
        public string Join { get { return Weekdebut?.ToString("dd/MMM") + " " + Weekend?.ToString("dd/MMM"); } }
        public int _4WeeksInterventionCount { get; set; }
    }
}
