using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApi.Library.Models.InterventionModels
{
    public class InterventionModel
    {
        public int Id { get; set; }
        public DateTime? InterventionDate { get; set; }
        public SelectedDirectionModel Direction { get; set; }
        public SiteModel Site { get; set; }
        public IdentificationModel Identification { get; set; }
        public EquipementModel Equipement { get; set; }
        public ActionModel Action { get; set; }
        public string Rapport { get; set; }
        public string AddBy { get; set; }




    }
}
