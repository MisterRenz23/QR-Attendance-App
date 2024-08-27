using MySql.Data.MySqlClient;
using Project_001.Action;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_001

{
    public partial class registrationPage : Form
    {
        private MySqlConnection con = new MySqlConnection();


        public registrationPage()
        {
            InitializeComponent();
            con.ConnectionString = @"server=localhost;database=user_infotb;userid=root;password=;";

            // Subscribe to the FormClosing event
            this.FormClosing += new FormClosingEventHandler(RegistrationPage_FormClosing);
        }
        string Gender;

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

        private void Button2_Click(object sender, EventArgs e)
        {
            //for qrcode generator
            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
            var MyData = QG.CreateQrCode(id_text.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(MyData);
            pictureBox2.Image = code.GetGraphic(100);
            try
            {
                //for image
                MemoryStream ms = new MemoryStream();
                //pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                //byte[] Photo = ms.ToArray();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] Photo = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(Photo, 0, Photo.Length);

                //connect DB Connection
                con.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = con;
                command.CommandText = "INSERT INTO registration_tb (ID,FirstName,LastName,Birthday,Gender,Photo) values ('" + id_text.Text + "','" + firstName_text.Text + "','" + lastName_text.Text + "','" + birthdayPicker.Text + "','" + Gender + "',@photo)";
                command.Parameters.AddWithValue("@photo", Photo);
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Save Successfull !");
                id_text.Clear();
                firstName_text.Clear();
                lastName_text.Clear();
                pictureBox1.Image = null;
                //loadbtn_Click(null, null);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            //for Save folder generate qrcode Image
            string initialDIR = @"C:\Users\John Renz\qr";
            var dialog = new SaveFileDialog();
            dialog.InitialDirectory = initialDIR;
            dialog.Filter = "PNG|*.png|JPEG|*.jpeg|BMP|*.bmp|GIF|*.gif";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(dialog.FileName);

            }


        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Female";
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
    }
}
