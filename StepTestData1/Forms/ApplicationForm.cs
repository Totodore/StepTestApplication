using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace StepTestData1
{

    /// <summary>
    /// This custom abstract class is made to handle the form switching, the material design and some global parameters.
    /// The switching functionnality is made so that we can switch all form (closing one and opening another) without just hiding one (because it would keep it in memory)
    /// Because if we try to close the first form with a basic configuration the entire app closes. So we have to detach the first form from the app <see cref="Program"/>
    /// However by doing that if the window red cross is clicked the form will close but the app will continue to run in background.
    /// So there is a custom event handling that determine if the user as a clicked on the cross or if we called the close method from the switch method.
    /// If the user click on the red cross the app will be exit (code 0). But if we called Switch or Close in the code, just the form will be closes
    /// </summary>
    public class ApplicationForm : MaterialForm
    {
        private bool calledClose = false;

        public ApplicationForm()
        {
            FormClosing += OnFormClose;

            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.DeepPurple900, Primary.DeepPurple900,
                Primary.DeepPurple600, Accent.DeepPurple700,
                TextShade.WHITE
            );
            FormBorderStyle = FormBorderStyle.Sizable;
            StartPosition = FormStartPosition.CenterScreen;
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

        /// <summary>
        /// Switch method with a typeparameter 
        /// </summary>
        /// <typeparam name="T">The new form to switch</typeparam>
        public void Switch<T>() where T : Form, new()
        {
            var f = new T();
            f.Show();
            Close();
        }
        /// <summary>
        /// Switch method with a form instance parameter
        /// This overload is made so that we can pass args to the new form constructor
        /// </summary>
        /// <param name="form">The new form to switch</param>
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
        private void OnFormClose(Object target, FormClosingEventArgs e)
        {
            if (!calledClose)
                Application.Exit();
        }
    }
}
