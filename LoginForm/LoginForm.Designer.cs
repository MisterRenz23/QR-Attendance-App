namespace Project_001
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label3 = new Label();
            label2 = new Label();
            user_text = new RichTextBox();
            password_text = new RichTextBox();
            button1 = new Action.CustomButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Public Sans Black", 39.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(227, 168);
            label1.Name = "label1";
            label1.Size = new Size(768, 74);
            label1.TabIndex = 0;
            label1.Text = "Attendance Checker System";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Public Sans", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(484, 376);
            label3.Name = "label3";
            label3.Size = new Size(103, 28);
            label3.TabIndex = 1;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Public Sans", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(485, 287);
            label2.Name = "label2";
            label2.Size = new Size(106, 28);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // user_text
            // 
            user_text.Font = new Font("Public Sans", 14F);
            user_text.Location = new Point(489, 322);
            user_text.Name = "user_text";
            user_text.Size = new Size(260, 35);
            user_text.TabIndex = 4;
            user_text.Text = "admin";
            // 
            // password_text
            // 
            password_text.Font = new Font("Public Sans", 14F);
            password_text.Location = new Point(489, 412);
            password_text.Name = "password_text";
            password_text.Size = new Size(260, 35);
            password_text.TabIndex = 5;
            password_text.Text = "admin";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(12, 23, 120);
            button1.BackgroundColor = Color.FromArgb(12, 23, 120);
            button1.BorderColor = Color.WhiteSmoke;
            button1.BorderRadius = 5;
            button1.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(566, 484);
            button1.Name = "button1";
            button1.Padding = new Padding(0, 0, 0, 2);
            button1.Size = new Size(112, 44);
            button1.TabIndex = 6;
            button1.Text = "LOGIN";
            button1.TextColor = Color.White;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 26, 51);
            BackgroundImage = Properties.Resources.BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1184, 711);
            Controls.Add(button1);
            Controls.Add(password_text);
            Controls.Add(user_text);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            Text = "Attendance System";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label3;
        private TextBox user_text_2;
        private Label label2;
        private RichTextBox user_text;
        private RichTextBox password_text;
        private Action.CustomButton button1;
    }
}
