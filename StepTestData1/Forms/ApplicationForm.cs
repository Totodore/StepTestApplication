using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StepTestData1
{

    /// <summary>
    /// This custom abstract class is made to handle the form switching 
    /// Without the app closing Problem. Because if we close the main form then the app will close
    /// And if we instantiate the main form before running the app, if the form closes the app will continue to run in background
    /// </summary>
    public class ApplicationForm : Form
    {
        private bool calledClose = false;

        public ApplicationForm()
        {
            FormClosing += OnFormClose;
        }

        /// <summary>
        /// We override the close methods and if it is used from a form button
        /// The app should keep running so we set the calledClose to true
        /// </summary>
        public virtual new void Close()
        {
            calledClose = true;
            base.Close();
        }

        public void Switch<T>() where T : Form, new()
        {
            var f = new T();
            f.Show();
            Close();
        }

        public void Switch(Form form)
        {
            form.Show();
            Close();
        }

        /// <summary>
        /// Event listener when the form closes
        /// If the close has been called it means that we have to only close the form and not the app
        /// If not we exit the application
        /// </summary>
        /// <param name="target"></param>
        /// <param name="e"></param>
        private void OnFormClose(Object target, FormClosingEventArgs e)
        {
            if (!calledClose)
                Application.Exit();
        }
    }
}
