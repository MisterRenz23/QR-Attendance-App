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
        private bool blockMessageShown = false;

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

                    // DEBUG: Log the scanned ID to verify it's being passed correctly
                    Console.WriteLine("Scanned ID: " + id);

                    // Use exact match for ID
                    string query = "SELECT FirstName, LastName, Birthday, Gender, PhotoPath, StartDate, IsBlocked FROM registration_tb WHERE ID = @ID";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Check if the user is blocked
                                if (Convert.ToBoolean(reader["IsBlocked"]))
                                {
                                    MessageBox.Show("This account is blocked due to excessive absences.", "Account Blocked", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    // Reset necessary flags after a blocked scan
                                    blockMessageShown = false;
                                    inputInProgress = false;
                                    id_text.Text = string.Empty; // Clear the scanned input
                                    return;
                                }

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

                                DateTime? startDate = reader["StartDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["StartDate"]) : null;

                                if (startDate == null)
                                {
                                    // If this is the student's first scan, set the start date to today
                                    SetStartDate(id);
                                }
                                else
                                {
                                    // Check for absences and block the account if necessary
                                    CheckAbsencesAndBlockAccount(id, startDate.Value);
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

                            // Ensure that flags are reset after each scan
                            blockMessageShown = false;
                            inputInProgress = false;
                            id_text.Text = string.Empty; // Clear the scanned input after processing
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SetStartDate(string id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string updateQuery = "UPDATE registration_tb SET StartDate = date('now') WHERE ID = @ID";

                    using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while setting start date: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckAbsencesAndBlockAccount(string id, DateTime startDate)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Query to get all attendance records for this student
                    string attendanceQuery = "SELECT ScanDate FROM attendance_tb WHERE ID = @ID";
                    List<DateTime> scanDates = new List<DateTime>();

                    using (SQLiteCommand cmd = new SQLiteCommand(attendanceQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                scanDates.Add(Convert.ToDateTime(reader["ScanDate"]));
                            }
                        }
                    }

                    // Calculate absences from start date until today
                    DateTime currentDate = DateTime.Now;
                    int absences = 0;

                    for (DateTime date = startDate; date <= currentDate; date = date.AddDays(1))
                    {
                        // Check if the student didn't scan on this day (excluding weekends if needed)
                        if (!scanDates.Contains(date))
                        {
                            absences++;
                        }
                    }

                    if (absences >= 3)
                    {
                        // Block the account if 3 or more absences
                        string blockQuery = "UPDATE registration_tb SET IsBlocked = TRUE WHERE ID = @ID";

                        using (SQLiteCommand cmd = new SQLiteCommand(blockQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID", id);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Account has been blocked due to 3 or more absences.", "Account Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking absences: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecordAttendance(string id, string firstName, string lastName)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // DEBUG: Log scanned ID to check if it's passed correctly
                    Console.WriteLine("Scanned ID: " + id);

                    // Check if the user exists in the registration_tb and if the user is blocked
                    string checkUserQuery = "SELECT IsBlocked FROM registration_tb WHERE ID LIKE @ID";  // Use LIKE to avoid potential format mismatches

                    using (SQLiteCommand checkUserCmd = new SQLiteCommand(checkUserQuery, conn))
                    {
                        checkUserCmd.Parameters.AddWithValue("@ID", "%" + id + "%");  // Use wildcard for flexibility in matching

                        object result = checkUserCmd.ExecuteScalar();

                        // If the user is not found, result will be null
                        if (result == null)
                        {
                            MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Stop further execution, no user found
                        }

                        // Check if the user is blocked
                        bool isBlocked = Convert.ToBoolean(result);

                        // If the account is blocked, show message and exit the function
                        if (isBlocked && !blockMessageShown)
                        {
                            MessageBox.Show("Account has been blocked due to 3 or more absences.", "Account Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            blockMessageShown = true; // Set the flag to true so message won't show again
                            return; // Stop further execution, don't record attendance
                        }
                    }

                    // Reset the block message flag after a successful scan
                    blockMessageShown = false;

                    // Check if the user has already scanned today
                    string checkQuery = "SELECT COUNT(*) FROM attendance_tb WHERE ID = @ID AND ScanDate = date('now')";

                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ID", id);

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count == 0)
                        {
                            // Insert attendance record if not already scanned today
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
