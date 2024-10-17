namespace Project_001
{
    partial class AccountStatusPage
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
            txtStudentId = new TextBox();
            label1 = new Label();
            dataGridViewAttendance = new DataGridView();
            btnSubmit = new Action.CustomButton();
            pictureBoxStudentPhoto = new PictureBox();
            textBoxBirthday = new TextBox();
            label5 = new Label();
            textBoxGender = new TextBox();
            label4 = new Label();
            textBoxFirstName = new TextBox();
            textBoxLastName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            labelStatus = new Label();
            DeleteBtn = new Action.CustomButton();
            BackBtn = new Action.CustomButton();
            InsertRecordBtn = new Action.CustomButton();
            dateTimePickerAttendanceDate = new DateTimePicker();
            dataGridViewAbsences = new DataGridView();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAttendance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStudentPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAbsences).BeginInit();
            SuspendLayout();
            // 
            // txtStudentId
            // 
            txtStudentId.Anchor = AnchorStyles.None;
            txtStudentId.Location = new Point(253, 136);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(175, 23);
            txtStudentId.TabIndex = 0;
            txtStudentId.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(101, 135);
            label1.Name = "label1";
            label1.Size = new Size(133, 20);
            label1.TabIndex = 1;
            label1.Text = "Enter ID Number:";
            // 
            // dataGridViewAttendance
            // 
            dataGridViewAttendance.AllowUserToAddRows = false;
            dataGridViewAttendance.Anchor = AnchorStyles.None;
            dataGridViewAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAttendance.Location = new Point(696, 377);
            dataGridViewAttendance.Name = "dataGridViewAttendance";
            dataGridViewAttendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAttendance.Size = new Size(375, 175);
            dataGridViewAttendance.TabIndex = 2;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.None;
            btnSubmit.BackColor = Color.Navy;
            btnSubmit.BackgroundColor = Color.Navy;
            btnSubmit.BorderColor = Color.PaleVioletRed;
            btnSubmit.BorderRadius = 20;
            btnSubmit.BorderSize = 0;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Public Sans", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(444, 133);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(79, 32);
            btnSubmit.TabIndex = 3;
            btnSubmit.Text = "Submit";
            btnSubmit.TextColor = Color.White;
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click_1;
            // 
            // pictureBoxStudentPhoto
            // 
            pictureBoxStudentPhoto.Anchor = AnchorStyles.None;
            pictureBoxStudentPhoto.Image = Properties.Resources.placeholder;
            pictureBoxStudentPhoto.Location = new Point(101, 250);
            pictureBoxStudentPhoto.Name = "pictureBoxStudentPhoto";
            pictureBoxStudentPhoto.Size = new Size(211, 211);
            pictureBoxStudentPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxStudentPhoto.TabIndex = 4;
            pictureBoxStudentPhoto.TabStop = false;
            // 
            // textBoxBirthday
            // 
            textBoxBirthday.Anchor = AnchorStyles.None;
            textBoxBirthday.Enabled = false;
            textBoxBirthday.Location = new Point(473, 366);
            textBoxBirthday.Name = "textBoxBirthday";
            textBoxBirthday.ReadOnly = true;
            textBoxBirthday.Size = new Size(153, 23);
            textBoxBirthday.TabIndex = 26;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(335, 361);
            label5.Name = "label5";
            label5.Size = new Size(93, 28);
            label5.TabIndex = 25;
            label5.Text = "Birthday:";
            // 
            // textBoxGender
            // 
            textBoxGender.Anchor = AnchorStyles.None;
            textBoxGender.Enabled = false;
            textBoxGender.Location = new Point(473, 405);
            textBoxGender.Name = "textBoxGender";
            textBoxGender.ReadOnly = true;
            textBoxGender.Size = new Size(153, 23);
            textBoxGender.TabIndex = 24;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(335, 401);
            label4.Name = "label4";
            label4.Size = new Size(85, 28);
            label4.TabIndex = 23;
            label4.Text = "Gender:";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Anchor = AnchorStyles.None;
            textBoxFirstName.Enabled = false;
            textBoxFirstName.Location = new Point(473, 283);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.ReadOnly = true;
            textBoxFirstName.Size = new Size(153, 23);
            textBoxFirstName.TabIndex = 21;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Anchor = AnchorStyles.None;
            textBoxLastName.Enabled = false;
            textBoxLastName.Location = new Point(473, 323);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.ReadOnly = true;
            textBoxLastName.Size = new Size(153, 23);
            textBoxLastName.TabIndex = 22;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(334, 318);
            label2.Name = "label2";
            label2.Size = new Size(113, 28);
            label2.TabIndex = 20;
            label2.Text = "Last Name:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(335, 279);
            label3.Name = "label3";
            label3.Size = new Size(115, 28);
            label3.TabIndex = 19;
            label3.Text = "First Name:";
            // 
            // labelStatus
            // 
            labelStatus.Anchor = AnchorStyles.None;
            labelStatus.AutoSize = true;
            labelStatus.BackColor = Color.Transparent;
            labelStatus.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            labelStatus.ForeColor = Color.White;
            labelStatus.Location = new Point(151, 209);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(114, 28);
            labelStatus.TabIndex = 28;
            labelStatus.Text = "Status: N/A";
            // 
            // DeleteBtn
            // 
            DeleteBtn.Anchor = AnchorStyles.None;
            DeleteBtn.BackColor = Color.FromArgb(192, 0, 0);
            DeleteBtn.BackgroundColor = Color.FromArgb(192, 0, 0);
            DeleteBtn.BorderColor = Color.PaleVioletRed;
            DeleteBtn.BorderRadius = 20;
            DeleteBtn.BorderSize = 0;
            DeleteBtn.FlatAppearance.BorderSize = 0;
            DeleteBtn.FlatStyle = FlatStyle.Flat;
            DeleteBtn.Font = new Font("Public Sans", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DeleteBtn.ForeColor = Color.White;
            DeleteBtn.Location = new Point(971, 571);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(100, 30);
            DeleteBtn.TabIndex = 29;
            DeleteBtn.Text = "Delete Record";
            DeleteBtn.TextColor = Color.White;
            DeleteBtn.UseVisualStyleBackColor = false;
            DeleteBtn.Click += DeleteBtn_Click;
            // 
            // BackBtn
            // 
            BackBtn.Anchor = AnchorStyles.None;
            BackBtn.BackColor = Color.FromArgb(12, 23, 120);
            BackBtn.BackgroundColor = Color.FromArgb(12, 23, 120);
            BackBtn.BorderColor = Color.PaleVioletRed;
            BackBtn.BorderRadius = 5;
            BackBtn.BorderSize = 0;
            BackBtn.FlatAppearance.BorderSize = 0;
            BackBtn.FlatStyle = FlatStyle.Flat;
            BackBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            BackBtn.ForeColor = Color.WhiteSmoke;
            BackBtn.Location = new Point(25, 654);
            BackBtn.Name = "BackBtn";
            BackBtn.Size = new Size(90, 30);
            BackBtn.TabIndex = 30;
            BackBtn.Text = "<< Back";
            BackBtn.TextColor = Color.WhiteSmoke;
            BackBtn.UseVisualStyleBackColor = false;
            BackBtn.Click += BackBtn_Click;
            // 
            // InsertRecordBtn
            // 
            InsertRecordBtn.Anchor = AnchorStyles.None;
            InsertRecordBtn.BackColor = Color.Green;
            InsertRecordBtn.BackgroundColor = Color.Green;
            InsertRecordBtn.BorderColor = Color.PaleVioletRed;
            InsertRecordBtn.BorderRadius = 20;
            InsertRecordBtn.BorderSize = 0;
            InsertRecordBtn.FlatAppearance.BorderSize = 0;
            InsertRecordBtn.FlatStyle = FlatStyle.Flat;
            InsertRecordBtn.Font = new Font("Public Sans", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InsertRecordBtn.ForeColor = Color.White;
            InsertRecordBtn.Location = new Point(696, 570);
            InsertRecordBtn.Name = "InsertRecordBtn";
            InsertRecordBtn.Size = new Size(100, 30);
            InsertRecordBtn.TabIndex = 31;
            InsertRecordBtn.Text = "Insert Record";
            InsertRecordBtn.TextColor = Color.White;
            InsertRecordBtn.UseVisualStyleBackColor = false;
            InsertRecordBtn.Click += InsertRecordBtn_Click_1;
            // 
            // dateTimePickerAttendanceDate
            // 
            dateTimePickerAttendanceDate.Anchor = AnchorStyles.None;
            dateTimePickerAttendanceDate.CalendarFont = new Font("Public Sans", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerAttendanceDate.CustomFormat = "ddd, MM/dd/yyyy";
            dateTimePickerAttendanceDate.Location = new Point(810, 574);
            dateTimePickerAttendanceDate.Name = "dateTimePickerAttendanceDate";
            dateTimePickerAttendanceDate.Size = new Size(155, 23);
            dateTimePickerAttendanceDate.TabIndex = 32;
            // 
            // dataGridViewAbsences
            // 
            dataGridViewAbsences.AllowUserToAddRows = false;
            dataGridViewAbsences.AllowUserToResizeColumns = false;
            dataGridViewAbsences.AllowUserToResizeRows = false;
            dataGridViewAbsences.Anchor = AnchorStyles.None;
            dataGridViewAbsences.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAbsences.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAbsences.Enabled = false;
            dataGridViewAbsences.Location = new Point(696, 135);
            dataGridViewAbsences.Name = "dataGridViewAbsences";
            dataGridViewAbsences.RowHeadersVisible = false;
            dataGridViewAbsences.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewAbsences.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAbsences.Size = new Size(375, 175);
            dataGridViewAbsences.TabIndex = 33;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(820, 95);
            label6.Name = "label6";
            label6.Size = new Size(133, 28);
            label6.TabIndex = 34;
            label6.Text = "Absent Dates";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(810, 342);
            label7.Name = "label7";
            label7.Size = new Size(154, 28);
            label7.TabIndex = 35;
            label7.Text = "Recorded Dates";
            // 
            // AccountStatusPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 26, 51);
            BackgroundImage = Properties.Resources.BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1184, 711);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dataGridViewAbsences);
            Controls.Add(dateTimePickerAttendanceDate);
            Controls.Add(InsertRecordBtn);
            Controls.Add(BackBtn);
            Controls.Add(DeleteBtn);
            Controls.Add(labelStatus);
            Controls.Add(textBoxBirthday);
            Controls.Add(label5);
            Controls.Add(textBoxGender);
            Controls.Add(label4);
            Controls.Add(textBoxFirstName);
            Controls.Add(textBoxLastName);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(pictureBoxStudentPhoto);
            Controls.Add(btnSubmit);
            Controls.Add(dataGridViewAttendance);
            Controls.Add(label1);
            Controls.Add(txtStudentId);
            DoubleBuffered = true;
            Name = "AccountStatusPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AccountStatusPage";
            ((System.ComponentModel.ISupportInitialize)dataGridViewAttendance).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStudentPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAbsences).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtStudentId;
        private Label label1;
        private DataGridView dataGridViewAttendance;
        private Action.CustomButton btnSubmit;
        private PictureBox pictureBoxStudentPhoto;
        private TextBox textBoxBirthday;
        private Label label5;
        private TextBox textBoxGender;
        private Label label4;
        private TextBox textBoxFirstName;
        private TextBox textBoxLastName;
        private Label label2;
        private Label label3;
        private Label labelStatus;
        private Action.CustomButton DeleteBtn;
        private Action.CustomButton BackBtn;
        private Action.CustomButton InsertRecordBtn;
        private DateTimePicker dateTimePickerAttendanceDate;
        private DataGridView dataGridViewAbsences;
        private Label label6;
        private Label label7;
    }
}