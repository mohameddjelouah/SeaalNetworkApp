using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApi.Library.Models.DashboardModels
{
    public class InterventionDataModel
    {
        public int InterventionTotal { get; set; }
        public int InterventionThisYear { get; set; }
        public int InterventionThisMonth { get; set; }
        public int InterventionLastYear { get; set; }
        public int InterventionLastMonth { get; set; }
        public int InterventionYesterday { get; set; }
    }
}
