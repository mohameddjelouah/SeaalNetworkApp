using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApi.Library.Models.DashboardModels
{
    public class IncidentLastMonthModel
    {
        public int IncidentLastMonth { get; set; }
        public int IncidentLastMonthCloturer { get; set; }
        public int IncidentLastMonthNonCloturer { get; set; }
    }
}
