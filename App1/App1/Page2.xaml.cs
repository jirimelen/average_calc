using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	public partial class Page2 : ContentPage
	{
        MyDatabase db = DBManager.Database;

		public Page2 ()
		{
			InitializeComponent ();

            FillPicker();
		}

        private async Task FillPicker()
        {
            subjectPicker.ItemsSource = await db.GetListOf<Subject>();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // insert mark into db
            var selected = (subjectPicker.SelectedItem as Subject);
            await db.InsertMark(new Mark {
                Impact = int.Parse(impactEntry.Text),
                Value = int.Parse(markEntry.Text),
                SubjectID = selected.ID
            });
            impactEntry.Text = String.Empty;
            markEntry.Text = String.Empty;
            progress_label.Text = "hotovo";
            // update the subAves list on main page
            var tabPage = this.Parent.Parent as TabbedPage;
            var navPage = tabPage.Children[0] as NavigationPage;
            var mainPage = navPage.CurrentPage as MainPage;
            await mainPage.FillSubAves();

        }
    }
}