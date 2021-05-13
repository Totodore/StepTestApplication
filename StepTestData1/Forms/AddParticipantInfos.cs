using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StepTestData1
{
    public partial class AddParticipantInfos : Form
    {
        private ParticipantInfos infos = new ParticipantInfos();
        private bool done = false;
        public AddParticipantInfos()
        {
            InitializeComponent();
        }
        private void AddParticipantInfos_Load(object sender, EventArgs e)
        {
            ParticipantName.DataBindings.Add("Text", infos, "Name");
            ParticipantAge.DataBindings.Add("Text", infos, "Age", true);
        }
        public async new Task<ParticipantInfos> Show()
        {
            base.Show();
            while (!done)
                await Task.Delay(25);
            return infos;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (MaleParticipant.Checked)
                infos.Sex = Sex.Male;
            else if (FemaleParticipant.Checked)
                infos.Sex = Sex.Female;

            if (infos.Name.Length < 2)
                MessageBox.Show("Name must be longer than 1 character!");
            else if (infos.Age == null || infos.Age < 15 || infos.Age > 69)
                MessageBox.Show("Participant must be older than 14 and younger than 69 years old!");
            else if (infos.Sex == null)
                MessageBox.Show("You must choose a sex for the participant!");
            else
            {
                done = true;
                Close();
            }
        }
    }

    public class ParticipantInfos
    {
        public int? Age { get; set; }
        public string Name { get; set; } = "";
        public Sex? Sex { get; set; }
    }
}
