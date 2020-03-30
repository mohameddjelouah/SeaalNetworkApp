using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Models
{
    public class StoreIncidentModel
    {

        public int Id { get; set; }
        public DateTime? IncidentDate { get; set; }
        public int Direction { get; set; }
        public int Site { get; set; }
        public int Nature { get; set; }
        public int Origin { get; set; }
        public int? Operateur { get; set; }
        public bool isClotured { get; set; }
        public string Solution { get; set; }
        public DateTime? ClotureDate { get; set; }
        public string AddBy { get; set; }
    }
}
