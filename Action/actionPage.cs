using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Project_001.Action

{
    public partial class actionPage : Form
    {

        public actionPage()
        {
            InitializeComponent();
            this.Resize += new EventHandler(ActionPage_Resize);

        }



        private void DigitalClock_Tick(object sender, EventArgs e)
        {
            clockLabel.Text = DateTime.Now.ToString("hh : mm : ss tt");
            dateLabel.Text = DateTime.Now.ToLongDateString();
        }

        private void ActionPage_Load_1(object sender, EventArgs e)
        {
            digitalClock.Start();
        }

        private void CheckAttendanceBtn_Click(object sender, EventArgs e)
        {
            mainScreenPage mainscreenPage = new mainScreenPage();
            mainscreenPage.Show();
            mainscreenPage.WindowState = this.WindowState; // Inherit the window state
            this.Hide();
        }

        private void RegisterNewBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the registrationPage form
            registrationPage regPage = new registrationPage();
            regPage.WindowState = this.WindowState; // Inherit the window state

            // Show the registrationPage form
            regPage.Show();

            // Close the current actionPage form
            this.Close();
        }

        private void AccStatusBtn_Click(object sender, EventArgs e)
        {
            AccountStatusPage accountStatusPage = new AccountStatusPage();
            accountStatusPage.WindowState = this.WindowState; // Inherit the window state
            accountStatusPage.Show();
            this.Close();
        }

        private void actionPage_SizeChanged(object sender, EventArgs e)
        {

        }

        private void ActionPage_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                // Maximize any other forms if needed, or apply further actions
                foreach (Form form in Application.OpenForms)
                {
                    form.WindowState = FormWindowState.Maximized;
                }
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                // Optionally, restore other forms to normal
                foreach (Form form in Application.OpenForms)
                {
                    form.WindowState = FormWindowState.Normal;
                }
            }
        }
    }
}
