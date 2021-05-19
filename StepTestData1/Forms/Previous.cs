using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StepTestData1
{
    public partial class Previous : ApplicationForm
    {

        /// <summary>
        /// List of the loaded tests
        /// </summary>
        private List<Test> tests;
        public Previous()
        {
            InitializeComponent();
        }
        /// <summary>
        /// We Load test we the window is loading
        /// </summary>
        private void Previous_Load(object sender, EventArgs e)
        {
            LoadTests();
        }
        /// <summary>
        /// We get all the test and we display them
        /// </summary>
        public async void LoadTests()
        {
            tests = await DatabaseContext.GetAll();
            DisplayTable();
        }

        /// <summary>
        /// When we click on the back button we get back to the home form
        /// </summary>
        private void Back_Click(object sender, EventArgs e)
        {
            Switch<Home>();
        }

        /// <summary>
        /// Iterate each loaded test and add them to the table
        /// Then it autoresize the columns
        /// </summary>
        private void DisplayTable()
        {
            foreach (var test in tests)
                Results.Rows.Add(test.UserName, test.Sex, test.Age, test.Score, Utils.ComputeRatingFromScore(test.Score, test.Age, test.Sex).ToString(), test.Date);
            Results.AutoResizeColumns();
        }

        /// <summary>
        /// If we search in the searchbar we make a search request and we redisplay data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SearchInput_TextChanged(object sender, EventArgs e)
        {
            tests = await DatabaseContext.Search(SearchInput.Text);
            Results.Rows.Clear();
            DisplayTable();
        }
    }
}
