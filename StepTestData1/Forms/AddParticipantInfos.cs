using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StepTestData1
{
    public partial class AddParticipantInfos : Form
    {
        /// <summary>
        /// Current entered data in the add participant window
        /// </summary>
        private readonly ParticipantInfos infos = new ParticipantInfos();
        /// <summary>
        /// Represent if the user has clicked on done
        /// </summary>
        private bool done = false;
        public AddParticipantInfos()
        {
            InitializeComponent();
        }
        /// <summary>
        /// We set databinding with the two input and the participant object
        /// </summary>
        private void AddParticipantInfos_Load(object sender, EventArgs e)
        {
            ParticipantName.DataBindings.Add("Text", infos, "Name");
            ParticipantAge.DataBindings.Add("Text", infos, "Age", true);
        }
        /// <summary>
        /// We override Show in order to make as blocking methods that will return the participant object when 
        /// The user has clicked on done
        /// </summary>
        /// <returns></returns>
        public async new Task<ParticipantInfos> Show()
        {
            base.Show();
            while (!done)
                await Task.Delay(25);
            return infos;
        }

        /// <summary>
        /// If the user clicked on done, we set the participant Sex, then we check if all the entered data are valid
        /// If not we display an error message, else we set done as true so the blocking loop above stops and we close the window
        /// </summary>
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

    /// <summary>
    /// Represents the informations of a test participant
    /// </summary>
    public class ParticipantInfos
    {
        public int Age { get; set; }
        public string Name { get; set; } = "";
        public Sex Sex { get; set; }
    }
}
