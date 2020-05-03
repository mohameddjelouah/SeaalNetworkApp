using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Models.DashbordModels
{
    public class IncidentThisYearModel
    {
        public int IncidentThisYear { get; set; }
        public int IncidentThisYearCloturer { get; set; }
        public int IncidentThisYearNonCloturer { get; set; }
        public string Cloture { get { return "(" + (Math.Round(IncidentThisYearCloturer * 100.0 / IncidentThisYear) ).ToString() + "%)"; } }
        public string NonCloture { get { return "(" + (Math.Round(IncidentThisYearNonCloturer * 100.0 / IncidentThisYear)).ToString() + "%)"; } }
    }
}
