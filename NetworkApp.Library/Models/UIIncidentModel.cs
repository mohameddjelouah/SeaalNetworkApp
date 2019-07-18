﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Models
{
    public class UIIncidentModel
    {

        public int Id { get; set; }
        public DateTime IncidentDate { get; set; }
        public string Direction { get; set; }
        public string Site { get; set; }
        public string Nature { get; set; }
        public string Operateur { get; set; }
        public int isClotured { get; set; }
        public string Solution { get; set; }
        public DateTime ClotureDate { get; set; }
        public string AddBy { get; set; }

    }
}