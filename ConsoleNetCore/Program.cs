using MyLibrary;
using MyLibrary.types;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConsoleNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = DBManager.Database;
            var calc = new AverageCalculator();
            /*
            db.InsertSubject(new Subject { Name = "Math" });
            db.InsertSubject(new Subject { Name = "English language" });
            db.InsertSubject(new Subject { Name = "Czech Language" });
            db.InsertSubject(new Subject { Name = "Social studies" });
            db.InsertSubject(new Subject { Name = "Physical Education" });
            db.InsertSubject(new Subject { Name = "Programming" });
            */
            
            /*db.InsertMark(new Mark { Value = 1, Impact = 50, SubjectID = 1 });
            db.InsertMark(new Mark { Value = 2, Impact = 100, SubjectID = 5 });
            db.InsertMark(new Mark { Value = 3, Impact = 80, SubjectID = 1 });
            db.InsertMark(new Mark { Value = 4, Impact = 10, SubjectID = 3 });
            db.InsertMark(new Mark { Value = 5, Impact = 30, SubjectID = 5 });*/
            db.InsertMark(new Mark { Value = 2.5, Impact = 40, SubjectID = 2 });
            
            List<Mark> gottenMarks = db.GetListOf<Mark>().Result;
            List<Subject> gottenSubjects = db.GetListOf<Subject>().Result;

            /*foreach (var mark in gottenMarks)
            {
                //db.DeleteMark(mark);
                Console.WriteLine("\nsubject: " + db.GetById<Subject>(mark.SubjectID).Result.Name + "\n mark  : " + mark.Value + "\n impact: " + mark.Impact);
            }*/

            List<Subject> subjects = db.GetListOf<Subject>().Result;
            List<Mark> marks = db.GetListOf<Mark>().Result;

            foreach (var subject in subjects)
            {
                double marksValue = 0;
                int marksImpact = 0;
                foreach (var mark in marks)
                {
                    if (mark.SubjectID == subject.ID)
                    {
                        marksValue += mark.Value * mark.Impact;
                        marksImpact += mark.Impact;
                    }
                }
                var subAve = new SubjectAverage { Name = subject.Name, Average = calc.calculate(marksValue, marksImpact).ToString("#,##0.00") };
                Console.WriteLine(subAve.Name + "  ||  " + subAve.Average);
            }

            Console.WriteLine();
            /*
            foreach (var subject in gottenSubjects)
            {
                Console.WriteLine("ID: " + subject.ID + " subject: " + subject.Name);
            }
            */
            Console.ReadKey();
        }
    }
}
