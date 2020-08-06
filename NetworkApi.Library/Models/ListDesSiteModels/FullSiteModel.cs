using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApi.Library.Models.ListDesSiteModels
{
    public class FullSiteModel
    {
        public SiteDetail Detail { get; set; }
        public List<SiteEquipementModel> SiteEquipements { get; set; }
        public List<SiteOperateurModel> SiteOperateurs { get; set; }
    
    
    
    
    }



}
