using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApi.Library.Models.DashboardModels
{
    public class IncidentTotalModel
    {
        public int IncidentTotal { get; set; }
        public int IncidentTotalClotorer { get; set; }
        public int IncidentTotalNonClotorer { get; set; }
    }
}
