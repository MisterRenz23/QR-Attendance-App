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
using System.Diagnostics;

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

                    // Use exact match for ID
                    string query = "SELECT FirstName, LastName, Birthday, Gender, PhotoPath, StartDate, IsBlocked FROM registration_tb WHERE ID = @ID";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Clear the DataGridView to remove data from the previous user
                                dataGridView1.Rows.Clear();

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

                                // Set a fixed start date for counting absences from October 1, 2024
                                DateTime absenceStartDate = new DateTime(2024, 10, 1);

                                // Check absences from October 1, 2024
                                CheckAbsencesAndBlockAccount(id, absenceStartDate);

                                // Check if the student is blocked and show the block message AFTER displaying details and absences
                                if (Convert.ToBoolean(reader["IsBlocked"]))
                                {
                                    ShowStatusMessage("Account has been blocked due to 3 or more absences.", "#FF0000", 5);  // Blocked message displayed
                                }
                                else
                                {
                                    // Record attendance if the account is not blocked
                                    RecordAttendance(id, reader["FirstName"].ToString(), reader["LastName"].ToString());
                                }
                            }
                            else
                            {
                                // Clear the textboxes and DataGridView if no user found
                                ClearTextBoxes();
                                dataGridView1.Rows.Clear();  // Ensure the grid is cleared if user is not found
                                ShowStatusMessage("User not found!", "#FF0000");  // Error message for user not found
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
                ShowStatusMessage("An error occurred: " + ex.Message, "#FF0000");  // Display error message
            }
        }


        private void SetStartDate(string id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Set the start date to October 1, 2024, regardless of when the student scans
                    string fixedStartDate = "2024-10-01";

                    // Update the StartDate field in the registration table
                    string updateQuery = "UPDATE registration_tb SET StartDate = @StartDate WHERE ID = @ID";

                    using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", fixedStartDate);
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
                    string attendanceQuery = "SELECT ScanDate FROM attendance_tb WHERE ID = @ID ORDER BY ScanDate";
                    List<DateTime> scanDates = new List<DateTime>();

                    using (SQLiteCommand cmd = new SQLiteCommand(attendanceQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Store only the date part (ignore time)
                                DateTime scanDate = Convert.ToDateTime(reader["ScanDate"]).Date;
                                scanDates.Add(scanDate);
                            }
                        }
                    }

                    // Clear the DataGridView before populating
                    dataGridView1.Rows.Clear();

                    // Calculate absences from October 1, 2024 until the day before the current scan
                    DateTime currentDate = DateTime.Now.Date;  // Use the current date without time
                    int absences = 0;
                    int noCount = 1;  // Track the "No." column

                    // Check for absences between October 1, 2024, and the day before the current scan
                    for (DateTime date = startDate.Date; date < currentDate; date = date.AddDays(1))
                    {
                        // We are counting all days, including weekends

                        // If the date is not in the scanned dates list, it counts as an absence
                        if (!scanDates.Contains(date))
                        {
                            absences++;
                            Debug.WriteLine("Absence on {0}", date);  // Log each absence date for debugging

                            // Add the absence details to the DataGridView
                            dataGridView1.Rows.Add(noCount, date.ToString("yyyy-MM-dd"));
                            noCount++;  // Increment the "No." count
                        }
                    }

                    // Log the total number of absences
                    Debug.WriteLine("Total absences for user {0}: {1}", id, absences);

                    // Check if the student has 3 or more absences
                    if (absences >= 3)
                    {
                        // Block the account
                        string blockQuery = "UPDATE registration_tb SET IsBlocked = TRUE WHERE ID = @ID";

                        using (SQLiteCommand cmd = new SQLiteCommand(blockQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID", id);
                            cmd.ExecuteNonQuery();
                        }
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
                    Debug.WriteLine("Scanned ID: " + id);

                    // Check if the user exists in the registration_tb and if the user is blocked
                    string checkUserQuery = "SELECT IsBlocked FROM registration_tb WHERE ID = @ID";

                    using (SQLiteCommand checkUserCmd = new SQLiteCommand(checkUserQuery, conn))
                    {
                        checkUserCmd.Parameters.AddWithValue("@ID", id);
                        object result = checkUserCmd.ExecuteScalar();

                        // If the user is not found, result will be null
                        if (result == null)
                        {
                            ShowStatusMessage("User not found!", "#FF0000");  // Red color for error
                            return; // Stop further execution, no user found
                        }

                        // Check if the user is blocked
                        bool isBlocked = Convert.ToBoolean(result);

                        // If the account is blocked, show message and exit the function
                        if (isBlocked)
                        {
                            ShowStatusMessage("Account has been blocked due to 3 or more absences.", "#FF0000");  // Red color for block message
                            return; // Stop further execution, don't record attendance
                        }
                    }

                    // Use C#'s DateTime to capture the correct date and time
                    string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                    string currentTime = DateTime.Now.ToString("HH:mm:ss");

                    // Check if the user has already scanned today
                    string checkQuery = "SELECT COUNT(*) FROM attendance_tb WHERE ID = @ID AND ScanDate = @ScanDate";

                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ID", id);
                        checkCmd.Parameters.AddWithValue("@ScanDate", currentDate);

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count == 0)
                        {
                            // Insert attendance record if not already scanned today
                            string insertQuery = "INSERT INTO attendance_tb (ID, FirstName, LastName, ScanDate, ScanTime, AlreadyScanned) " +
                                                 "VALUES (@ID, @FirstName, @LastName, @ScanDate, @ScanTime, TRUE)";

                            using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@ID", id);
                                insertCmd.Parameters.AddWithValue("@FirstName", firstName);
                                insertCmd.Parameters.AddWithValue("@LastName", lastName);
                                insertCmd.Parameters.AddWithValue("@ScanDate", currentDate); // Use C#'s current date
                                insertCmd.Parameters.AddWithValue("@ScanTime", currentTime); // Use C#'s current time

                                insertCmd.ExecuteNonQuery();

                                ShowStatusMessage("Attendance recorded successfully.", "#7ED957");  // Custom green color for success
                            }
                        }
                        else
                        {
                            ShowStatusMessage("This user has already scanned today.", "#7ED957");  // Use the custom green color for already scanned
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage("An error occurred while recording attendance: " + ex.Message, "#FF0000");  // Red color for error message
            }
        }

        private void CheckAbsencesAndUpdateBlockStatus(string studentId, DateTime startDate)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Query to get all attendance records for this student
                    string attendanceQuery = "SELECT ScanDate FROM attendance_tb WHERE ID = @ID ORDER BY ScanDate";
                    List<DateTime> scanDates = new List<DateTime>();

                    using (SQLiteCommand cmd = new SQLiteCommand(attendanceQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", studentId);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Store only the date part (ignore time)
                                DateTime scanDate = Convert.ToDateTime(reader["ScanDate"]).Date;
                                scanDates.Add(scanDate);
                            }
                        }
                    }

                    // Calculate absences from October 1, 2024, until today
                    DateTime currentDate = DateTime.Now.Date;  // Use the current date without time
                    int absences = 0;

                    // Check for absences between startDate and the day before the current date
                    for (DateTime date = startDate.Date; date < currentDate; date = date.AddDays(1))
                    {
                        // If the date is not in the scanned dates list, it counts as an absence
                        if (!scanDates.Contains(date))
                        {
                            absences++;
                        }
                    }

                    // Block the account if the student has 3 or more absences
                    string updateQuery;
                    if (absences >= 3)
                    {
                        updateQuery = "UPDATE registration_tb SET IsBlocked = 1 WHERE ID = @ID";
                    }
                    else
                    {
                        updateQuery = "UPDATE registration_tb SET IsBlocked = 0 WHERE ID = @ID";
                    }

                    using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@ID", studentId);
                        updateCmd.ExecuteNonQuery();
                    }

                    // Optionally, log or display the total absences for the student
                    Debug.WriteLine($"Total absences for user {studentId}: {absences}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking absences: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ShowStatusMessage(string message, string hexColor, int durationInSeconds = 2)
        {
            // Set the text and background color using the hex color
            statusLabel.Text = message;
            statusLabel.BackColor = ColorTranslator.FromHtml(hexColor);
            statusLabel.Visible = true;

            // Create a timer to hide the message after a few seconds
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = durationInSeconds * 1000;  // Convert seconds to milliseconds
            timer.Tick += (s, e) =>
            {
                statusLabel.Visible = false;  // Hide the label after the duration
                timer.Stop();  // Stop the timer
            };
            timer.Start();
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
            timer1.Start();
            label6.Text = DateTime.Now.ToLongTimeString();
            label7.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            // Set the flag to indicate we're navigating to another form
            isNavigatingToAnotherForm = true;

            // Close the current form and open AttendanceRecordForm
            this.Close();
            ViewAttendanceRecord scannedUsersForm = new ViewAttendanceRecord();
            scannedUsersForm.Show();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            var newForm = new actionPage();
            newForm.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
