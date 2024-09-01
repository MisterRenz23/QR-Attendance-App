using System.Data.SQLite;
using System.Data;

namespace Project_001
{
    public partial class LoginForm : Form
    {
        // Use a shared SQLite connection
        private SQLiteConnection con = new SQLiteConnection("Data Source=attendance.db;Version=3;");
        public LoginForm()
        {
            InitializeComponent();
            con.DefaultTimeout = 5000; // 5000 ms = 5 seconds
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //con.Open();
            //if (con.State == ConnectionState.Open)
            //{
            //    MessageBox.Show("Connect Successful");
            //    con.Close();
            //}

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if the username or password fields are empty
            if (string.IsNullOrWhiteSpace(user_text.Text) || string.IsNullOrWhiteSpace(password_text.Text))
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

                // Use a `using` block to ensure proper disposal
                using (cmd = new SQLiteCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM login_tb WHERE Username= @username AND Password = @password";
                    cmd.Parameters.AddWithValue("@username", user_text.Text);
                    cmd.Parameters.AddWithValue("@password", password_text.Text);

                    using (rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            this.Hide();
                            Action.actionPage mf = new Action.actionPage();
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
                // Ensure the connection is closed
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}