﻿using System;
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
    public partial class TestSession : ApplicationForm
    {
        private readonly List<ParticipantInfos> participants;
        private readonly int stepHeight;
        public TestSession(List<ParticipantInfos> participants, int stepHeight)
        {
            this.participants = participants;
            this.stepHeight = stepHeight;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

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

        private void TabView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Switch(new AddParticipant(participants));
        }

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
