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
           
        }

        private void digitalClock_Tick(object sender, EventArgs e)
        {
            clockLabel.Text = DateTime.Now.ToString("hh : mm : ss tt");
            dateLabel.Text = DateTime.Now.ToLongDateString();
        }

        private void actionPage_Load_1(object sender, EventArgs e)
        {
            digitalClock.Start();
        }

        private void checkattendanceButton_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkAttendanceBtn_Click(object sender, EventArgs e)
        {
            mainScreenPage mainscreenPage = new mainScreenPage();
            mainscreenPage.Show();
            this.Close();

        }

        private void registerNewBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the registrationPage form
            registrationPage regPage = new registrationPage();

            // Show the registrationPage form
            regPage.Show();

            // Close the current actionPage form
            this.Close();
        }
    }
}
