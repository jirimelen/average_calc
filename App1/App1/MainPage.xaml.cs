using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MyLibrary;
using MyLibrary.types;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        MyDatabase db = DBManager.Database;
        AverageCalculator calculator = new AverageCalculator();
        public List<SubjectAverage> SubAves = new List<SubjectAverage>();

        public MainPage()
        {
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
            //db.InsertMark(new Mark { Value = 2.5, Impact = 40, SubjectID = 2 });
            
            InitializeComponent();
            FillSubAves();
        }

        public async void FillSubAves()
        {
            SubAves.Clear();
            List<Subject> subjects = await db.GetListOf<Subject>();
            List<Mark> marks = await db.GetListOf<Mark>();

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
                SubAves.Add(new SubjectAverage { Name = subject.Name, Average = calculator.calculate(marksValue, marksImpact).ToString("#,##0.00") });
            }
            // move to the function below
            listviewSubjects.ItemsSource = SubAves;
        }

        public void DisplaySubAves()
        {
        }

        private async void Navigate_CustomAverage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new Page1()));
        }
    }
}
