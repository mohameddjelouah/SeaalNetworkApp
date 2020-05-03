﻿using NetworkApi.Library.Models.DashboardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApi.Library.Models
{
    public class DashboardModel
    {
        public List<IncidentChartModel> IncidentChart { get; set; }
        public List<Last4WeeksChartModel> Last4WeeksChart { get; set; }
        public IncidentTotalModel IncidentTotal { get; set; }
        public IncidentThisYearModel IncidentThisYear { get; set; }
        public IncidentThisMonthModel IncidentThisMonth { get; set; }
        public IncidentLastYearModel IncidentLastYear { get; set; }
        public IncidentLastMonthModel IncidentLastMonth { get; set; }
        public int IncidentYesterday { get; set; }
        public int Sites { get; set; }
    }
}
