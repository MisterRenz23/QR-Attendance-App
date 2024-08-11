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
            button1 = new Button();
            firstName_text = new TextBox();
            id_text = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lastName_text = new TextBox();
            label5 = new Label();
            birthdayPicker = new DateTimePicker();
            label4 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            button3 = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(115, 295);
            button1.Name = "button1";
            button1.Size = new Size(112, 33);
            button1.TabIndex = 9;
            button1.Text = "Add Picture";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // firstName_text
            // 
            firstName_text.Location = new Point(447, 121);
            firstName_text.Name = "firstName_text";
            firstName_text.Size = new Size(175, 23);
            firstName_text.TabIndex = 7;
            // 
            // id_text
            // 
            id_text.Location = new Point(447, 78);
            id_text.Name = "id_text";
            id_text.Size = new Size(175, 23);
            id_text.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(315, 116);
            label3.Name = "label3";
            label3.Size = new Size(110, 28);
            label3.TabIndex = 5;
            label3.Text = "First Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(315, 73);
            label2.Name = "label2";
            label2.Size = new Size(112, 28);
            label2.TabIndex = 6;
            label2.Text = "ID Number:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(315, 154);
            label1.Name = "label1";
            label1.Size = new Size(107, 28);
            label1.TabIndex = 6;
            label1.Text = "Last Name:";
            // 
            // lastName_text
            // 
            lastName_text.Location = new Point(447, 159);
            lastName_text.Name = "lastName_text";
            lastName_text.Size = new Size(175, 23);
            lastName_text.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(315, 199);
            label5.Name = "label5";
            label5.Size = new Size(89, 28);
            label5.TabIndex = 6;
            label5.Text = "Birthday:";
            // 
            // birthdayPicker
            // 
            birthdayPicker.Format = DateTimePickerFormat.Short;
            birthdayPicker.Location = new Point(447, 204);
            birthdayPicker.Name = "birthdayPicker";
            birthdayPicker.Size = new Size(175, 23);
            birthdayPicker.TabIndex = 10;
            birthdayPicker.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(315, 244);
            label4.Name = "label4";
            label4.Size = new Size(80, 28);
            label4.TabIndex = 11;
            label4.Text = "Gender:";
            label4.Click += label4_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.ForeColor = Color.White;
            radioButton1.Location = new Point(447, 253);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(51, 19);
            radioButton1.TabIndex = 12;
            radioButton1.TabStop = true;
            radioButton1.Text = "Male";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.ForeColor = Color.Transparent;
            radioButton2.Location = new Point(521, 253);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(63, 19);
            radioButton2.TabIndex = 12;
            radioButton2.TabStop = true;
            radioButton2.Text = "Female";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(77, 78);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(203, 194);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(348, 295);
            button2.Name = "button2";
            button2.Size = new Size(112, 33);
            button2.TabIndex = 14;
            button2.Text = "SAVE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(510, 295);
            button3.Name = "button3";
            button3.Size = new Size(112, 33);
            button3.TabIndex = 15;
            button3.Text = "DELETE";
            button3.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(701, 78);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(248, 194);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // registrationPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 26, 51);
            ClientSize = new Size(1064, 565);
            Controls.Add(pictureBox2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label4);
            Controls.Add(birthdayPicker);
            Controls.Add(button1);
            Controls.Add(firstName_text);
            Controls.Add(lastName_text);
            Controls.Add(id_text);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "registrationPage";
            Text = "registrationPage";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox firstName_text;
        private TextBox id_text;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox lastName_text;
        private Label label5;
        private DateTimePicker birthdayPicker;
        private Label label4;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private PictureBox pictureBox1;
        private Button button2;
        private Button button3;
        private PictureBox pictureBox2;
    }
}