﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApi.Library.Models
{
    public class PostIncidentModel
    {
        public int Id { get; set; }
        public DateTime? IncidentDate { get; set; }
        public SelectedDirectionModel Direction { get; set; }
        public SiteModel Site { get; set; }
        public NatureModel Nature { get; set; }
        public OriginModel Origin { get; set; }
        public OperateurModel Operateur { get; set; }
        public bool isClotured { get; set; }
        public string Solution { get; set; }
        public DateTime? ClotureDate { get; set; }
        public string AddBy { get; set; }
    }
}
