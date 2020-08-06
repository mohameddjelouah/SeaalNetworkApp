using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Models.ListDesSiteModels
{
    public class SiteOperateurModel
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public OperateurModel Operateur { get; set; }
        public string Display { get { return Operateur.Operateur; } }
    }
}
