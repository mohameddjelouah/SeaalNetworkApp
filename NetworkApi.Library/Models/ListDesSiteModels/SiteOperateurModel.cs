using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper.Contrib.Extensions;

namespace NetworkApi.Library.Models.ListDesSiteModels
{
    public class SiteOperateurModel
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public int OperateurId { get { return Operateur.Id; } }
        public OperateurModel Operateur { get; set; }
        
    }
}
