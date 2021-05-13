using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ExcelDataReader;

namespace StepTestData1
{
    public partial class AddParticipant : ApplicationForm
    {

        private readonly List<ParticipantInfos> participants = new List<ParticipantInfos>();
        public AddParticipant()
        {
            InitializeComponent();
        }
        private void AddParticipant_Load(object sender, EventArgs e)
        {
            AddedParticipants.View = View.Details;
            AddedParticipants.FullRowSelect = true;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Switch<Home>();
        }

        private void StartSessionBtn_Click(object sender, EventArgs e)
        {

        }

        private void AddParticipantToList(ParticipantInfos userInfo)
        {
            string[] arr = new string[3];
            arr[0] = userInfo.Name;
            arr[1] = userInfo.Age.ToString();
            arr[2] = userInfo.Sex.ToString();
            AddedParticipants.Items.Add(new ListViewItem(arr));
        }
        private async void NewParticipantBtn_Click(object sender, EventArgs e)
        {
            var newParticipant = new AddParticipantInfos();
            var userInfo = await newParticipant.Show();
            participants.Add(userInfo);
            AddParticipantToList(userInfo);
        }

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
                                            Sex = Enum.Parse(typeof(Sex), row[table.Columns[2]].ToString(), true) as Sex?
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
