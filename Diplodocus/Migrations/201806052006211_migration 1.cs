namespace Diplodocus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        IdGrade = c.Int(nullable: false, identity: true),
                        gradeName = c.String(),
                    })
                .PrimaryKey(t => t.IdGrade);
            
            CreateTable(
                "dbo.SchoolSubjects",
                c => new
                    {
                        IdSubject = c.Int(nullable: false, identity: true),
                        subjectName = c.String(nullable: false),
                        GradeIdGrade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSubject)
                .ForeignKey("dbo.Grades", t => t.GradeIdGrade, cascadeDelete: true)
                .Index(t => t.GradeIdGrade);
            
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
                .PrimaryKey(t => t.IdStudentMarkSubject)
                .ForeignKey("dbo.SchoolSubjects", t => t.aSchoolSubject_IdSubject)
                .ForeignKey("dbo.SchoolSubjectMarks", t => t.SchoolSubjectMarkIdMark, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.unStudent_IdUser)
                .Index(t => t.SchoolSubjectMarkIdMark)
                .Index(t => t.aSchoolSubject_IdSubject)
                .Index(t => t.unStudent_IdUser);
            
            CreateTable(
                "dbo.SchoolSubjectMarks",
                c => new
                    {
                        IdMark = c.Int(nullable: false, identity: true),
                        Mark = c.Int(),
                        MarkPalier = c.Int(),
                    })
                .PrimaryKey(t => t.IdMark);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Grade_IdGrade = c.Int(),
                    })
                .PrimaryKey(t => t.IdUser)
                .ForeignKey("dbo.Grades", t => t.Grade_IdGrade)
                .Index(t => t.Grade_IdGrade);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Grade_IdGrade", "dbo.Grades");
            DropForeignKey("dbo.StudentMarkSubjects", "unStudent_IdUser", "dbo.Users");
            DropForeignKey("dbo.StudentMarkSubjects", "SchoolSubjectMarkIdMark", "dbo.SchoolSubjectMarks");
            DropForeignKey("dbo.StudentMarkSubjects", "aSchoolSubject_IdSubject", "dbo.SchoolSubjects");
            DropForeignKey("dbo.SchoolSubjects", "GradeIdGrade", "dbo.Grades");
            DropIndex("dbo.Users", new[] { "Grade_IdGrade" });
            DropIndex("dbo.StudentMarkSubjects", new[] { "unStudent_IdUser" });
            DropIndex("dbo.StudentMarkSubjects", new[] { "aSchoolSubject_IdSubject" });
            DropIndex("dbo.StudentMarkSubjects", new[] { "SchoolSubjectMarkIdMark" });
            DropIndex("dbo.SchoolSubjects", new[] { "GradeIdGrade" });
            DropTable("dbo.Users");
            DropTable("dbo.SchoolSubjectMarks");
            DropTable("dbo.StudentMarkSubjects");
            DropTable("dbo.SchoolSubjects");
            DropTable("dbo.Grades");
        }
    }
}
