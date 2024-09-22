using System.ComponentModel;

namespace Project_001.Action
{
    partial class actionPage
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
            components = new Container();
            backgroundWorker1 = new BackgroundWorker();
            clockLabel = new Label();
            digitalClock = new System.Windows.Forms.Timer(components);
            digitalDate = new Label();
            dateLabel = new Label();
            rosaryMonth = new Label();
            registerNewBtn = new CustomButton();
            checkAttendanceBtn = new CustomButton();
            SuspendLayout();
            // 
            // clockLabel
            // 
            clockLabel.BackColor = Color.Transparent;
            clockLabel.Font = new Font("Public Sans", 39.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clockLabel.ForeColor = Color.WhiteSmoke;
            clockLabel.Location = new Point(250, 248);
            clockLabel.Name = "clockLabel";
            clockLabel.Size = new Size(700, 86);
            clockLabel.TabIndex = 0;
            clockLabel.Text = "00 : 00 : 00 AM";
            clockLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // digitalClock
            // 
            digitalClock.Enabled = true;
            digitalClock.Interval = 5;
            digitalClock.Tick += DigitalClock_Tick;
            // 
            // digitalDate
            // 
            digitalDate.AutoSize = true;
            digitalDate.BackColor = Color.Transparent;
            digitalDate.Font = new Font("Public Sans", 39.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            digitalDate.ForeColor = Color.White;
            digitalDate.Location = new Point(503, 260);
            digitalDate.Name = "digitalDate";
            digitalDate.Size = new Size(0, 74);
            digitalDate.TabIndex = 2;
            // 
            // dateLabel
            // 
            dateLabel.BackColor = Color.Transparent;
            dateLabel.Font = new Font("Public Sans", 20.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateLabel.ForeColor = Color.WhiteSmoke;
            dateLabel.Location = new Point(250, 202);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(700, 45);
            dateLabel.TabIndex = 3;
            dateLabel.Text = "Date";
            dateLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // rosaryMonth
            // 
            rosaryMonth.BackColor = Color.Transparent;
            rosaryMonth.Font = new Font("Public Sans", 39.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rosaryMonth.ForeColor = Color.WhiteSmoke;
            rosaryMonth.Location = new Point(250, 128);
            rosaryMonth.Name = "rosaryMonth";
            rosaryMonth.Size = new Size(700, 74);
            rosaryMonth.TabIndex = 4;
            rosaryMonth.Text = "ROSARY MONTH";
            rosaryMonth.TextAlign = ContentAlignment.TopCenter;
            // 
            // registerNewBtn
            // 
            registerNewBtn.BackColor = Color.FromArgb(54, 54, 148);
            registerNewBtn.BackgroundColor = Color.FromArgb(54, 54, 148);
            registerNewBtn.BorderColor = Color.PaleVioletRed;
            registerNewBtn.BorderRadius = 8;
            registerNewBtn.BorderSize = 0;
            registerNewBtn.FlatAppearance.BorderSize = 0;
            registerNewBtn.FlatStyle = FlatStyle.Flat;
            registerNewBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            registerNewBtn.ForeColor = Color.WhiteSmoke;
            registerNewBtn.Location = new Point(492, 496);
            registerNewBtn.Name = "registerNewBtn";
            registerNewBtn.Size = new Size(209, 35);
            registerNewBtn.TabIndex = 8;
            registerNewBtn.Text = "Register New Account";
            registerNewBtn.TextColor = Color.WhiteSmoke;
            registerNewBtn.UseVisualStyleBackColor = false;
            registerNewBtn.Click += RegisterNewBtn_Click;
            // 
            // checkAttendanceBtn
            // 
            checkAttendanceBtn.BackColor = Color.FromArgb(20, 174, 92);
            checkAttendanceBtn.BackgroundColor = Color.FromArgb(20, 174, 92);
            checkAttendanceBtn.BackgroundImageLayout = ImageLayout.None;
            checkAttendanceBtn.BorderColor = Color.Transparent;
            checkAttendanceBtn.BorderRadius = 8;
            checkAttendanceBtn.BorderSize = 1;
            checkAttendanceBtn.FlatAppearance.BorderSize = 0;
            checkAttendanceBtn.FlatStyle = FlatStyle.Flat;
            checkAttendanceBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkAttendanceBtn.ForeColor = Color.WhiteSmoke;
            checkAttendanceBtn.Location = new Point(492, 420);
            checkAttendanceBtn.Name = "checkAttendanceBtn";
            checkAttendanceBtn.Size = new Size(209, 56);
            checkAttendanceBtn.TabIndex = 9;
            checkAttendanceBtn.Text = "Check Attendance Now";
            checkAttendanceBtn.TextColor = Color.WhiteSmoke;
            checkAttendanceBtn.UseVisualStyleBackColor = false;
            checkAttendanceBtn.Click += CheckAttendanceBtn_Click;
            // 
            // actionPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 26, 51);
            BackgroundImage = Properties.Resources.BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1184, 711);
            Controls.Add(checkAttendanceBtn);
            Controls.Add(registerNewBtn);
            Controls.Add(rosaryMonth);
            Controls.Add(dateLabel);
            Controls.Add(digitalDate);
            Controls.Add(clockLabel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "actionPage";
            Text = "Action Page";
            TransparencyKey = Color.Transparent;
            Load += ActionPage_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label clockLabel;
        private System.Windows.Forms.Timer digitalClock;
        private Label digitalDate;
        private Label dateLabel;
        private Label rosaryMonth;
        private CustomButton registerNewBtn;
        private CustomButton checkAttendanceBtn;
    }
}