namespace Project_001
{
    partial class ViewAttendanceRecord
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAttendanceRecord));
            dataGridViewScannedUsers = new DataGridView();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            exportBtn = new Action.CustomButton();
            BackBtn = new Action.CustomButton();
            RosaryMonth = new Label();
            customButton1 = new Action.CustomButton();
            dateTimePicker1 = new DateTimePicker();
            customButton2 = new Action.CustomButton();
            ((System.ComponentModel.ISupportInitialize)dataGridViewScannedUsers).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewScannedUsers
            // 
            dataGridViewScannedUsers.Anchor = AnchorStyles.None;
            dataGridViewScannedUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewScannedUsers.BackgroundColor = Color.WhiteSmoke;
            dataGridViewScannedUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewScannedUsers.Location = new Point(227, 276);
            dataGridViewScannedUsers.Name = "dataGridViewScannedUsers";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewScannedUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewScannedUsers.Size = new Size(746, 230);
            dataGridViewScannedUsers.TabIndex = 0;
            dataGridViewScannedUsers.CellContentClick += dataGridViewScannedUsers_CellContentClick;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Public Sans", 20.2499981F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(247, 189);
            label1.Name = "label1";
            label1.Size = new Size(700, 45);
            label1.TabIndex = 2;
            label1.Text = "Date";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // exportBtn
            // 
            exportBtn.Anchor = AnchorStyles.None;
            exportBtn.BackColor = Color.Teal;
            exportBtn.BackgroundColor = Color.Teal;
            exportBtn.BorderColor = Color.FromArgb(12, 23, 120);
            exportBtn.BorderRadius = 5;
            exportBtn.BorderSize = 0;
            exportBtn.FlatAppearance.BorderSize = 0;
            exportBtn.FlatStyle = FlatStyle.Flat;
            exportBtn.Font = new Font("Public Sans SemiBold", 10F);
            exportBtn.ForeColor = Color.WhiteSmoke;
            exportBtn.Location = new Point(693, 526);
            exportBtn.Name = "exportBtn";
            exportBtn.Padding = new Padding(0, 0, 0, 2);
            exportBtn.Size = new Size(110, 40);
            exportBtn.TabIndex = 4;
            exportBtn.Text = "Export Month";
            exportBtn.TextColor = Color.WhiteSmoke;
            exportBtn.UseVisualStyleBackColor = false;
            exportBtn.Click += exportBtn_Click;
            // 
            // BackBtn
            // 
            BackBtn.Anchor = AnchorStyles.None;
            BackBtn.BackColor = Color.FromArgb(12, 23, 120);
            BackBtn.BackgroundColor = Color.FromArgb(12, 23, 120);
            BackBtn.BorderColor = Color.WhiteSmoke;
            BackBtn.BorderRadius = 5;
            BackBtn.BorderSize = 0;
            BackBtn.FlatAppearance.BorderSize = 0;
            BackBtn.FlatStyle = FlatStyle.Flat;
            BackBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            BackBtn.ForeColor = Color.White;
            BackBtn.Location = new Point(40, 645);
            BackBtn.Name = "BackBtn";
            BackBtn.Size = new Size(90, 30);
            BackBtn.TabIndex = 5;
            BackBtn.Text = "<< Back";
            BackBtn.TextColor = Color.White;
            BackBtn.UseVisualStyleBackColor = false;
            BackBtn.Click += BackBtn_Click;
            // 
            // RosaryMonth
            // 
            RosaryMonth.Anchor = AnchorStyles.None;
            RosaryMonth.BackColor = Color.Transparent;
            RosaryMonth.Font = new Font("Public Sans", 35.9999962F, FontStyle.Bold);
            RosaryMonth.ForeColor = Color.WhiteSmoke;
            RosaryMonth.Location = new Point(247, 122);
            RosaryMonth.Name = "RosaryMonth";
            RosaryMonth.Size = new Size(700, 67);
            RosaryMonth.TabIndex = 7;
            RosaryMonth.Text = "ROSARY MONTH";
            RosaryMonth.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // customButton1
            // 
            customButton1.Anchor = AnchorStyles.None;
            customButton1.BackColor = Color.Teal;
            customButton1.BackgroundColor = Color.Teal;
            customButton1.BorderColor = Color.FromArgb(12, 23, 120);
            customButton1.BorderRadius = 5;
            customButton1.BorderSize = 0;
            customButton1.FlatAppearance.BorderSize = 0;
            customButton1.FlatStyle = FlatStyle.Flat;
            customButton1.Font = new Font("Public Sans SemiBold", 10F);
            customButton1.ForeColor = Color.WhiteSmoke;
            customButton1.Location = new Point(439, 527);
            customButton1.Name = "customButton1";
            customButton1.Padding = new Padding(0, 0, 0, 2);
            customButton1.Size = new Size(110, 40);
            customButton1.TabIndex = 8;
            customButton1.Text = "Export Day";
            customButton1.TextColor = Color.WhiteSmoke;
            customButton1.UseVisualStyleBackColor = false;
            customButton1.Click += customButton1_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.None;
            dateTimePicker1.Location = new Point(227, 535);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 9;
            // 
            // customButton2
            // 
            customButton2.Anchor = AnchorStyles.None;
            customButton2.BackColor = Color.Teal;
            customButton2.BackgroundColor = Color.Teal;
            customButton2.BorderColor = Color.FromArgb(12, 23, 120);
            customButton2.BorderRadius = 5;
            customButton2.BorderSize = 0;
            customButton2.FlatAppearance.BorderSize = 0;
            customButton2.FlatStyle = FlatStyle.Flat;
            customButton2.Font = new Font("Public Sans SemiBold", 10F);
            customButton2.ForeColor = Color.WhiteSmoke;
            customButton2.Location = new Point(816, 526);
            customButton2.Name = "customButton2";
            customButton2.Padding = new Padding(0, 0, 0, 2);
            customButton2.Size = new Size(153, 40);
            customButton2.TabIndex = 10;
            customButton2.Text = "Absence Report";
            customButton2.TextColor = Color.WhiteSmoke;
            customButton2.UseVisualStyleBackColor = false;
            customButton2.Click += customButton2_Click;
            // 
            // ViewAttendanceRecord
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 26, 51);
            BackgroundImage = Properties.Resources.BG;
            ClientSize = new Size(1184, 711);
            Controls.Add(customButton2);
            Controls.Add(dateTimePicker1);
            Controls.Add(customButton1);
            Controls.Add(RosaryMonth);
            Controls.Add(BackBtn);
            Controls.Add(exportBtn);
            Controls.Add(label1);
            Controls.Add(dataGridViewScannedUsers);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ViewAttendanceRecord";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ViewAttendanceRecord";
            Load += ViewAttendanceRecord_Load;
            Resize += ViewAttendanceRecord_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridViewScannedUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewScannedUsers;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private Action.CustomButton exportBtn;
        private Action.CustomButton BackBtn;
        private Label RosaryMonth;
        private Action.CustomButton customButton1;
        private DateTimePicker dateTimePicker1;
        private Action.CustomButton customButton2;
    }
}