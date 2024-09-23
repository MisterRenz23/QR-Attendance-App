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
            // Open the mainScreenPage form when this form is closed
            mainScreenPage mainForm = new mainScreenPage();
            mainForm.Show();
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

        private void ViewAttendanceRecord_Load(object sender, EventArgs e)
        {

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
                // Set the flag to indicate we're navigating to another form
                isNavigatingToAnotherForm = true;

                // Close the current form and open AttendanceRecordForm
                this.Close();
            mainScreenPage mainScreenPage = new mainScreenPage();

        }
    }
}