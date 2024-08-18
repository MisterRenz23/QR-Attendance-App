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
            user_text = new TextBox();
            label2 = new Label();
            label3 = new Label();
            password_text = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Public Sans Black", 39.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(280, 307);
            label1.Name = "label1";
            label1.Size = new Size(766, 74);
            label1.TabIndex = 0;
            label1.Text = "Attendance Checker System";
            label1.Click += label1_Click;
            // 
            // user_text
            // 
            user_text.Location = new Point(652, 445);
            user_text.Name = "user_text";
            user_text.Size = new Size(175, 23);
            user_text.TabIndex = 2;
            user_text.Text = "admin";
            user_text.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(520, 440);
            label2.Name = "label2";
            label2.Size = new Size(115, 28);
            label2.TabIndex = 1;
            label2.Text = "USERNAME";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(520, 483);
            label3.Name = "label3";
            label3.Size = new Size(117, 28);
            label3.TabIndex = 1;
            label3.Text = "PASSWORD";
            // 
            // password_text
            // 
            password_text.Location = new Point(652, 488);
            password_text.Name = "password_text";
            password_text.Size = new Size(175, 23);
            password_text.TabIndex = 2;
            password_text.Text = "admin";
            password_text.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(652, 555);
            button1.Name = "button1";
            button1.Size = new Size(112, 33);
            button1.TabIndex = 3;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 26, 51);
            ClientSize = new Size(1344, 711);
            Controls.Add(button1);
            Controls.Add(password_text);
            Controls.Add(user_text);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "Attendance System";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox user_text;
        private Label label2;
        private Label label3;
        private TextBox password_text;
        private Button button1;
    }
}
