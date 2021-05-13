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

        private List<Test> tests;
        public Previous()
        {
            InitializeComponent();
        }
        private void Previous_Load(object sender, EventArgs e)
        {
            LoadTests();
        }
        public async void LoadTests()
        {
            await DatabaseContext.Add(new Test() { Age = 19, Date = DateTime.Now, Score = 29, Sex = Sex.Male, UserName = "azdiazdnoi" });
            tests = await DatabaseContext.GetAll();
            DisplayTable();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Switch<Home>();
        }

        private void DisplayTable()
        {
            foreach (var test in tests)
                Results.Rows.Add(test.UserName, test.Sex, test.Age, test.Score, Utils.ComputeRatingFromScore(test.Score, test.Age, test.Sex).ToString(), test.Date);
            Results.AutoResizeColumns();
        }

        private async void SearchInput_TextChanged(object sender, EventArgs e)
        {
            Results.Rows.Clear();
            tests = await DatabaseContext.Search(SearchInput.Text);
            DisplayTable();
        }

        private void Results_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            DatabaseContext.Delete(tests[e.RowIndex]);
        }

    }
}
