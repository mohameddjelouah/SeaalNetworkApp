using NetworkApi.Library.Models.InterventionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApi.Library.Models.ListDesSiteModels
{
    public class AddSiteDataModel
    {
        public List<DirectionModel> Directions { get; set; }
        public List<DhcpModel> DhcpServers { get; set; }
        public List<OperateurModel> Operateurs { get; set; }
        public List<EquipementModel> Equipements { get; set; }
    }
}
