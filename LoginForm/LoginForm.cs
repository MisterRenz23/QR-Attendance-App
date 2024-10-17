using System.Data.SQLite;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_001.Action;


namespace Project_001
{
    public partial class LoginForm : Form
    {
        // Use a shared SQLite connection
        private SQLiteConnection con = new SQLiteConnection("Data Source=attendance.db;Version=3;");
        // Variable to store the actual password
        private string realPassword = string.Empty;
        public LoginForm()
        {
            InitializeComponent();
            con.DefaultTimeout = 5000; // 5000 ms = 5 seconds

            this.Resize += new EventHandler(LoginForm_Resize);

            // Ensure the fields are cleared on startup
            user_text.Text = string.Empty;
            password_text.Text = string.Empty;

            // Subscribe to the KeyDown event for Enter key detection
            user_text.KeyDown += new KeyEventHandler(OnEnterKeyPress);
            password_text.KeyDown += new KeyEventHandler(OnEnterKeyPress);

            // Handle the password masking
            password_text.TextChanged += Password_text_TextChanged;
        }

        // Trigger login on Enter key press
        private void OnEnterKeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Call the login button click event handler
                button1_Click_1(sender, e);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void Password_text_TextChanged(object sender, EventArgs e)
        {
            // Store the real password input in realPassword
            if (password_text.Text.Length > realPassword.Length)
            {
                realPassword += password_text.Text.Substring(realPassword.Length);
            }
            else if (password_text.Text.Length < realPassword.Length)
            {
                realPassword = realPassword.Substring(0, password_text.Text.Length);
            }

            // Replace the RichTextBox text with asterisks
            int selectionStart = password_text.SelectionStart;
            password_text.Text = new string('*', realPassword.Length);
            password_text.SelectionStart = selectionStart;
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            // Check if username or password is empty
            if (string.IsNullOrWhiteSpace(user_text.Text) || string.IsNullOrWhiteSpace(realPassword))
            {
                MessageBox.Show("Please enter both Username and Password.");
                return;
            }

            SQLiteCommand cmd;
            SQLiteDataReader rd;
            try
            {
                // Open the connection
                con.Open();

                using (cmd = new SQLiteCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM login_tb WHERE Username = @username AND Password = @password";
                    cmd.Parameters.AddWithValue("@username", user_text.Text);
                    cmd.Parameters.AddWithValue("@password", realPassword); // Use the real password

                    using (rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            this.Hide();
                            // Open the ActionPage and inherit the window state
                            Action.actionPage mf = new Action.actionPage();
                            mf.WindowState = this.WindowState; // Inherit the window state from LoginForm
                            mf.ShowDialog();

                                                  }
                        else
                        {
                            MessageBox.Show("Wrong Username or Password. Please try again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        private void LoginForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                // Set other forms to maximized
                foreach (Form form in Application.OpenForms)
                {
                    form.WindowState = FormWindowState.Maximized;
                }
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                // Optionally, set other forms back to normal if desired
                foreach (Form form in Application.OpenForms)
                {
                    form.WindowState = FormWindowState.Normal;
                }
            }
        }
    }
}