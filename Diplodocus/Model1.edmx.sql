
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/23/2018 23:51:38
-- Generated from EDMX file: C:\Users\Admin\source\repos\Diplodocus2\Diplodocus\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DDB_DIPLODOCUS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Manager_ToTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Manager] DROP CONSTRAINT [FK_Manager_ToTable];
GO
IF OBJECT_ID(N'[dbo].[FK_Student_ToTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Student] DROP CONSTRAINT [FK_Student_ToTable];
GO
IF OBJECT_ID(N'[dbo].[FK_Teacher_ToTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Teacher] DROP CONSTRAINT [FK_Teacher_ToTable];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Examen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Examen];
GO
IF OBJECT_ID(N'[dbo].[Grade]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grade];
GO
IF OBJECT_ID(N'[dbo].[Manager]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Manager];
GO
IF OBJECT_ID(N'[dbo].[SchoolSubject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SchoolSubject];
GO
IF OBJECT_ID(N'[dbo].[SchoolSubjectMark]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SchoolSubjectMark];
GO
IF OBJECT_ID(N'[dbo].[Student]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Student];
GO
IF OBJECT_ID(N'[dbo].[Teacher]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teacher];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Examen1'
CREATE TABLE [dbo].[Examen1] (
    [idExamen] int  NOT NULL,
    [nameExamen] varchar(50)  NULL,
    [typeExamen] varchar(50)  NULL,
    [markExamen] varchar(50)  NULL,
    [SchoolSubjectMarkIdMark] int  NOT NULL
);
GO

-- Creating table 'Grades'
CREATE TABLE [dbo].[Grades] (
    [IdGrade] int  NOT NULL,
    [gradeName] varchar(50)  NULL,
    [ManagerGrade_Grade_idUser] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [idUser] int  NOT NULL,
    [firstName] varchar(50)  NULL,
    [lastName] varchar(50)  NULL,
    [address] varchar(50)  NULL,
    [phoneNumber] nchar(10)  NULL
);
GO

-- Creating table 'Users_Teacher'
CREATE TABLE [dbo].[Users_Teacher] (
    [idUser] int  NOT NULL
);
GO

-- Creating table 'Users_Manager'
CREATE TABLE [dbo].[Users_Manager] (
    [idUser] int  NOT NULL
);
GO

-- Creating table 'SchoolSubjects'
CREATE TABLE [dbo].[SchoolSubjects] (
    [idSubject] int  NOT NULL,
    [subjectName] varchar(50)  NULL,
    [GradeIdGrade] int  NOT NULL,
    [TeacherSchoolSubject_SchoolSubject_idUser] int  NOT NULL
);
GO

-- Creating table 'SchoolSubjectMarks'
CREATE TABLE [dbo].[SchoolSubjectMarks] (
    [mark] int  NULL,
    [IdMark] int  NOT NULL
);
GO

-- Creating table 'Users_Student'
CREATE TABLE [dbo].[Users_Student] (
    [SchoolSubjectMarkIdMark] int  NOT NULL,
    [GradeIdGrade] int  NOT NULL,
    [idUser] int  NOT NULL
);
GO

-- Creating table 'StudentMarkSubjects'
CREATE TABLE [dbo].[StudentMarkSubjects] (
    [IdStudentMarkSubject] int IDENTITY(1,1) NOT NULL,
    [Student_idUser] int  NOT NULL,
    [SchoolSubject_idSubject] int  NOT NULL,
    [SchoolSubjectMarkIdMark] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idExamen] in table 'Examen1'
ALTER TABLE [dbo].[Examen1]
ADD CONSTRAINT [PK_Examen1]
    PRIMARY KEY CLUSTERED ([idExamen] ASC);
GO

-- Creating primary key on [IdGrade] in table 'Grades'
ALTER TABLE [dbo].[Grades]
ADD CONSTRAINT [PK_Grades]
    PRIMARY KEY CLUSTERED ([IdGrade] ASC);
GO

-- Creating primary key on [idUser] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([idUser] ASC);
GO

-- Creating primary key on [idUser] in table 'Users_Teacher'
ALTER TABLE [dbo].[Users_Teacher]
ADD CONSTRAINT [PK_Users_Teacher]
    PRIMARY KEY CLUSTERED ([idUser] ASC);
GO

-- Creating primary key on [idUser] in table 'Users_Manager'
ALTER TABLE [dbo].[Users_Manager]
ADD CONSTRAINT [PK_Users_Manager]
    PRIMARY KEY CLUSTERED ([idUser] ASC);
GO

-- Creating primary key on [idSubject] in table 'SchoolSubjects'
ALTER TABLE [dbo].[SchoolSubjects]
ADD CONSTRAINT [PK_SchoolSubjects]
    PRIMARY KEY CLUSTERED ([idSubject] ASC);
GO

-- Creating primary key on [IdMark] in table 'SchoolSubjectMarks'
ALTER TABLE [dbo].[SchoolSubjectMarks]
ADD CONSTRAINT [PK_SchoolSubjectMarks]
    PRIMARY KEY CLUSTERED ([IdMark] ASC);
GO

-- Creating primary key on [idUser] in table 'Users_Student'
ALTER TABLE [dbo].[Users_Student]
ADD CONSTRAINT [PK_Users_Student]
    PRIMARY KEY CLUSTERED ([idUser] ASC);
GO

-- Creating primary key on [IdStudentMarkSubject] in table 'StudentMarkSubjects'
ALTER TABLE [dbo].[StudentMarkSubjects]
ADD CONSTRAINT [PK_StudentMarkSubjects]
    PRIMARY KEY CLUSTERED ([IdStudentMarkSubject] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Student_idUser] in table 'StudentMarkSubjects'
ALTER TABLE [dbo].[StudentMarkSubjects]
ADD CONSTRAINT [FK_StudentStudentMarkSubject]
    FOREIGN KEY ([Student_idUser])
    REFERENCES [dbo].[Users_Student]
        ([idUser])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentStudentMarkSubject'
CREATE INDEX [IX_FK_StudentStudentMarkSubject]
ON [dbo].[StudentMarkSubjects]
    ([Student_idUser]);
GO

-- Creating foreign key on [SchoolSubject_idSubject] in table 'StudentMarkSubjects'
ALTER TABLE [dbo].[StudentMarkSubjects]
ADD CONSTRAINT [FK_SchoolSubjectStudentMarkSubject]
    FOREIGN KEY ([SchoolSubject_idSubject])
    REFERENCES [dbo].[SchoolSubjects]
        ([idSubject])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SchoolSubjectStudentMarkSubject'
CREATE INDEX [IX_FK_SchoolSubjectStudentMarkSubject]
ON [dbo].[StudentMarkSubjects]
    ([SchoolSubject_idSubject]);
GO

-- Creating foreign key on [SchoolSubjectMarkIdMark] in table 'StudentMarkSubjects'
ALTER TABLE [dbo].[StudentMarkSubjects]
ADD CONSTRAINT [FK_SchoolSubjectMarkStudentMarkSubject]
    FOREIGN KEY ([SchoolSubjectMarkIdMark])
    REFERENCES [dbo].[SchoolSubjectMarks]
        ([IdMark])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SchoolSubjectMarkStudentMarkSubject'
CREATE INDEX [IX_FK_SchoolSubjectMarkStudentMarkSubject]
ON [dbo].[StudentMarkSubjects]
    ([SchoolSubjectMarkIdMark]);
GO

-- Creating foreign key on [SchoolSubjectMarkIdMark] in table 'Examen1'
ALTER TABLE [dbo].[Examen1]
ADD CONSTRAINT [FK_SchoolSubjectMarkExamen]
    FOREIGN KEY ([SchoolSubjectMarkIdMark])
    REFERENCES [dbo].[SchoolSubjectMarks]
        ([IdMark])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SchoolSubjectMarkExamen'
CREATE INDEX [IX_FK_SchoolSubjectMarkExamen]
ON [dbo].[Examen1]
    ([SchoolSubjectMarkIdMark]);
GO

-- Creating foreign key on [GradeIdGrade] in table 'Users_Student'
ALTER TABLE [dbo].[Users_Student]
ADD CONSTRAINT [FK_GradeStudent]
    FOREIGN KEY ([GradeIdGrade])
    REFERENCES [dbo].[Grades]
        ([IdGrade])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GradeStudent'
CREATE INDEX [IX_FK_GradeStudent]
ON [dbo].[Users_Student]
    ([GradeIdGrade]);
GO

-- Creating foreign key on [GradeIdGrade] in table 'SchoolSubjects'
ALTER TABLE [dbo].[SchoolSubjects]
ADD CONSTRAINT [FK_GradeSchoolSubject]
    FOREIGN KEY ([GradeIdGrade])
    REFERENCES [dbo].[Grades]
        ([IdGrade])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GradeSchoolSubject'
CREATE INDEX [IX_FK_GradeSchoolSubject]
ON [dbo].[SchoolSubjects]
    ([GradeIdGrade]);
GO

-- Creating foreign key on [TeacherSchoolSubject_SchoolSubject_idUser] in table 'SchoolSubjects'
ALTER TABLE [dbo].[SchoolSubjects]
ADD CONSTRAINT [FK_TeacherSchoolSubject]
    FOREIGN KEY ([TeacherSchoolSubject_SchoolSubject_idUser])
    REFERENCES [dbo].[Users_Teacher]
        ([idUser])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeacherSchoolSubject'
CREATE INDEX [IX_FK_TeacherSchoolSubject]
ON [dbo].[SchoolSubjects]
    ([TeacherSchoolSubject_SchoolSubject_idUser]);
GO

-- Creating foreign key on [ManagerGrade_Grade_idUser] in table 'Grades'
ALTER TABLE [dbo].[Grades]
ADD CONSTRAINT [FK_ManagerGrade]
    FOREIGN KEY ([ManagerGrade_Grade_idUser])
    REFERENCES [dbo].[Users_Manager]
        ([idUser])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerGrade'
CREATE INDEX [IX_FK_ManagerGrade]
ON [dbo].[Grades]
    ([ManagerGrade_Grade_idUser]);
GO

-- Creating foreign key on [idUser] in table 'Users_Teacher'
ALTER TABLE [dbo].[Users_Teacher]
ADD CONSTRAINT [FK_Teacher_inherits_User]
    FOREIGN KEY ([idUser])
    REFERENCES [dbo].[Users]
        ([idUser])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [idUser] in table 'Users_Manager'
ALTER TABLE [dbo].[Users_Manager]
ADD CONSTRAINT [FK_Manager_inherits_Teacher]
    FOREIGN KEY ([idUser])
    REFERENCES [dbo].[Users_Teacher]
        ([idUser])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [idUser] in table 'Users_Student'
ALTER TABLE [dbo].[Users_Student]
ADD CONSTRAINT [FK_Student_inherits_User]
    FOREIGN KEY ([idUser])
    REFERENCES [dbo].[Users]
        ([idUser])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------