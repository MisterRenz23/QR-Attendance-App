using MySql.Data.MySqlClient;
using System.Data;

namespace Project_001
{
    public partial class LoginForm : Form
    {
        private MySqlConnection con = new MySqlConnection();
        public LoginForm()
        {
            InitializeComponent();
            con.ConnectionString = @"server=localhost;database=user_infotb;userid=root;password=;";
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

            MySqlCommand cmd;
            MySqlDataReader rd;
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM login_tb WHERE Username= @username AND Password = @password";
                cmd.Parameters.AddWithValue("@username", user_text.Text);
                cmd.Parameters.AddWithValue("@password", password_text.Text);
                rd = cmd.ExecuteReader();
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
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (con != null)
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
