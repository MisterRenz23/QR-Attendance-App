using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project_001
{
    public partial class ViewAttedanceRecord : Form
    {

        private DateTime testDate = DateTime.Now;

        // Define the connection string
        private string connectionString = @"server=localhost;database=user_infotb;userid=root;password=;";
        public ViewAttedanceRecord()
        {
            InitializeComponent();
            LoadAttendanceData();
            this.FormClosed += AttendanceRecordForm_FormClosed; // Attach the FormClosed event
        }

        private void AttendanceRecordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Reopen the main screen page
            mainScreenPage mainForm = new mainScreenPage();
            mainForm.Show();
        }

        private void LoadAttendanceData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Use the test date for the query
                    string query = "SELECT FirstName, LastName, ScanTime FROM attendance_tb WHERE ScanDate = @ScanDate ORDER BY ScanTime ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ScanDate", testDate.ToString("yyyy-MM-dd"));

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Add a new column for the Number (#1, #2, etc.)
                            dt.Columns.Add("Number", typeof(int)).SetOrdinal(0);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dt.Rows[i]["Number"] = i + 1;
                            }

                            // Bind the DataTable to the DataGridView
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading attendance records: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ViewAttedanceRecord_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
