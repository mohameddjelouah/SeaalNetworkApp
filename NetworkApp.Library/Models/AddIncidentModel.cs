using NetworkApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Models
{
    public class AddIncidentModel
    {

        public List<DirectionModel> Directions { get; set; }
        public List<NatureModel> Natures { get; set; }
        public List<OperateurModel> Operateurs { get; set; }
        public List<OriginModel> Origins { get; set; }
}
}
