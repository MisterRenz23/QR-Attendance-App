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

namespace Project_001
{
    public partial class ViewAttendanceRecord : Form
    {

        private string connectionString = "Data Source=attendance.db;Version=3;";
        private DateTime testDate = DateTime.Now; // Use DateTime.Now or set a specific date for testing

        public ViewAttendanceRecord()
        {
            InitializeComponent();
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

                    // Use the test date for the query
                    string query = "SELECT ID, FirstName, LastName, ScanDate, ScanTime FROM attendance_tb WHERE AlreadyScanned = 1 AND ScanDate = @ScanDate";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        // Use the testDate in the parameter
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

    }
}
