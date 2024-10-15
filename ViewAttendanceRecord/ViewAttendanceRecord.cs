using Project_001.Action;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ClosedXML.Excel; // Add this import for ClosedXML

namespace Project_001
{
    public partial class ViewAttendanceRecord : Form
    {

        private string connectionString = "Data Source=attendance.db;Version=3;";
        private DateTime testDate = DateTime.Now; // Use DateTime.Now or set a specific date for testing
        private bool isNavigatingToAnotherForm = false;

        public ViewAttendanceRecord()
        {
            InitializeComponent();

            //Realtime date and time
            timer1.Start();
            label1.Text = DateTime.Now.ToLongDateString();

            //testDate = new DateTime(2024, 8, 29);
            LoadScannedUsers();
            this.FormClosed += ViewAttendanceRecord_FormClosed;
        }

        private void ViewAttendanceRecord_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void LoadScannedUsers()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // SQL query to retrieve data for the current day
                    string query = @"
                SELECT attendance_tb.ID, attendance_tb.FirstName, attendance_tb.LastName, attendance_tb.ScanDate, attendance_tb.ScanTime 
                FROM attendance_tb
                INNER JOIN registration_tb ON attendance_tb.ID = registration_tb.ID
                WHERE attendance_tb.AlreadyScanned = 1 
                AND attendance_tb.ScanDate = @ScanDate
                AND registration_tb.IsBlocked = 0"; // Only include users who are not blocked

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ScanDate", testDate.ToString("yyyy-MM-dd"));

                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Add a new column for the Number (#1, #2, etc.)
                        dt.Columns.Add("Number", typeof(int)).SetOrdinal(0);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dt.Rows[i]["Number"] = i + 1;
                        }

                        // Bind the DataTable to the DataGridView
                        dataGridViewScannedUsers.DataSource = dt;
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToLongDateString();
        }

        private void ViewAttendanceRecord_Load(object sender, EventArgs e)
        {

        }

        // New method to export today's attendance to Excel
        private void ExportAttendanceForDay(DateTime selectedDate)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Workbook|*.xlsx";
                    sfd.Title = "Save Attendance Record as Excel File";
                    sfd.FileName = $"AttendanceRecord_{selectedDate:yyyyMMdd}.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            // Fetch records for the selected date
                            DataTable dt = FetchAttendanceForDate(selectedDate);

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                // Create a new worksheet
                                var worksheet = workbook.Worksheets.Add("AttendanceRecord");

                                // Manually set the headers
                                worksheet.Cell(1, 1).Value = "No.";
                                worksheet.Cell(1, 2).Value = "First Name";
                                worksheet.Cell(1, 3).Value = "Last Name";
                                worksheet.Cell(1, 4).Value = "Scan Date";
                                worksheet.Cell(1, 5).Value = "Scan Time";

                                // Populate the worksheet with data from the DataTable
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    worksheet.Cell(i + 2, 1).Value = Convert.ToInt32(dt.Rows[i]["Number"]);
                                    worksheet.Cell(i + 2, 2).Value = dt.Rows[i]["FirstName"].ToString();
                                    worksheet.Cell(i + 2, 3).Value = dt.Rows[i]["LastName"].ToString();
                                    worksheet.Cell(i + 2, 4).Value = DateTime.Parse(dt.Rows[i]["ScanDate"].ToString()).ToString("yyyy-MM-dd");
                                    worksheet.Cell(i + 2, 5).Value = DateTime.Parse(dt.Rows[i]["ScanTime"].ToString()).ToString("HH:mm:ss");
                                }

                                // Optionally, adjust the column width to fit the content
                                worksheet.Columns().AdjustToContents();

                                // Apply center alignment to all data cells
                                var dataRange = worksheet.RangeUsed();
                                dataRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                                // Bold the header row
                                worksheet.Row(1).Style.Font.Bold = true;

                                // Save the workbook to the selected file path
                                workbook.SaveAs(sfd.FileName);
                                MessageBox.Show("Data successfully exported to Excel!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No data available for the selected date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private DataTable FetchAttendanceForDate(DateTime selectedDate)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                    SELECT attendance_tb.ID, attendance_tb.FirstName, attendance_tb.LastName, attendance_tb.ScanDate, attendance_tb.ScanTime 
                    FROM attendance_tb
                    WHERE attendance_tb.ScanDate = @ScanDate";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ScanDate", selectedDate.ToString("yyyy-MM-dd"));

                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                        adapter.Fill(dt);

                        dt.Columns.Add("Number", typeof(int)).SetOrdinal(0);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dt.Rows[i]["Number"] = i + 1;
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }


        // New method to export to Excel
        private void ExportToExcel()
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Workbook|*.xlsx";
                    sfd.Title = "Save Attendance Record as Excel File";
                    sfd.FileName = $"AttendanceRecord_{DateTime.Now:yyyyMMdd}.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            // Fetch all records from the database instead of using the DataGridView
                            DataTable dt = FetchAllAttendanceRecords();

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                // Create a new worksheet
                                var worksheet = workbook.Worksheets.Add("AttendanceRecord");

                                // Manually set the headers
                                worksheet.Cell(1, 1).Value = "No.";
                                worksheet.Cell(1, 2).Value = "First Name";
                                worksheet.Cell(1, 3).Value = "Last Name";
                                worksheet.Cell(1, 4).Value = "Scan Date";
                                worksheet.Cell(1, 5).Value = "Scan Time";

                                // Populate the worksheet with data from the DataTable
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    // Explicitly cast each value to the correct type
                                    worksheet.Cell(i + 2, 1).Value = Convert.ToInt32(dt.Rows[i]["Number"]);
                                    worksheet.Cell(i + 2, 2).Value = dt.Rows[i]["FirstName"].ToString();
                                    worksheet.Cell(i + 2, 3).Value = dt.Rows[i]["LastName"].ToString();
                                    worksheet.Cell(i + 2, 4).Value = DateTime.Parse(dt.Rows[i]["ScanDate"].ToString()).ToString("yyyy-MM-dd");
                                    worksheet.Cell(i + 2, 5).Value = DateTime.Parse(dt.Rows[i]["ScanTime"].ToString()).ToString("HH:mm:ss");
                                }

                                // Optionally, adjust the column width to fit the content
                                worksheet.Columns().AdjustToContents();

                                // Apply center alignment to all data
                                var dataRange = worksheet.RangeUsed();
                                dataRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                                // Bold the header row
                                worksheet.Row(1).Style.Font.Bold = true;

                                // Save the workbook to the selected file path
                                workbook.SaveAs(sfd.FileName);
                                MessageBox.Show("All data successfully exported to Excel!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No data available to export.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable FetchAllAttendanceRecords()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT attendance_tb.ID, attendance_tb.FirstName, attendance_tb.LastName, attendance_tb.ScanDate, attendance_tb.ScanTime 
                FROM attendance_tb";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                        adapter.Fill(dt);

                        dt.Columns.Add("Number", typeof(int)).SetOrdinal(0);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dt.Rows[i]["Number"] = i + 1;
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        // Button click event for exporting to Excel


        private void btnExportToExcel_Click_1(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        private void BackBtn_Click(object sender, EventArgs e)
        {
            var newForm = new mainScreenPage();
            newForm.Show();
            this.Hide();
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void dataGridViewScannedUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            // Get the selected date from the DateTimePicker
            DateTime selectedDate = dateTimePicker1.Value.Date;

            // Call the export function with the selected date
            ExportAttendanceForDay(selectedDate);
        }

        private void ExportAbsenceSummaryToExcel(DataTable absenceSummary)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Workbook|*.xlsx";
                    sfd.Title = "Save Absence Summary as Excel File";
                    sfd.FileName = $"AbsenceSummary_{DateTime.Now:yyyyMMdd}.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            // Create two separate worksheets for active and blocked accounts
                            var activeWorksheet = workbook.Worksheets.Add("Active Accounts");
                            var blockedWorksheet = workbook.Worksheets.Add("Blocked Accounts");

                            // Set headers for both worksheets
                            string[] headers = { "ID", "First Name", "Last Name", "Total Absences", "Absence Dates" };
                            for (int i = 0; i < headers.Length; i++)
                            {
                                activeWorksheet.Cell(1, i + 1).Value = headers[i];
                                blockedWorksheet.Cell(1, i + 1).Value = headers[i];
                            }

                            int activeRow = 2;
                            int blockedRow = 2;

                            // Separate the active and blocked accounts
                            foreach (DataRow row in absenceSummary.Rows)
                            {
                                bool isBlocked = Convert.ToBoolean(row["IsBlocked"]);

                                if (isBlocked)
                                {
                                    // Populate blocked worksheet
                                    blockedWorksheet.Cell(blockedRow, 1).Value = row["ID"].ToString();
                                    blockedWorksheet.Cell(blockedRow, 2).Value = row["FirstName"].ToString();
                                    blockedWorksheet.Cell(blockedRow, 3).Value = row["LastName"].ToString();
                                    blockedWorksheet.Cell(blockedRow, 4).Value = Convert.ToInt32(row["TotalAbsences"]);
                                    blockedWorksheet.Cell(blockedRow, 5).Value = row["AbsenceDates"].ToString();
                                    blockedRow++;
                                }
                                else
                                {
                                    // Populate active worksheet
                                    activeWorksheet.Cell(activeRow, 1).Value = row["ID"].ToString();
                                    activeWorksheet.Cell(activeRow, 2).Value = row["FirstName"].ToString();
                                    activeWorksheet.Cell(activeRow, 3).Value = row["LastName"].ToString();
                                    activeWorksheet.Cell(activeRow, 4).Value = Convert.ToInt32(row["TotalAbsences"]);
                                    activeWorksheet.Cell(activeRow, 5).Value = row["AbsenceDates"].ToString();
                                    activeRow++;
                                }
                            }

                            // Adjust columns for both worksheets
                            activeWorksheet.Columns().AdjustToContents();
                            blockedWorksheet.Columns().AdjustToContents();

                            // Style both worksheets (center alignment, bold headers)
                            activeWorksheet.RangeUsed().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            blockedWorksheet.RangeUsed().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            activeWorksheet.Row(1).Style.Font.Bold = true;
                            blockedWorksheet.Row(1).Style.Font.Bold = true;

                            // Save the workbook
                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Absence summary successfully exported to Excel!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting absence summary: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateIsBlockedStatus(string studentId, int totalAbsences)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // If the student has 3 or more absences, block the account (isBlocked = 1), otherwise unblock (isBlocked = 0)
                    string updateQuery = "UPDATE registration_tb SET IsBlocked = @IsBlocked WHERE ID = @ID";
                    using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", studentId);
                        cmd.Parameters.AddWithValue("@IsBlocked", totalAbsences >= 3 ? 1 : 0); // Block if 3 or more absences
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating isBlocked status for student {studentId}: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // Function to calculate absences for a student
        private (int, List<DateTime>) CalculateStudentAbsences(string id, DateTime startDate)
        {
            int absences = 0;
            List<DateTime> absenceDates = new List<DateTime>();

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

                    // Check for absences between October 1, 2024, and the current date
                    DateTime currentDate = DateTime.Now.Date;

                    for (DateTime date = startDate.Date; date < currentDate; date = date.AddDays(1))
                    {
                        // We are counting all days, including weekends

                        // If the date is not in the scanned dates list, it counts as an absence
                        if (!scanDates.Contains(date))
                        {
                            absences++;
                            absenceDates.Add(date);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating absences for ID " + id + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return (absences, absenceDates);
        }

        private void customButton2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Query to get all students from registration_tb
                    string query = "SELECT ID, FirstName, LastName FROM registration_tb";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable absenceSummary = new DataTable();
                            absenceSummary.Columns.Add("ID", typeof(string));
                            absenceSummary.Columns.Add("FirstName", typeof(string));
                            absenceSummary.Columns.Add("LastName", typeof(string));
                            absenceSummary.Columns.Add("TotalAbsences", typeof(int));
                            absenceSummary.Columns.Add("AbsenceDates", typeof(string)); // This will store the dates as a comma-separated string
                            absenceSummary.Columns.Add("IsBlocked", typeof(bool)); // Explicitly add the IsBlocked column

                            while (reader.Read())
                            {
                                string id = reader["ID"].ToString();
                                string firstName = reader["FirstName"].ToString();
                                string lastName = reader["LastName"].ToString();

                                // Set the fixed start date as October 1, 2024
                                DateTime absenceStartDate = new DateTime(2024, 10, 1);

                                // Call the method to get absences for each student
                                (int totalAbsences, List<DateTime> absenceDates) = CalculateStudentAbsences(id, absenceStartDate);

                                // ** Update the IsBlocked status based on absences **
                                UpdateIsBlockedStatus(id, totalAbsences);

                                // Only add students with at least one absence to the summary
                                if (totalAbsences > 0)
                                {
                                    DataRow row = absenceSummary.NewRow();
                                    row["ID"] = id;
                                    row["FirstName"] = firstName;
                                    row["LastName"] = lastName;
                                    row["TotalAbsences"] = totalAbsences;
                                    row["AbsenceDates"] = string.Join(", ", absenceDates.Select(d => d.ToString("yyyy-MM-dd")));

                                    // Fetch the updated IsBlocked status from the database after the update
                                    row["IsBlocked"] = totalAbsences >= 3; // If the student has 3 or more absences, they are blocked
                                    absenceSummary.Rows.Add(row);
                                }
                            }

                            // Export the summary if there are absences
                            if (absenceSummary.Rows.Count > 0)
                            {
                                ExportAbsenceSummaryToExcel(absenceSummary);
                            }
                            else
                            {
                                MessageBox.Show("No absence data available to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating absence summary: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}