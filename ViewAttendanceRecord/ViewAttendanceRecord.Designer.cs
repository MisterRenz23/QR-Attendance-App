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
            dataGridViewScannedUsers = new DataGridView();
            btnExportToExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewScannedUsers).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewScannedUsers
            // 
            dataGridViewScannedUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewScannedUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewScannedUsers.Location = new Point(77, 123);
            dataGridViewScannedUsers.Name = "dataGridViewScannedUsers";
            dataGridViewScannedUsers.Size = new Size(648, 289);
            dataGridViewScannedUsers.TabIndex = 0;
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
            BackColor = Color.FromArgb(0, 26, 51);
            ClientSize = new Size(800, 450);
            Controls.Add(btnExportToExcel);
            Controls.Add(dataGridViewScannedUsers);
            Name = "ViewAttendanceRecord";
            Text = "ViewAttendanceRecord";
            Load += ViewAttendanceRecord_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewScannedUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewScannedUsers;
        private Button btnExportToExcel;
    }
}