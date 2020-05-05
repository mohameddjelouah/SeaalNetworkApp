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
        public string Cloture { get { return "(" + (Math.Round(IncidentThisMonthCloturer * 100.0 / IncidentThisMonth)).ToString() + "%)"; } }
        public string NonCloture { get { return "(" + (Math.Round(IncidentThisMonthNonCloturer * 100.0 / IncidentThisMonth)).ToString() + "%)"; } }
        public string IncidentThisMonthText { get { return "Incident En " + DateTime.Now.ToString("MMMM"); } }
    }
}
