using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
    {
        MyDatabase db = DBManager.Database;
        AverageCalculator calculator = new AverageCalculator();
        public List<SubjectAverage> SubAves = new List<SubjectAverage>();

        private List<int> ListViewIS = new List<int>();

        public Page1() {
            InitializeComponent();

            AddMark();
        }

        private void AddMark()
        {
            ListViewIS.Add(1);
            listviewAves.ItemsSource = ListViewIS;
        }

        private void PrintResult(object sender, EventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}