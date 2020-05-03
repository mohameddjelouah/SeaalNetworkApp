using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Models.DashbordModels
{
    public class IncidentThisMonthModel
    {
        public int IncidentThisMonth { get; set; }
        public int IncidentThisMonthCloturer { get; set; }
        public int IncidentThisMonthNonCloturer { get; set; }
    }
}
