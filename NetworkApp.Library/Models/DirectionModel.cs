using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Models
{
    public class DirectionModel
    {
        public int Id { get; set; }
        public string Direction { get; set; }
        public List<SiteModel> Sites { get; set; } 

    }
}
