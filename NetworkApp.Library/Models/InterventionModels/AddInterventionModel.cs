using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Models.InterventionModels
{
    public class AddInterventionModel
    {

        public List<DirectionModel> Directions { get; set; }
        public List<IdentificationModel> Identifications { get; set; }
        public List<EquipementModel> Equipements { get; set; }
        public List<ActionModel> Actions { get; set; }
        

    }
}
