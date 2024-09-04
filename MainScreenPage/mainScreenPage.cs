using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Timers;
using Project_001.Action;

namespace Project_001
{
    public partial class mainScreenPage : Form
    {

        // Define the connection string
        private string connectionString = "Data Source=attendance.db;Version=3;";
        private System.Windows.Forms.Timer inputTimer;
        private bool inputInProgress = false;
        private bool isNavigatingToAnotherForm = false;

        public mainScreenPage()
        {
            InitializeComponent();
            inputTimer = new System.Windows.Forms.Timer();
            inputTimer.Interval = 500; // Set the delay to 500 milliseconds
            inputTimer.Tick += InputTimer_Tick;
            id_text.Location = new Point(-1000, -1000);

            // Attach the FormClosed event
            this.FormClosed += mainScreenPage_FormClosed;


            scanned_id.Enabled = false;
            firstName_text.Enabled = false;
            lastName_text.Enabled = false;
            birthday_text.Enabled = false;
            gender_text.Enabled = false;

            id_text.TabIndex = 0;
            id_text.Focus();

        }

        private void mainScreenPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Only reopen the actionPage if not navigating to another form
            if (!isNavigatingToAnotherForm)
            {
                actionPage actionForm = new actionPage();
                actionForm.Show();
            }
        }

        // Event handler for when the ID TextBox receives input
        private void TxtId_TextChanged(object sender, EventArgs e)
        {
            inputTimer.Stop();
            inputTimer.Start();

            inputInProgress = true;
        }

        private void InputTimer_Tick(object sender, EventArgs e)
        {
            // Stop the timer, we don't need it to keep ticking
            inputTimer.Stop();

            // If input was in progress, process the ID
            if (inputInProgress && id_text.Text.Length > 0)
            {
                // Process the scanned ID
                RetrieveAndDisplayUserDetails(id_text.Text);
                inputInProgress = false; // Reset the flag
            }
        }

        private void RetrieveAndDisplayUserDetails(string id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT FirstName, LastName, Birthday, Gender, PhotoPath FROM registration_tb WHERE ID = @ID";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate the textboxes with user details
                                id_text.Text = string.Empty;
                                scanned_id.Text = id;
                                firstName_text.Text = reader["FirstName"].ToString();
                                lastName_text.Text = reader["LastName"].ToString();
                                birthday_text.Text = Convert.ToDateTime(reader["Birthday"]).ToString("yyyy-MM-dd");
                                gender_text.Text = reader["Gender"].ToString();

                                // Retrieve and display the photo from PhotoPath
                                string photoPath = reader["PhotoPath"].ToString();
                                if (!string.IsNullOrEmpty(photoPath) && File.Exists(photoPath))
                                {
                                    pictureBox1.Image = Image.FromFile(photoPath);
                                }
                                else
                                {
                                    pictureBox1.Image = null; // Clear the picture box if no photo is found
                                }

                                // Record attendance
                                RecordAttendance(id, reader["FirstName"].ToString(), reader["LastName"].ToString());
                            }
                            else
                            {
                                // Clear the textboxes if no user found
                                ClearTextBoxes();
                                MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecordAttendance(string id, string firstName, string lastName)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Check if the user has already scanned today
                    string checkQuery = "SELECT COUNT(*) FROM attendance_tb WHERE ID = @ID AND ScanDate = date('now')";

                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ID", id);

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count == 0)
                        {
                            // Insert attendance record
                            string insertQuery = "INSERT INTO attendance_tb (ID, FirstName, LastName, ScanDate, ScanTime, AlreadyScanned) " +
                                                 "VALUES (@ID, @FirstName, @LastName, date('now'), time('now'), TRUE)";

                            using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@ID", id);
                                insertCmd.Parameters.AddWithValue("@FirstName", firstName);
                                insertCmd.Parameters.AddWithValue("@LastName", lastName);

                                insertCmd.ExecuteNonQuery();

                                MessageBox.Show("Attendance recorded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("This user has already scanned today.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while recording attendance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearTextBoxes()
        {
            scanned_id.Text = string.Empty;
            firstName_text.Text = string.Empty;
            firstName_text.Text = string.Empty;
            lastName_text.Text = string.Empty;
            birthday_text.Text = string.Empty;

        }


        private void MainScreenPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Set the flag to indicate we're navigating to another form
            isNavigatingToAnotherForm = true;

            // Close the current form and open AttendanceRecordForm
            this.Close();
            ViewAttendanceRecord scannedUsersForm = new ViewAttendanceRecord();
            scannedUsersForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
