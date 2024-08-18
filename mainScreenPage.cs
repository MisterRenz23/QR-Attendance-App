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
using System.Timers;

namespace Project_001
{
    public partial class mainScreenPage : Form
    {

        // Define the connection string
        private string connectionString = @"server=localhost;database=user_infotb;userid=root;password=;";
        private System.Windows.Forms.Timer inputTimer;
        private bool inputInProgress = false;
     
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

        // Event handler for when the ID TextBox receives input
        private void txtId_TextChanged(object sender, EventArgs e)
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
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT FirstName, LastName, Birthday, Gender, Photo FROM registration_tb WHERE ID = @ID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        

                        using (MySqlDataReader reader = cmd.ExecuteReader())
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

                                // Retrieve and display the photo
                                if (reader["Photo"] != DBNull.Value)
                                {
                                    byte[] photoBytes = (byte[])reader["Photo"];
                                    using (var ms = new System.IO.MemoryStream(photoBytes))
                                    {
                                        pictureBox1.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    pictureBox1.Image = null; // Clear the picture box if no photo is found
                                }
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
        private void ClearTextBoxes()
        {
            scanned_id.Text = string.Empty;
            firstName_text.Text = string.Empty;
            firstName_text.Text = string.Empty;
            lastName_text.Text = string.Empty;
            birthday_text.Text = string.Empty;

        }


        private void mainScreenPage_Load(object sender, EventArgs e)
        {

        }
    }
}
