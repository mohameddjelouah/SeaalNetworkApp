using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Models.DashbordModels
{
    public class IncidentTotalModel
    {
        public int IncidentTotal { get; set; }
        public int IncidentTotalClotorer { get; set; }
        public int IncidentTotalNonClotorer { get; set; }
        public string Cloture { get { return "("+(Math.Round(IncidentTotalClotorer *100.0 / IncidentTotal)).ToString()+"%)"; } }
        public string NonCloture { get { return "("+(Math.Round(IncidentTotalNonClotorer * 100.0 / IncidentTotal)).ToString() + "%)"; } }
        
    }
}
