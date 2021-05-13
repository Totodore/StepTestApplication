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
    public partial class TabTest : Form
    {
        public ParticipantInfos participant;
        public TabTest(ParticipantInfos participant)
        {
            this.participant = participant;
            InitializeComponent();
        }
    }
}
