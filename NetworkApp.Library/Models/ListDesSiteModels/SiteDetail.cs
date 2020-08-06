using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Models.ListDesSiteModels
{
    public class SiteDetail
    {
        public int Id { get; set; }
        public SelectedDirectionModel Direction { get; set; }
        public SiteModel Site { get; set; }
        public string Address { get; set; }
        public string Mask { get; set; }
        public DhcpModel Dhcp { get; set; }
    }
}
