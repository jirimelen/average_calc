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
        public Page1()

        {
            InitializeComponent();
        }

        private void PrintResult(object sender, EventArgs e)
        {

        }
    }
}