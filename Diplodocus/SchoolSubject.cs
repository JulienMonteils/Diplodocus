//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplodocus
{
    using System;
    using System.Collections.Generic;
    
    public partial class SchoolSubject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SchoolSubject()
        {
            this.aStudentMarkSubjects = new HashSet<StudentMarkSubject>();
        }
    
        public int idSubject { get; set; }
        public string subjectName { get; set; }
        public int GradeIdGrade { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentMarkSubject> aStudentMarkSubjects { get; set; }
        public virtual Grade aGrade { get; set; }
    }
}