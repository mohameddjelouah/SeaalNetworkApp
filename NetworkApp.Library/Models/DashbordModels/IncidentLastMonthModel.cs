using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Models.DashbordModels
{
    public class IncidentLastMonthModel
    {
        public int IncidentLastMonth { get; set; }
        public int IncidentLastMonthCloturer { get; set; }
        public int IncidentLastMonthNonCloturer { get; set; }
        public string Cloture { get { return "(" + (Math.Round(IncidentLastMonthCloturer * 100.0 / IncidentLastMonth)).ToString() + "%)"; } }
        public string NonCloture { get { return "(" + (Math.Round(IncidentLastMonthNonCloturer * 100.0 / IncidentLastMonth)).ToString() + "%)"; } }
    }
}
