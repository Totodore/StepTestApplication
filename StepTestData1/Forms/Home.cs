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
    /// The home form class contains only 2 event listeners that handle the switch form to the new session or to the previous test form
    /// </summary>
    public partial class Home : ApplicationForm
    {
        public Home()
        {
            InitializeComponent();
        }

        private void NewSession_Click(object sender, EventArgs e)
        {
            Switch<AddParticipant>();
        }

        private void ConsultPrevious_Click(object sender, EventArgs e)
        {
            Switch<Previous>();
        }
    }
}
