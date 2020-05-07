using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Models.DashbordModels
{
    public class InterventionDataModel
    {
        public int InterventionTotal { get; set; }
        public string InterventionTotalText { get { return "Intervention Total "; } }

        public int InterventionThisYear { get; set; }
        public string InterventionThisYearText { get { return "Intervention En " + DateTime.Now.ToString("yyyy"); } }

        public int InterventionThisMonth { get; set; }
        public string InterventionThisMonthText { get { return "Intervention En " + DateTime.Now.ToString("MMMM"); } }

        public int InterventionLastYear { get; set; }
        public string InterventionLastYearText { get { return "Intervention En " + DateTime.Now.AddYears(-1).ToString("yyyy"); } }

        public int InterventionLastMonth { get; set; }
        public string InterventionLastMonthText { get { return "Intervention En " + DateTime.Now.AddMonths(-1).ToString("MMMM"); } }

        public int InterventionYesterday { get; set; }
    }
}
