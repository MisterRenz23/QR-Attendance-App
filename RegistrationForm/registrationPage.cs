using System.Data.SQLite;
using Project_001.Action;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Project_001

{
    public partial class registrationPage : Form
    {
        // Use SQLite connection
        private SQLiteConnection con = new SQLiteConnection("Data Source=attendance.db;Version=3;");
        private string Gender;
        private string uniqueId; // Store the unique ID generated on form load

        public registrationPage()
        {
            InitializeComponent();
            // Set the ID field to be non-editable and greyed out
            id_text.ReadOnly = true;
            id_text.BackColor = SystemColors.Control; // Greyed out look
            id_text.TabStop = false; // Skip in tab order

            // Generate and display the unique ID when the form loads
            uniqueId = GenerateUniqueID();
            id_text.Text = uniqueId;

            // Subscribe to the FormClosing event
            this.FormClosing += RegistrationPage_FormClosing;
        }


        private string GenerateUniqueID()
        {
            string id = string.Empty;
            bool isUnique = false;
            Random random = new Random();

            while (!isUnique)
            {
                // Generate ID in the format "10-(year)-(random 5 digits)", e.g., "10-24-12345"
                string yearPart = DateTime.Now.ToString("yy"); // Last two digits of the current year
                string randomPart = random.Next(10000, 99999).ToString("D5"); // 5-digit random number
                id = $"10-{yearPart}-{randomPart}";

                try
                {
                    // Check if the ID is unique in the database
                    using (SQLiteConnection conn = new SQLiteConnection(con))
                    {
                        conn.Open();
                        string query = "SELECT COUNT(*) FROM registration_tb WHERE ID = @id";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            isUnique = count == 0; // ID is unique if count is 0
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking ID uniqueness: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isUnique = false; // Continue the loop if an error occurs
                }
            }

            return id; // Ensure id is returned after being set
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Male";
        }
        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Female";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(firstName_text.Text) ||
                string.IsNullOrWhiteSpace(lastName_text.Text) ||
                string.IsNullOrWhiteSpace(birthdayPicker.Text) ||
                string.IsNullOrWhiteSpace(Gender))
            {
                MessageBox.Show("Please fill in all required fields: First Name, Last Name, Birthday, and Gender.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Use a default placeholder photo if no photo is uploaded
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = Properties.Resources.placeholder; // Replace 'placeholder' with the name of your default image resource
            }

            // Use the unique ID generated on form load
            id_text.Text = uniqueId;

            // Generate QR code
            QRCodeGenerator QG = new QRCodeGenerator();
            var MyData = QG.CreateQrCode(uniqueId, QRCodeGenerator.ECCLevel.H);
            var code = new QRCode(MyData);
            pictureBox2.Image = code.GetGraphic(100);

            try
            {
                // Save the photo to the executable directory and get the file path
                string photoPath = SavePhotoToExecutableDirectory();

                // Insert data into SQLite DB
                con.Open();
                SQLiteCommand command = new SQLiteCommand
                {
                    Connection = con,
                    CommandText = "INSERT INTO registration_tb (ID, FirstName, LastName, Birthday, Gender, PhotoPath) " +
                                  "VALUES (@id, @firstName, @lastName, @birthday, @gender, @photoPath)"
                };
                command.Parameters.AddWithValue("@id", uniqueId);
                command.Parameters.AddWithValue("@firstName", firstName_text.Text);
                command.Parameters.AddWithValue("@lastName", lastName_text.Text);
                command.Parameters.AddWithValue("@birthday", birthdayPicker.Text);
                command.Parameters.AddWithValue("@gender", Gender);
                command.Parameters.AddWithValue("@photoPath", photoPath);
                command.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Save Successful!");
                SaveQrCodeWithUserSelection();
                id_text.Clear();
                firstName_text.Clear();
                lastName_text.Clear();
                pictureBox1.Image = null;
                pictureBox2.Image = null;

                // Generate a new ID for the next entry
                uniqueId = GenerateUniqueID();
                id_text.Text = uniqueId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private string SavePhotoToExecutableDirectory()
        {
            // Get the application's base directory
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Define a folder within the base directory for storing photos
            string photosFolder = Path.Combine(baseDirectory, "Photos");

            // Ensure the Photos folder exists
            if (!Directory.Exists(photosFolder))
            {
                Directory.CreateDirectory(photosFolder);
            }

            // Create filename in the format "(unique ID)-Last Name, First Name.jpg"
            string fileName = MakeValidFileName($"{id_text.Text}-{lastName_text.Text.Trim()}, {firstName_text.Text.Trim()}.jpg");
            string fullPath = Path.Combine(photosFolder, fileName);

            // Save the image to the Photos folder
            try
            {
                pictureBox1.Image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save photo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Return the path of the saved image
            return fullPath;
        }


        private void SaveQrCodeWithUserSelection()
        {
            // Get the application's base directory
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Define a folder within the base directory for storing QR codes
            string qrCodesFolder = Path.Combine(baseDirectory, "QR Codes");

            // Ensure the QR Codes folder exists
            if (!Directory.Exists(qrCodesFolder))
            {
                Directory.CreateDirectory(qrCodesFolder);
            }

            // Create filename in the format "(unique ID)-Last Name, First Name.png"
            string fileName = MakeValidFileName($"{id_text.Text}-{lastName_text.Text.Trim()}, {firstName_text.Text.Trim()}.png");
            string fullPath = Path.Combine(qrCodesFolder, fileName);

            try
            {
                // Save the QR code image to the QR Codes folder
                pictureBox2.Image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save QR Code: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string MakeValidFileName(string name)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(c, '_'); // Replace invalid characters with an underscore or another safe character
            }
            return name;
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            //for upload image
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(fd.FileName);
            }
        }

        private void RegistrationPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Directly instantiate and show the actionPage form
            new actionPage().Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void firstName_text_TextChanged(object sender, EventArgs e)
        {

        }
    }
}