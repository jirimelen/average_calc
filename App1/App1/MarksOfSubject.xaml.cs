using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;
using MyLibrary.types;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MarksOfSubject : ContentPage
	{
        MyDatabase db = DBManager.Database;
        List<Mark> marks = new List<Mark>();

		public MarksOfSubject(int subjectID)
		{
			InitializeComponent();
            /*Subject sub = db.GetById<Subject>(subjectID).Result;
            var par = this.Parent as NavigationPage;
            par.Title = sub.Name;*/

            DisplayMarks(subjectID);
		}

        private async Task DisplayMarks( int SubjectID )
        {
            marks.Clear();
            marks = await db.GetMarksBySqlRequest("select * from Mark where SubjectID=" + SubjectID);
            marksListView.ItemsSource = marks;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var senderB = sender as Button;
            var parent = senderB.Parent as StackLayout;
            var idLabel = parent.Children[3] as Label;
            int id = int.Parse(idLabel.Text);
            Mark toDelte = await db.GetById<Mark>(id);
            await db.DeleteMark(toDelte);
            // update the subAves list on main page
            var tabPage = this.Parent.Parent as TabbedPage;
            var navPage = tabPage.Children[0] as NavigationPage;
            var mainPage = navPage.CurrentPage as MainPage;
            await mainPage.FillSubAves();
        }
    }
}