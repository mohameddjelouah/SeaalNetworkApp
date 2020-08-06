using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Models.ListDesSiteModels
{
    public class StoreSiteDetail
    {
        public int Id { get; set; }
        public int DirectionId { get; set; }
        public int SiteId { get; set; }
        public string Address { get; set; }
        public string Mask { get; set; }
        public int DhcpId { get; set; }
    }
}
