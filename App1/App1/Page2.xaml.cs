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

        private async void FillPicker()
        {
            subjectPicker.ItemsSource = await db.GetListOf<Subject>();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var selected = (Subject)subjectPicker.SelectedItem;
            await db.InsertMark(new Mark { Impact = int.Parse(impactEntry.Text), Value = int.Parse(markEntry.Text), SubjectID = selected.ID });
            var x = (TabbedPage)(this.Parent);
            var y = (MainPage)(x.Children[0]);
            y.FillSubAves();
        }
    }
}