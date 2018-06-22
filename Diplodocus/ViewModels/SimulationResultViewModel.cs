using Diplodocus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplodocus.ViewModels
{
    public class SimulationResultViewModel
    {
        public Student Student { get; set; }
        public double Moyenne { get; set; }
        public double MoyenneS1 { get; set; }
        public double MoyenneS2 { get; set; }
        public Grade Grade { get; set; }
        public IEnumerable<SchoolSubject> Subjects { get; set; }
        public Dictionary<SchoolSubject, double> LesNotes { get; set; }
        public List<SchoolSubject> matieresRattrapage { get; set; }
        //public RattrapageViewModel RattrapageVM { get; set; }
    }
}