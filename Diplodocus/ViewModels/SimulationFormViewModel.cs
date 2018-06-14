using Diplodocus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplodocus.ViewModels
{
    public class SimulationFormViewModel
    {
        public Student Student { get; set; }
        public Grade Grade { get; set; }
        public IEnumerable<SchoolSubject> SchoolSubjects { get; set; }
        public List<SchoolSubjectMark> SchoolSubjectMarks { get; set; }
        public List<int> Notes { get; set; }
        public Dictionary<SchoolSubject, int> TestNotes { get; set; }
        public List<SchoolSubject> MatieresRattrapage { get; set; }
    }
}