using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Models.InterventionModels
{
    public class StoreInterventionModel
    {
        public DateTime? InterventionDate { get; set; }
        public int DirectionId { get; set; }
        public int SiteId { get; set; }
        public int IdentificationId { get; set; }
        public int EquipemenetId { get; set; }
        public int ActionId { get; set; }
        public string Rapport { get; set; }
        public string AddBy { get; set; }
    }
}
