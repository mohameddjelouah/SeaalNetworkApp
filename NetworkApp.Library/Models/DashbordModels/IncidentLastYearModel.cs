using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Models.DashbordModels
{
    public class IncidentLastYearModel
    {
        public int IncidentLastYear { get; set; }
        public int IncidentLastYearCloturer { get; set; }
        public int IncidentLastYearNonCloturer { get; set; }
        public string Cloture { get { return "(" + (Math.Round(IncidentLastYearCloturer * 100.0 / IncidentLastYear)).ToString() + "%)"; } }
        public string NonCloture { get { return "(" + (Math.Round(IncidentLastYearNonCloturer * 100.0 / IncidentLastYear)).ToString() + "%)"; } }
        public string IncidentLastYearText { get { return "Incident En " + DateTime.Now.AddYears(-1).ToString("yyyy"); } }
    }
}
