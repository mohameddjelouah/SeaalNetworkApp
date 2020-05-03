using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApi.Library.Models.DashboardModels
{
    public class IncidentThisYearModel
    {
        public int IncidentThisYear { get; set; }
        public int IncidentThisYearCloturer { get; set; }
        public int IncidentThisYearNonCloturer { get; set; }
    }
}
