using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diplodocus.Models
{
    public abstract class Examen
    {
        // "m_" == données membres
        protected string examName { get; set; }
        protected string examType { get; set; }
        protected float noteExam { get; set; }

        protected Examen(string examName, string examType, float noteExam)
        {
            this.examName = examName;
            this.examType = examType;
            this.noteExam = noteExam;
        }
        
        protected abstract string ToString();

    }
}