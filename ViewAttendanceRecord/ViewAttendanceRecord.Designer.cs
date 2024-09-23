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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewScannedUsers = new DataGridView();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            exportBtn = new Action.CustomButton();
            BackBtn = new Action.CustomButton();
            RosaryMonth = new Label();
            btnExportToExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewScannedUsers).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewScannedUsers
            // 
            dataGridViewScannedUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewScannedUsers.BackgroundColor = Color.WhiteSmoke;
            dataGridViewScannedUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewScannedUsers.Location = new Point(144, 296);
            dataGridViewScannedUsers.Name = "dataGridViewScannedUsers";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewScannedUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewScannedUsers.Size = new Size(900, 289);
            dataGridViewScannedUsers.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Public Sans", 20.2499981F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(248, 173);
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
            exportBtn.BackColor = Color.Teal;
            exportBtn.BackgroundColor = Color.Teal;
            exportBtn.BorderColor = Color.FromArgb(12, 23, 120);
            exportBtn.BorderRadius = 5;
            exportBtn.BorderSize = 0;
            exportBtn.FlatAppearance.BorderSize = 0;
            exportBtn.FlatStyle = FlatStyle.Flat;
            exportBtn.Font = new Font("Public Sans SemiBold", 10F);
            exportBtn.ForeColor = Color.WhiteSmoke;
            exportBtn.Location = new Point(934, 603);
            exportBtn.Name = "exportBtn";
            exportBtn.Padding = new Padding(0, 0, 0, 2);
            exportBtn.Size = new Size(110, 40);
            exportBtn.TabIndex = 4;
            exportBtn.Text = "Export";
            exportBtn.TextColor = Color.WhiteSmoke;
            exportBtn.UseVisualStyleBackColor = false;
            // 
            // BackBtn
            // 
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
            RosaryMonth.BackColor = Color.Transparent;
            RosaryMonth.Font = new Font("Public Sans", 35.9999962F, FontStyle.Bold);
            RosaryMonth.ForeColor = Color.WhiteSmoke;
            RosaryMonth.Location = new Point(248, 106);
            RosaryMonth.Name = "RosaryMonth";
            RosaryMonth.Size = new Size(700, 67);
            RosaryMonth.TabIndex = 7;
            RosaryMonth.Text = "ROSARY MONTH";
            RosaryMonth.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnExportToExcel
            // 
            btnExportToExcel.Location = new Point(334, 40);
            btnExportToExcel.Name = "btnExportToExcel";
            btnExportToExcel.Size = new Size(152, 59);
            btnExportToExcel.TabIndex = 1;
            btnExportToExcel.Text = "Export to Excel";
            btnExportToExcel.UseVisualStyleBackColor = true;
            btnExportToExcel.Click += btnExportToExcel_Click_1;
            // 
            // ViewAttendanceRecord
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BG;
            ClientSize = new Size(1184, 711);
            Controls.Add(RosaryMonth);
            Controls.Add(BackBtn);
            Controls.Add(exportBtn);
            Controls.Add(label1);
            BackColor = Color.FromArgb(0, 26, 51);
            ClientSize = new Size(800, 450);
            Controls.Add(btnExportToExcel);
            Controls.Add(dataGridViewScannedUsers);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ViewAttendanceRecord";
            Text = "ViewAttendanceRecord";
            Load += ViewAttendanceRecord_Load;
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
        private Button btnExportToExcel;
    }
}