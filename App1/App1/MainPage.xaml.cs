using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MyLibrary;
using MyLibrary.types;
using System.Collections.ObjectModel;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        MyDatabase db = DBManager.Database;
        AverageCalculator calculator = new AverageCalculator();
        public ObservableCollection<SubjectAverage> SubAves = new ObservableCollection<SubjectAverage>();

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
            
            /*db(new Mark { Value = 1, Impact = 50, SubjectID = 1 });
            db.InsertMark(new Mark { Value = 2, Impact = 100, SubjectID = 5 });
            db.InsertMark(new Mark { Value = 3, Impact = 80, SubjectID = 1 });
            db.InsertMark(new Mark { Value = 4, Impact = 10, SubjectID = 3 });
            db.InsertMark(new Mark { Value = 5, Impact = 30, SubjectID = 5 });*/
            //db.InsertMark(new Mark { Value = 2.5, Impact = 40, SubjectID = 2 });
            
            InitializeComponent();
            DisplaySubAves();
        }

        public async Task FillSubAves()
        {
            SubAves.Clear();
            List<Subject> subjects = await db.GetListOf<Subject>();
            List<Mark> marks = await db.GetListOf<Mark>();

            foreach (var subject in subjects)
            {
                List<Mark> MarksToCalculate = new List<Mark>();
                foreach (var mark in marks)
                {
                    if (mark.SubjectID == subject.ID)
                    {
                        MarksToCalculate.Add(mark);
                    }
                }
                SubAves.Add(new SubjectAverage { Name = subject.Name, Average = calculator.calculate(MarksToCalculate).ToString("#,##0.00") });
            }
        }

        public async Task DisplaySubAves()
        {
            await FillSubAves();
            listviewSubjects.ItemsSource = SubAves;
        }

        private async void Navigate_CustomAverage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }

        private async void listviewSubjects_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string selectedName = (e.SelectedItem as SubjectAverage).Name;
            List<Subject> selectedSubject = await db.GetSubjectByName(selectedName);
            var go = 2;
            await Navigation.PushAsync(new MarksOfSubject(selectedSubject[0].ID));
        }
    }
}
