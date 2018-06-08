namespace Diplodocus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentMarkSubjects", "aSchoolSubject_IdSubject", "dbo.SchoolSubjects");
            DropForeignKey("dbo.StudentMarkSubjects", "SchoolSubjectMarkIdMark", "dbo.SchoolSubjectMarks");
            DropForeignKey("dbo.StudentMarkSubjects", "unStudent_IdUser", "dbo.Students");
            DropIndex("dbo.StudentMarkSubjects", new[] { "SchoolSubjectMarkIdMark" });
            DropIndex("dbo.StudentMarkSubjects", new[] { "aSchoolSubject_IdSubject" });
            DropIndex("dbo.StudentMarkSubjects", new[] { "unStudent_IdUser" });
            AddColumn("dbo.Grades", "Manager_IdUser", c => c.Int());
            AddColumn("dbo.SchoolSubjects", "SubjectMarkFloor", c => c.Long(nullable: false));
            AddColumn("dbo.SchoolSubjects", "Semester", c => c.Int(nullable: false));
            AddColumn("dbo.SchoolSubjects", "Rattrapable", c => c.Boolean(nullable: false));
            AddColumn("dbo.SchoolSubjectMarks", "Student_IdUser", c => c.Int());
            AddColumn("dbo.SchoolSubjectMarks", "SchoolSubject_IdSubject", c => c.Int());
            AddColumn("dbo.Students", "AddressMail", c => c.String());
            AddColumn("dbo.Students", "Password", c => c.String(nullable: false));
            CreateIndex("dbo.Grades", "Manager_IdUser");
            CreateIndex("dbo.SchoolSubjectMarks", "Student_IdUser");
            CreateIndex("dbo.SchoolSubjectMarks", "SchoolSubject_IdSubject");
            AddForeignKey("dbo.Grades", "Manager_IdUser", "dbo.Managers", "IdUser");
            AddForeignKey("dbo.SchoolSubjectMarks", "Student_IdUser", "dbo.Students", "IdUser");
            AddForeignKey("dbo.SchoolSubjectMarks", "SchoolSubject_IdSubject", "dbo.SchoolSubjects", "IdSubject");
            DropColumn("dbo.SchoolSubjectMarks", "MarkPalier");
            DropColumn("dbo.Students", "Address");
            DropTable("dbo.StudentMarkSubjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentMarkSubjects",
                c => new
                    {
                        IdStudentMarkSubject = c.Int(nullable: false, identity: true),
                        Student_idUser = c.Int(nullable: false),
                        SchoolSubject_idSubject = c.Int(nullable: false),
                        SchoolSubjectMarkIdMark = c.Int(nullable: false),
                        aSchoolSubject_IdSubject = c.Int(),
                        unStudent_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdStudentMarkSubject);
            
            AddColumn("dbo.Students", "Address", c => c.String());
            AddColumn("dbo.SchoolSubjectMarks", "MarkPalier", c => c.Int());
            DropForeignKey("dbo.SchoolSubjectMarks", "SchoolSubject_IdSubject", "dbo.SchoolSubjects");
            DropForeignKey("dbo.SchoolSubjectMarks", "Student_IdUser", "dbo.Students");
            DropForeignKey("dbo.Grades", "Manager_IdUser", "dbo.Managers");
            DropIndex("dbo.SchoolSubjectMarks", new[] { "SchoolSubject_IdSubject" });
            DropIndex("dbo.SchoolSubjectMarks", new[] { "Student_IdUser" });
            DropIndex("dbo.Grades", new[] { "Manager_IdUser" });
            DropColumn("dbo.Students", "Password");
            DropColumn("dbo.Students", "AddressMail");
            DropColumn("dbo.SchoolSubjectMarks", "SchoolSubject_IdSubject");
            DropColumn("dbo.SchoolSubjectMarks", "Student_IdUser");
            DropColumn("dbo.SchoolSubjects", "Rattrapable");
            DropColumn("dbo.SchoolSubjects", "Semester");
            DropColumn("dbo.SchoolSubjects", "SubjectMarkFloor");
            DropColumn("dbo.Grades", "Manager_IdUser");
            CreateIndex("dbo.StudentMarkSubjects", "unStudent_IdUser");
            CreateIndex("dbo.StudentMarkSubjects", "aSchoolSubject_IdSubject");
            CreateIndex("dbo.StudentMarkSubjects", "SchoolSubjectMarkIdMark");
            AddForeignKey("dbo.StudentMarkSubjects", "unStudent_IdUser", "dbo.Students", "IdUser");
            AddForeignKey("dbo.StudentMarkSubjects", "SchoolSubjectMarkIdMark", "dbo.SchoolSubjectMarks", "IdMark", cascadeDelete: true);
            AddForeignKey("dbo.StudentMarkSubjects", "aSchoolSubject_IdSubject", "dbo.SchoolSubjects", "IdSubject");
        }
    }
}
