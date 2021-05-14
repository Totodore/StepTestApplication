using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ExcelDataReader;
using MaterialSkin.Controls;

namespace StepTestData1
{
    /// <summary>
    /// Here is the form where the user can add or import a list of participant prior to the test
    /// </summary>
    public partial class AddParticipant : ApplicationForm
    {

        /// <summary>
        /// The list of added participants
        /// </summary>
        private readonly List<ParticipantInfos> participants;
        /// <summary>
        /// The list of radio buttons to select the step height
        /// </summary>
        private List<MaterialRadioButton> stepsBtns;
        public AddParticipant()
        {
            participants = new List<ParticipantInfos>();
            InitializeComponent();
        }
        /// <summary>
        /// If this form is switched from a form after (by clicking on the back button),
        /// Then the list of participants are given back in order to not loose it.
        /// We then add all the participants of the list in the Widget to display them
        /// </summary>
        /// <param name="participants">The list of participants given back</param>
        public AddParticipant(List<ParticipantInfos> participants)
        {
            this.participants = participants;
            InitializeComponent();
            foreach (var participant in participants)
                AddParticipantToList(participant);
        }
        /// <summary>
        /// We set the view list in details mode to display columns and we set the list of radio btns
        /// </summary>
        private void AddParticipant_Load(object sender, EventArgs e)
        {
            AddedParticipants.View = View.Details;
            AddedParticipants.FullRowSelect = true;
            stepsBtns = new List<MaterialRadioButton>()
            {
                Step15,
                Step20,
                Step25,
                Step30
            };
        }
        /// <summary>
        /// If the back button is clicked we switch to the home view
        /// </summary>
        private void Back_Click(object sender, EventArgs e)
        {
            Switch<Home>();
        }
        /// <summary>
        /// If the start session is clicked we get the step height and we switch to the TestSession form
        /// We give it the list of participants and the height of the step we chose
        /// </summary>
        private void StartSessionBtn_Click(object sender, EventArgs e)
        {
            int stepHeight = 15;
            foreach (var step in stepsBtns)
                if (step.Checked)
                    stepHeight = int.Parse(step.Tag.ToString());
            Switch(new TestSession(participants, stepHeight));
        }

        /// <summary>
        /// Methods that add a participant to the data list and the list view
        /// </summary>
        /// <param name="userInfo">The participant to add</param>
        private void AddParticipantToList(ParticipantInfos userInfo)
        {
            string[] arr = new string[3];
            arr[0] = userInfo.Name;
            arr[1] = userInfo.Age.ToString();
            arr[2] = userInfo.Sex.ToString();
            AddedParticipants.Items.Add(new ListViewItem(arr));
            if (AddedParticipants.Items.Count > 0 && !StartSessionBtn.Enabled)
                StartSessionBtn.Enabled = true;
        }
        /// <summary>
        /// If the new participant btn is clicked we open the AddParticipantInfos form and we block this one
        /// so we wait to get the add user info is the created form.
        /// Once the AddParticipantInfos form is closed we add the new participant to the list
        /// </summary>
        private async void NewParticipantBtn_Click(object sender, EventArgs e)
        {
            var newParticipant = new AddParticipantInfos();
            var userInfo = await newParticipant.Show();
            participants.Add(userInfo);
            AddParticipantToList(userInfo);
        }

        /// <summary>
        /// If we press the delete key while we have one or more selected participants we remove them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddedParticipants_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;
            var itemsToRemove = new List<ParticipantInfos>();
            foreach (ListViewItem lvItem in AddedParticipants.SelectedItems)
            {
                var index = AddedParticipants.Items.IndexOf(lvItem);
                itemsToRemove.Add(participants[index]);
                AddedParticipants.Items.Remove(lvItem);
            }
            foreach (var item in itemsToRemove)
                participants.Remove(item);
        }

        /// <summary>
        /// If we click on the import participant btn :
        /// - We open a File dialog to select a csv / xlsx / xls file
        /// - If the user has selected one
        /// - We open a file and we get a reader with The ExcelDataReader Lib
        /// - For each table and for each row, if the row if valid (3 full columns) (Name, Age, Sex) we try to add it to the list.
        /// - If we can't add one row we continue on the next row
        /// </summary>
        private void ImportParticipantBtn_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Select a table file",
                Filter = "Table Files|*.csv;*.xlsx;*.xls"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream;
                try {
                    using (stream = dialog.OpenFile())
                    {
                        using (var reader = Path.GetExtension(dialog.FileName) == ".csv" ? ExcelReaderFactory.CreateCsvReader(stream) : ExcelReaderFactory.CreateReader(stream))
                        {
                            var result = reader.AsDataSet();
                            foreach (DataTable table in result.Tables)
                                foreach (DataRow row in table.Rows)
                                {
                                    try
                                    {
                                        if (
                                            row.ItemArray.All(o => string.IsNullOrWhiteSpace(o?.ToString()))
                                            || row[table.Columns[0]].ToString().Length < 2
                                            || int.Parse(row[table.Columns[1]].ToString()) < 14
                                        ) continue;
                                        var participant = new ParticipantInfos()
                                        {    
                                            Name = row[table.Columns[0]].ToString(),
                                            Age = int.Parse(row[table.Columns[1]].ToString()),
                                            Sex = (Sex)Enum.Parse(typeof(Sex), row[table.Columns[2]].ToString(), true)
                                        };
                                        participants.Add(participant);
                                        AddParticipantToList(participant);
                                    } catch
                                    {
                                        continue;
                                    }
                                }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Impossible to parse this file!");
                }
             }

        }
    }
}
