namespace ScoreExam.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static ScoreExam.Program;

    internal sealed class Configuration : DbMigrationsConfiguration<ScoreExam.Program.TestContext>
    {
        private List<Subject> subjects;
        private List<Student> students;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ScoreExam.Program.TestContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            subjects = new List<Subject>{ new Subject {  SubjectId=1, SubjectName= "c# Programing" },
                                            new Subject { SubjectId=2, SubjectName= "Piton Programing" },
                                            new Subject { SubjectId=3, SubjectName= "c++ Programing" },
                                            new Subject { SubjectId=4, SubjectName= "Delfi Programing" },
                                            new Subject { SubjectId=5, SubjectName= "Pascale Programing" }};

            students = new List<Student> { new Student { StudentId = 1, FirstName = "pachurti", LastName = "bagaturia" },
                                            new Student { StudentId = 2, FirstName = "kakhaber", LastName = "sartania" },
                                            new Student { StudentId = 3, FirstName = "chuchua", LastName = "gana" },
                                            new Student { StudentId = 4, FirstName = "efsia", LastName = "directori" },
                                            new Student { StudentId = 5, FirstName = "emaili", LastName = "kutalia" }};
            context.Students.AddOrUpdate(f => f.LastName, students.ToArray());
            context.Subjects.AddOrUpdate(f => f.SubjectName, subjects.ToArray());
        }
    }
}
