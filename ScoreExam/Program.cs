using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace ScoreExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int Error = 0;
            int Correct = 0;

            List<Student> Students = new List<Student>();
            List<Subject> Subjects = new List<Subject>();
            List<Studentsubject> StudentSubjects = new List<Studentsubject>();

            string ReadFile = File.ReadAllText("C:\\Users\\Kakhaber.sartania\\Desktop\\sagamocdo_niSnebi.txt");

            using (TestContext db = new TestContext())
            {
                Students = db.Students.ToList();
                Subjects = db.Subjects.ToList();

                int index = 0;

                foreach (var item in ReadFile.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Skip(1))
                {
                    index++;

                    var Result = item.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    Studentsubject Studentsubject = new Studentsubject();

                    Studentsubject.Id = index;

                    if (int.TryParse(Result[0], out int result))
                    {
                        if (int.Parse(Result[0]) > Students.Last().StudentId)
                        {
                            Error++;
                            continue;
                        }
                        else
                        {
                            Studentsubject.StudentId = int.Parse(Result[0]);
                            Correct++;
                        }
                    }
                    else
                    {
                        Error++;
                        continue;
                    }

                    if (int.TryParse(Result[1], out int result1))
                    {
                        if (int.Parse(Result[1]) > Students.Last().StudentId)
                        {
                            Error++;
                            continue;
                        }
                        else
                        {
                            Studentsubject.SubjecId = int.Parse(Result[1]);
                        }
                    }
                    else
                    {
                        Error++;
                        continue;
                    }

                    if (int.TryParse(Result[2], out int result2))
                    {
                        Studentsubject.Point = int.Parse(Result[2]);
                    }
                    else
                    {
                        Error++;
                        continue;
                    }

                    StudentSubjects.Add(Studentsubject);
                }

                db.StudentSubjects.AddRange(StudentSubjects);
                db.SaveChanges();

            }

            Console.WriteLine($"shecdomit aris {Error} cali studenti");
            Console.WriteLine($"scored aris {Correct} cali studsenti");
        }

        public class TestContext : DbContext
        {
            public TestContext() : base("server=DESKTOP-FJOGIID; database=StudentTest; integrated security=true;")
            {

            }

            public DbSet<Student> Students { get; set; }
            public DbSet<Subject> Subjects { get; set; }
            public DbSet<Studentsubject> StudentSubjects { get; set; }
        }

        public class Student
        {
            public int StudentId { get; set; }
            [Required, StringLength(25)]
            public string FirstName { get; set; }
            [Required, StringLength(35)]
            public string LastName { get; set; }
            public override string ToString()
            {
                return FirstName + " " + LastName;
            }
        }

        public class Subject
        {
            public int SubjectId { get; set; }
            [Required, StringLength(50)]
            public string SubjectName { get; set; }
            public int StudentId { get; set; }
            public override string ToString()
            {
                return SubjectName;
            }
        }

        public class Studentsubject
        {
            public int Id { get; set; }
            public int StudentId { get; set; }
            public int SubjecId { get; set; }
            public int Point { get; set; }

            public ICollection<Student> Students { get; set; }
            public ICollection<Subject> Subjects { get; set; }
        }
    }
}
