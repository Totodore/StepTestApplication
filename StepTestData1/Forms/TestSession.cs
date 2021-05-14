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
    /// <summary>
    /// The test session form is just a form with a tab system that insert a TabPage form into each tabs
    /// </summary>
    public partial class TestSession : ApplicationForm
    {
        /// <summary>
        /// The list of participants
        /// </summary>
        private readonly List<ParticipantInfos> participants;
        /// <summary>
        /// The height of the step
        /// </summary>
        private readonly int stepHeight;
        /// <summary>
        /// We set attributes and we maximize the window
        /// </summary>
        /// <param name="participants">List of participants given by the previous form</param>
        /// <param name="stepHeight">Height of the step given by the previous form</param>
        public TestSession(List<ParticipantInfos> participants, int stepHeight)
        {
            this.participants = participants;
            this.stepHeight = stepHeight;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }
        /// <summary>
        /// When the test session load, for each participant we create a new tab in the tab view,
        /// then we create a new TabPage form and we insert it in the new tab
        /// We add an event handler to handle the inner form close
        /// </summary>
        private void TestSession_Load(object sender, EventArgs e)
        {
            foreach (var participant in participants)
            {
                var page = new TabPage
                { 
                    Text = participant.Name
                };
                var form = new TabTest(participant, stepHeight)
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    Visible = true,
                };
                form.BringToFront();
                form.Show();
                form.FormClosed += new FormClosedEventHandler((target, args) => OnFormClosed(participant));
                page.Controls.Add(form);
                TabView.TabPages.Add(page);
            }
        }

        /// <summary>
        /// We return on the previous view
        /// </summary>
        private void Back_Click(object sender, EventArgs e)
        {
            Switch(new AddParticipant(participants));
        }

        /// <summary>
        /// If an inner form has closed we remove the tab and the participant from the list
        /// If there is no participant now, we show a message and we get back to home
        /// </summary>
        /// <param name="participant">The participant bound to the inner form</param>
        private void OnFormClosed(ParticipantInfos participant)
        {
            TabView.TabPages.RemoveAt(participants.IndexOf(participant));
            participants.Remove(participant);
            if (participants.Count == 0)
            {
                MessageBox.Show("Test Session is ended!");
                Switch<Home>();
            }
        }
    }
}
