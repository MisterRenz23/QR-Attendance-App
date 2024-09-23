namespace Project_001
{
    partial class registrationPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Button1 = new Button();
            firstName_text = new TextBox();
            id_text = new TextBox();
            FirstNameLabl = new Label();
            IDNumLabl = new Label();
            LastNameLabl = new Label();
            lastName_text = new TextBox();
            BirthdayLabl = new Label();
            birthdayPicker = new DateTimePicker();
            GenderLabl = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            pictureBox1 = new PictureBox();
            Button2 = new Button();
            Button3 = new Button();
            pictureBox2 = new PictureBox();
            label6 = new Label();
            label7 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            rosaryMonth = new Label();
            label8 = new Label();
            BackBtn = new Action.CustomButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // Button1
            // 
            Button1.Location = new Point(134, 374);
            Button1.Name = "Button1";
            Button1.Size = new Size(112, 33);
            Button1.TabIndex = 9;
            Button1.Text = "Add Picture";
            Button1.UseVisualStyleBackColor = true;
            Button1.Click += Button1_Click;
            // 
            // firstName_text
            // 
            firstName_text.Location = new Point(488, 209);
            firstName_text.Name = "firstName_text";
            firstName_text.Size = new Size(175, 23);
            firstName_text.TabIndex = 7;
            firstName_text.TextChanged += firstName_text_TextChanged;
            // 
            // id_text
            // 
            id_text.Location = new Point(488, 161);
            id_text.Name = "id_text";
            id_text.Size = new Size(175, 23);
            id_text.TabIndex = 8;
            // 
            // FirstNameLabl
            // 
            FirstNameLabl.AutoSize = true;
            FirstNameLabl.BackColor = Color.Transparent;
            FirstNameLabl.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FirstNameLabl.ForeColor = Color.White;
            FirstNameLabl.Location = new Point(336, 204);
            FirstNameLabl.Name = "FirstNameLabl";
            FirstNameLabl.Size = new Size(110, 28);
            FirstNameLabl.TabIndex = 5;
            FirstNameLabl.Text = "First Name:";
            // 
            // IDNumLabl
            // 
            IDNumLabl.AutoSize = true;
            IDNumLabl.BackColor = Color.Transparent;
            IDNumLabl.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IDNumLabl.ForeColor = Color.White;
            IDNumLabl.Location = new Point(335, 156);
            IDNumLabl.Name = "IDNumLabl";
            IDNumLabl.Size = new Size(112, 28);
            IDNumLabl.TabIndex = 6;
            IDNumLabl.Text = "ID Number:";
            // 
            // LastNameLabl
            // 
            LastNameLabl.AutoSize = true;
            LastNameLabl.BackColor = Color.Transparent;
            LastNameLabl.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LastNameLabl.ForeColor = Color.White;
            LastNameLabl.Location = new Point(335, 250);
            LastNameLabl.Name = "LastNameLabl";
            LastNameLabl.Size = new Size(107, 28);
            LastNameLabl.TabIndex = 6;
            LastNameLabl.Text = "Last Name:";
            // 
            // lastName_text
            // 
            lastName_text.Location = new Point(488, 255);
            lastName_text.Name = "lastName_text";
            lastName_text.Size = new Size(175, 23);
            lastName_text.TabIndex = 8;
            // 
            // BirthdayLabl
            // 
            BirthdayLabl.AutoSize = true;
            BirthdayLabl.BackColor = Color.Transparent;
            BirthdayLabl.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BirthdayLabl.ForeColor = Color.White;
            BirthdayLabl.Location = new Point(335, 295);
            BirthdayLabl.Name = "BirthdayLabl";
            BirthdayLabl.Size = new Size(89, 28);
            BirthdayLabl.TabIndex = 6;
            BirthdayLabl.Text = "Birthday:";
            // 
            // birthdayPicker
            // 
            birthdayPicker.Format = DateTimePickerFormat.Short;
            birthdayPicker.Location = new Point(488, 300);
            birthdayPicker.Name = "birthdayPicker";
            birthdayPicker.Size = new Size(175, 23);
            birthdayPicker.TabIndex = 10;
            birthdayPicker.ValueChanged += DateTimePicker1_ValueChanged;
            // 
            // GenderLabl
            // 
            GenderLabl.AutoSize = true;
            GenderLabl.BackColor = Color.Transparent;
            GenderLabl.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GenderLabl.ForeColor = Color.White;
            GenderLabl.Location = new Point(335, 340);
            GenderLabl.Name = "GenderLabl";
            GenderLabl.Size = new Size(80, 28);
            GenderLabl.TabIndex = 11;
            GenderLabl.Text = "Gender:";
            GenderLabl.Click += Label4_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = Color.Transparent;
            radioButton1.ForeColor = Color.White;
            radioButton1.Location = new Point(488, 349);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(51, 19);
            radioButton1.TabIndex = 12;
            radioButton1.TabStop = true;
            radioButton1.Text = "Male";
            radioButton1.UseVisualStyleBackColor = false;
            radioButton1.CheckedChanged += RadioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = Color.Transparent;
            radioButton2.ForeColor = Color.Transparent;
            radioButton2.Location = new Point(574, 349);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(63, 19);
            radioButton2.TabIndex = 12;
            radioButton2.TabStop = true;
            radioButton2.Text = "Female";
            radioButton2.UseVisualStyleBackColor = false;
            radioButton2.CheckedChanged += RadioButton2_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(200, 227, 255);
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(92, 156);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // Button2
            // 
            Button2.Location = new Point(551, 392);
            Button2.Name = "Button2";
            Button2.Size = new Size(112, 33);
            Button2.TabIndex = 14;
            Button2.Text = "SAVE";
            Button2.UseVisualStyleBackColor = true;
            Button2.Click += Button2_Click;
            // 
            // Button3
            // 
            Button3.Location = new Point(413, 392);
            Button3.Name = "Button3";
            Button3.Size = new Size(112, 33);
            Button3.TabIndex = 15;
            Button3.Text = "DELETE";
            Button3.UseVisualStyleBackColor = true;
            Button3.Click += Button3_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(200, 227, 255);
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(823, 267);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(250, 250);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Public Sans", 20.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(808, 213);
            label6.Name = "label6";
            label6.Size = new Size(290, 38);
            label6.TabIndex = 17;
            label6.Text = "00 : 00 : 00 AM";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Public Sans", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.WhiteSmoke;
            label7.Location = new Point(853, 193);
            label7.Name = "label7";
            label7.Size = new Size(200, 20);
            label7.TabIndex = 18;
            label7.Text = "Date";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // rosaryMonth
            // 
            rosaryMonth.AutoSize = true;
            rosaryMonth.BackColor = Color.Transparent;
            rosaryMonth.Font = new Font("Public Sans", 24.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rosaryMonth.ForeColor = Color.WhiteSmoke;
            rosaryMonth.Location = new Point(808, 141);
            rosaryMonth.Name = "rosaryMonth";
            rosaryMonth.Size = new Size(290, 46);
            rosaryMonth.TabIndex = 19;
            rosaryMonth.Text = "ROSARY MONTH";
            rosaryMonth.TextAlign = ContentAlignment.TopCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(924, 529);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 20;
            label8.Text = "QR Code";
            // 
            // BackBtn
            // 
            BackBtn.BackColor = Color.FromArgb(12, 23, 120);
            BackBtn.BackgroundColor = Color.FromArgb(12, 23, 120);
            BackBtn.BorderColor = Color.Transparent;
            BackBtn.BorderRadius = 5;
            BackBtn.BorderSize = 0;
            BackBtn.FlatAppearance.BorderSize = 0;
            BackBtn.FlatStyle = FlatStyle.Flat;
            BackBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BackBtn.ForeColor = Color.WhiteSmoke;
            BackBtn.Location = new Point(40, 645);
            BackBtn.Name = "BackBtn";
            BackBtn.Size = new Size(90, 30);
            BackBtn.TabIndex = 21;
            BackBtn.Text = "<< Back";
            BackBtn.TextColor = Color.WhiteSmoke;
            BackBtn.UseVisualStyleBackColor = false;
            BackBtn.Click += BackBtn_Click;
            // 
            // registrationPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 26, 51);
            BackgroundImage = Properties.Resources.BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1184, 711);
            Controls.Add(BackBtn);
            Controls.Add(label8);
            Controls.Add(rosaryMonth);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(pictureBox2);
            Controls.Add(Button3);
            Controls.Add(Button2);
            Controls.Add(pictureBox1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(GenderLabl);
            Controls.Add(birthdayPicker);
            Controls.Add(Button1);
            Controls.Add(firstName_text);
            Controls.Add(lastName_text);
            Controls.Add(id_text);
            Controls.Add(BirthdayLabl);
            Controls.Add(LastNameLabl);
            Controls.Add(FirstNameLabl);
            Controls.Add(IDNumLabl);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "registrationPage";
            Text = "Registration Page";
            Load += registrationPage_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Button1;
        private TextBox firstName_text;
        private TextBox id_text;
        private Label FirstNameLabl;
        private Label IDNumLabl;
        private Label LastNameLabl;
        private TextBox lastName_text;
        private Label BirthdayLabl;
        private DateTimePicker birthdayPicker;
        private Label GenderLabl;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private PictureBox pictureBox1;
        private Button Button2;
        private Button Button3;
        private PictureBox pictureBox2;
        private Label label6;
        private Label label7;
        private System.Windows.Forms.Timer timer1;
        private Label rosaryMonth;
        private Label label8;
        private Action.CustomButton BackBtn;
        private Action.CustomButton ExitBtn;
    }
}