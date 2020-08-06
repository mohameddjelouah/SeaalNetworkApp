using NetworkApi.Library.Models.InterventionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApi.Library.Models.ListDesSiteModels
{
    public class SiteEquipementModel
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public EquipementModel Equipement { get; set; }
        public string EquipementHostname { get; set; }
        public string EquipementIp { get; set; }
        public int EquipementId { get { return Equipement.Id; } }
    }
}
