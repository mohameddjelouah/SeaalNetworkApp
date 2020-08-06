using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApi.Library.Models.ListDesSiteModels
{
    public class StoreSiteEquipementModel
    {

        public int Id { get; set; }
        public int SiteId { get; set; }
        public int EquipementId { get; set; }
        public string EquipementHostname { get; set; }
        public string EquipementIp { get; set; }
        
    }
}
