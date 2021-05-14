using System;
using System.Windows.Forms;

namespace StepTestData1
{
    static class Program
    {
        /// <summary>
        /// We initialize the first form before the application run so that it is detached
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new Home();
            form.Show();
            Application.Run();
        }
    }
}
