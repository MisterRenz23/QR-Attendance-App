using Project_001.Action;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_001
{
    public partial class AccountStatusPage : Form
    {

        private string connectionString = "Data Source=attendance.db;Version=3;";
        public AccountStatusPage()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AccountStatusPage_Load(object sender, EventArgs e)
        {
            // Set DataGridView to select full row
            dataGridViewAttendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Load all attendance records or any other setup
            LoadAllAttendanceRecords();
        }

        private void RefreshAttendanceAndAbsenceRecords(string studentId, DateTime absenceStartDate)
        {
            // Refresh attendance records
            LoadAttendanceRecords(studentId);

            // Refresh absence records
            LoadAbsenceRecords(studentId, absenceStartDate);

            // Refresh the DataGridViews
            dataGridViewAttendance.Refresh();
            dataGridViewAbsences.Refresh();

            // Check absences and block account if necessary
            CheckAbsencesAndUpdateBlockStatus(studentId, absenceStartDate);

            // Update status label
            UpdateStatusLabel(studentId);
        }

        private (string firstName, string lastName, bool isBlocked) FetchStudentDetails(string studentId)
        {
            string firstName = string.Empty;
            string lastName = string.Empty;
            bool isBlocked = false;

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string studentQuery = "SELECT FirstName, LastName, IsBlocked FROM registration_tb WHERE ID = @ID";
                    using (SQLiteCommand studentCmd = new SQLiteCommand(studentQuery, conn))
                    {
                        studentCmd.Parameters.AddWithValue("@ID", studentId);
                        using (SQLiteDataReader reader = studentCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                firstName = reader["FirstName"].ToString();
                                lastName = reader["LastName"].ToString();
                                isBlocked = Convert.ToBoolean(reader["IsBlocked"]);
                            }
                            else
                            {
                                MessageBox.Show("Student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching student details: " + ex.Message);
            }

            return (firstName, lastName, isBlocked);
        }


        private void UpdateStatusLabel(string studentId)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Query to get the student's IsBlocked status
                    string query = "SELECT IsBlocked FROM registration_tb WHERE ID = @ID";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", studentId);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bool isBlocked = Convert.ToBoolean(reader["IsBlocked"]);

                                // Update the status label based on the IsBlocked value
                                if (isBlocked)
                                {
                                    labelStatus.Text = "Status: BLOCKED";
                                    labelStatus.ForeColor = Color.Red;
                                    labelStatus.Font = new Font(labelStatus.Font.FontFamily, 20, FontStyle.Bold);
                                }
                                else
                                {
                                    labelStatus.Text = "Status: ACTIVE";
                                    labelStatus.ForeColor = Color.LightGreen;
                                    labelStatus.Font = new Font(labelStatus.Font.FontFamily, 20, FontStyle.Bold);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status label: " + ex.Message);
            }
        }
        private void LoadAllAttendanceRecords()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT AttendanceID, ScanDate, ScanTime FROM attendance_tb ORDER BY ScanDate ASC";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Display attendance records in the DataGridView
                        dataGridViewAttendance.DataSource = dt;

                        // Ensure only the AttendanceID, ScanDate, and ScanTime columns are shown
                        if (dataGridViewAttendance.Columns["AttendanceID"] != null)
                        {
                            dataGridViewAttendance.Columns["AttendanceID"].HeaderText = "Attendance ID";
                            dataGridViewAttendance.Columns["AttendanceID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }

                        if (dataGridViewAttendance.Columns["ScanDate"] != null)
                        {
                            dataGridViewAttendance.Columns["ScanDate"].HeaderText = "Date";
                            dataGridViewAttendance.Columns["ScanDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }

                        if (dataGridViewAttendance.Columns["ScanTime"] != null)
                        {
                            dataGridViewAttendance.Columns["ScanTime"].HeaderText = "Time";
                            dataGridViewAttendance.Columns["ScanTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }

                        // Hide all other columns (if any)
                        foreach (DataGridViewColumn column in dataGridViewAttendance.Columns)
                        {
                            if (column.Name != "AttendanceID" && column.Name != "ScanDate" && column.Name != "ScanTime")
                            {
                                column.Visible = false;
                            }
                        }

                        // Auto-resize the columns to fit the content
                        dataGridViewAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridViewAttendance.RowHeadersVisible = false;  // Optionally, hide row headers (empty first column)
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance records: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteAttendanceRecord(string id)
        {
            // Replace this with your actual database delete logic
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=attendance.db;Version=3;"))
            {
                conn.Open();
                string query = "DELETE FROM attendance_tb WHERE AttendanceID = @AttendanceID";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AttendanceID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LoadAttendanceRecords(string studentId)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string query;
                    if (string.IsNullOrEmpty(studentId))
                    {
                        // Query to get all attendance records
                        query = "SELECT AttendanceID, ID, ScanDate, ScanTime FROM attendance_tb ORDER BY ScanDate ASC";
                    }
                    else
                    {
                        // Query to get attendance records for a specific student
                        query = "SELECT AttendanceID, ID, ScanDate, ScanTime FROM attendance_tb WHERE ID = @ID ORDER BY ScanDate ASC";
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(studentId))
                        {
                            // Set the student ID parameter
                            cmd.Parameters.AddWithValue("@ID", studentId);
                        }

                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Display attendance records in the DataGridView
                        dataGridViewAttendance.DataSource = dt;

                        // Ensure only the AttendanceID, ID, ScanDate, and ScanTime columns are shown
                        if (dataGridViewAttendance.Columns["AttendanceID"] != null)
                        {
                            dataGridViewAttendance.Columns["AttendanceID"].HeaderText = "Attendance ID";
                            dataGridViewAttendance.Columns["AttendanceID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }

                        if (dataGridViewAttendance.Columns["ID"] != null)
                        {
                            dataGridViewAttendance.Columns["ID"].HeaderText = "Student ID"; // Ensure the student ID column is visible
                            dataGridViewAttendance.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridViewAttendance.Columns["ID"].Visible = false; // Optionally hide the ID column if you don't want to display it
                        }

                        if (dataGridViewAttendance.Columns["ScanDate"] != null)
                        {
                            dataGridViewAttendance.Columns["ScanDate"].HeaderText = "Date";
                            dataGridViewAttendance.Columns["ScanDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }

                        if (dataGridViewAttendance.Columns["ScanTime"] != null)
                        {
                            dataGridViewAttendance.Columns["ScanTime"].HeaderText = "Time";
                            dataGridViewAttendance.Columns["ScanTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }

                        // Auto-resize the columns to fit the content
                        dataGridViewAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridViewAttendance.RowHeadersVisible = false;  // Optionally, hide row headers (empty first column)
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance records: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void InsertRecordBtn_Click_1(object sender, EventArgs e)
        {
            string studentId = txtStudentId.Text.Trim();
            DateTime attendanceDate = dateTimePickerAttendanceDate.Value.Date;
            DateTime attendanceTime = DateTime.Now;

            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("Please enter a valid Student ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var (firstName, lastName, isBlocked) = FetchStudentDetails(studentId);

            if (string.IsNullOrEmpty(firstName))
            {
                // No student found, exit early
                return;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Check if the student already has an attendance record for the selected date
                    string checkQuery = "SELECT COUNT(*) FROM attendance_tb WHERE ID = @ID AND ScanDate = @ScanDate";
                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ID", studentId);
                        checkCmd.Parameters.AddWithValue("@ScanDate", attendanceDate.ToString("yyyy-MM-dd"));

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("The student has already been recorded for this date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Insert the new attendance record
                    string insertQuery = "INSERT INTO attendance_tb (ID, FirstName, LastName, ScanDate, ScanTime, AlreadyScanned) " +
                                         "VALUES (@ID, @FirstName, @LastName, @ScanDate, @ScanTime, @AlreadyScanned)";
                    using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", studentId);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@ScanDate", attendanceDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@ScanTime", attendanceTime.ToString("HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@AlreadyScanned", true);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Attendance record inserted successfully!");

                    // Refresh data
                    RefreshAttendanceAndAbsenceRecords(studentId, new DateTime(2024, 10, 1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting attendance record: " + ex.Message);
            }
        }




        private void LoadAbsenceRecords(string studentId, DateTime startDate)
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

                    // Clear the DataGridView before populating it with new data
                    dataGridViewAbsences.Rows.Clear();
                    dataGridViewAbsences.Columns.Clear(); // Clear any old columns

                    // Add necessary columns if they do not exist
                    dataGridViewAbsences.Columns.Add("No", "No.");
                    dataGridViewAbsences.Columns.Add("Date", "Absence Date");

                    // Calculate absences from the start date until the current date
                    DateTime currentDate = DateTime.Now.Date;
                    int absences = 0;
                    int noCount = 1;  // Track the "No." column

                    // Loop through each date from the start date to the current date
                    for (DateTime date = startDate.Date; date < currentDate; date = date.AddDays(1))
                    {
                        // If the date is not in the scanned dates list, it counts as an absence
                        if (!scanDates.Contains(date))
                        {
                            absences++;

                            // Add the absence details to the DataGridView
                            dataGridViewAbsences.Rows.Add(noCount, date.ToString("yyyy-MM-dd"));
                            noCount++;  // Increment the "No." count
                        }
                    }

                    // Check if there are no absences to show a message
                  //  if (absences == 0)
                   // {
                      //  MessageBox.Show("No absences found for the student.");
                   // }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading absence record: " + ex.Message);
            }
        }







        // Clear student details in case no record is found
        private void ClearStudentDetails()
        {
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxBirthday.Clear();
            textBoxGender.Clear();
            pictureBoxStudentPhoto.Image = null;
            labelStatus.Text = "Status: N/A";

        }


        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            string studentId = txtStudentId.Text.Trim(); // Get the inputted ID from the TextBox

            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("Please enter a valid student ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Query to fetch the student's details
                    string studentQuery = "SELECT FirstName, LastName, Birthday, Gender, PhotoPath, IsBlocked FROM registration_tb WHERE ID = @ID";

                    using (SQLiteCommand studentCmd = new SQLiteCommand(studentQuery, conn))
                    {
                        studentCmd.Parameters.AddWithValue("@ID", studentId);

                        using (SQLiteDataReader reader = studentCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Make the textboxes read-only and greyed out
                                textBoxFirstName.ReadOnly = true;
                                textBoxFirstName.BackColor = Color.LightGray;

                                textBoxLastName.ReadOnly = true;
                                textBoxLastName.BackColor = Color.LightGray;

                                textBoxBirthday.ReadOnly = true;
                                textBoxBirthday.BackColor = Color.LightGray;

                                textBoxGender.ReadOnly = true;
                                textBoxGender.BackColor = Color.LightGray;

                                // Populate the textboxes with the student's details
                                textBoxFirstName.Text = reader["FirstName"].ToString();
                                textBoxLastName.Text = reader["LastName"].ToString();
                                textBoxBirthday.Text = Convert.ToDateTime(reader["Birthday"]).ToString("yyyy-MM-dd");
                                textBoxGender.Text = reader["Gender"].ToString();

                                // Show student photo if available
                                string photoPath = reader["PhotoPath"].ToString();
                                if (!string.IsNullOrEmpty(photoPath) && System.IO.File.Exists(photoPath))
                                {
                                    pictureBoxStudentPhoto.Image = Image.FromFile(photoPath);
                                }
                                else
                                {
                                    pictureBoxStudentPhoto.Image = null; // Clear if no photo is available
                                }

                                // Set student status (ACTIVE/BLOCKED)
                                bool isBlocked = Convert.ToBoolean(reader["IsBlocked"]);
                                if (isBlocked)
                                {
                                    // Blocked: Red color, bold, and large
                                    labelStatus.Text = "Status: BLOCKED";
                                    labelStatus.ForeColor = Color.Red;
                                    labelStatus.Font = new Font(labelStatus.Font.FontFamily, 20, FontStyle.Bold);
                                }
                                else
                                {
                                    // Active: Light Green color, bold, and large
                                    labelStatus.Text = "Status: ACTIVE";
                                    labelStatus.ForeColor = Color.LightGreen;
                                    labelStatus.Font = new Font(labelStatus.Font.FontFamily, 20, FontStyle.Bold);
                                }

                                // Dynamically position labelStatus below the pictureBoxStudentPhoto and center it
                                int pictureBoxX = pictureBoxStudentPhoto.Location.X;
                                int pictureBoxWidth = pictureBoxStudentPhoto.Width;
                                int pictureBoxBottom = pictureBoxStudentPhoto.Bottom;

                                // Center the label below the pictureBox
                                labelStatus.Location = new Point(
                                    pictureBoxX + (pictureBoxWidth / 2) - (labelStatus.Width / 2),
                                    pictureBoxBottom + 10 // 10 pixels below the picture box
                                );
                            }
                            else
                            {
                                MessageBox.Show("Student not found!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearStudentDetails();
                                return; // Exit if student is not found
                            }
                        }
                    }

                    // Query to fetch the student's attendance records
                    LoadAttendanceRecords(studentId); // Load attendance records into the grid

                    // Query to fetch the student's absence records (starting from October 1, 2024)
                    DateTime absenceStartDate = new DateTime(2024, 10, 1);  // Absences are calculated from October 1, 2024
                    LoadAbsenceRecords(studentId, absenceStartDate);  // Load absence records into the grid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving student details: " + ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewAttendance.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewAttendance.SelectedRows[0];
                string selectedAttendanceID = selectedRow.Cells["AttendanceID"].Value.ToString();
                string studentId = txtStudentId.Text.Trim();

                try
                {
                    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();

                        string deleteQuery = "DELETE FROM attendance_tb WHERE AttendanceID = @AttendanceID";
                        using (SQLiteCommand cmd = new SQLiteCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@AttendanceID", selectedAttendanceID);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Attendance record deleted successfully!");

                        // Refresh data
                        RefreshAttendanceAndAbsenceRecords(studentId, new DateTime(2024, 10, 1));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting the record: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }



        private void BackBtn_Click(object sender, EventArgs e)
        {
            var newForm = new actionPage();
            newForm.Show();
            this.Hide();
        }

        private void InsertRecordBtn_Click(object sender, EventArgs e)
        {

        }

        private void labelStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
