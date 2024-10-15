namespace Project_001
{
    partial class mainScreenPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainScreenPage));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            firstName_text = new TextBox();
            lastName_text = new TextBox();
            id_text = new TextBox();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            gender_text = new TextBox();
            label4 = new Label();
            birthday_text = new TextBox();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            scanned_id = new TextBox();
            label6 = new Label();
            label7 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label8 = new Label();
            button2 = new Action.CustomButton();
            dataGridView1 = new DataGridView();
            Number = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            BackBtn = new Action.CustomButton();
            statusLabel = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // firstName_text
            // 
            firstName_text.Location = new Point(523, 402);
            firstName_text.Name = "firstName_text";
            firstName_text.Size = new Size(175, 23);
            firstName_text.TabIndex = 12;
            // 
            // lastName_text
            // 
            lastName_text.Location = new Point(523, 447);
            lastName_text.Name = "lastName_text";
            lastName_text.Size = new Size(175, 23);
            lastName_text.TabIndex = 13;
            // 
            // id_text
            // 
            id_text.BackColor = Color.Silver;
            id_text.BorderStyle = BorderStyle.None;
            id_text.ForeColor = Color.Transparent;
            id_text.HideSelection = false;
            id_text.Location = new Point(1, 695);
            id_text.Name = "id_text";
            id_text.Size = new Size(175, 16);
            id_text.TabIndex = 14;
            id_text.TextChanged += TxtId_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(362, 442);
            label1.Name = "label1";
            label1.Size = new Size(107, 28);
            label1.TabIndex = 10;
            label1.Text = "Last Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(362, 397);
            label3.Name = "label3";
            label3.Size = new Size(110, 28);
            label3.TabIndex = 9;
            label3.Text = "First Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(362, 348);
            label2.Name = "label2";
            label2.Size = new Size(112, 28);
            label2.TabIndex = 11;
            label2.Text = "ID Number:";
            // 
            // gender_text
            // 
            gender_text.Location = new Point(523, 541);
            gender_text.Name = "gender_text";
            gender_text.Size = new Size(175, 23);
            gender_text.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(362, 536);
            label4.Name = "label4";
            label4.Size = new Size(80, 28);
            label4.TabIndex = 15;
            label4.Text = "Gender:";
            // 
            // birthday_text
            // 
            birthday_text.Location = new Point(523, 495);
            birthday_text.Name = "birthday_text";
            birthday_text.Size = new Size(175, 23);
            birthday_text.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(362, 490);
            label5.Name = "label5";
            label5.Size = new Size(89, 28);
            label5.TabIndex = 17;
            label5.Text = "Birthday:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(200, 227, 255);
            pictureBox1.Image = Properties.Resources.placeholder;
            pictureBox1.InitialImage = Properties.Resources.placeholder;
            pictureBox1.Location = new Point(102, 353);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(211, 211);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // scanned_id
            // 
            scanned_id.Location = new Point(523, 353);
            scanned_id.Name = "scanned_id";
            scanned_id.Size = new Size(175, 23);
            scanned_id.TabIndex = 20;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Public Sans", 39.7499962F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(247, 186);
            label6.Name = "label6";
            label6.Size = new Size(700, 86);
            label6.TabIndex = 22;
            label6.Text = "00 : 00 : 00 AM";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Public Sans", 20.2499981F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(247, 141);
            label7.Name = "label7";
            label7.Size = new Size(700, 45);
            label7.TabIndex = 3;
            label7.Text = "Date";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Public Sans", 35.9999962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.WhiteSmoke;
            label8.Location = new Point(247, 74);
            label8.Name = "label8";
            label8.Size = new Size(700, 67);
            label8.TabIndex = 24;
            label8.Text = "ROSARY MONTH";
            label8.TextAlign = ContentAlignment.TopCenter;
            label8.Click += label8_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(12, 23, 120);
            button2.BackgroundColor = Color.FromArgb(12, 23, 120);
            button2.BorderColor = Color.Transparent;
            button2.BorderRadius = 5;
            button2.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Public Sans", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(791, 353);
            button2.Name = "button2";
            button2.Padding = new Padding(7, 0, 5, 2);
            button2.Size = new Size(200, 42);
            button2.TabIndex = 25;
            button2.Text = "View Attendance Record";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.TextColor = Color.White;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Public Sans Medium", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(0, 0, 0, 1);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 26;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Number, Date });
            dataGridView1.GridColor = Color.DimGray;
            dataGridView1.Location = new Point(791, 414);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(278, 104);
            dataGridView1.TabIndex = 26;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Number
            // 
            Number.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            Number.DefaultCellStyle = dataGridViewCellStyle2;
            Number.Frozen = true;
            Number.HeaderText = "No.";
            Number.Name = "Number";
            Number.ReadOnly = true;
            Number.Resizable = DataGridViewTriState.False;
            Number.Width = 35;
            // 
            // Date
            // 
            Date.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            Date.DefaultCellStyle = dataGridViewCellStyle3;
            Date.Frozen = true;
            Date.HeaderText = "Date of Absences";
            Date.Name = "Date";
            Date.ReadOnly = true;
            Date.Resizable = DataGridViewTriState.False;
            Date.Width = 200;
            // 
            // BackBtn
            // 
            BackBtn.BackColor = Color.FromArgb(12, 23, 120);
            BackBtn.BackgroundColor = Color.FromArgb(12, 23, 120);
            BackBtn.BorderColor = Color.PaleVioletRed;
            BackBtn.BorderRadius = 5;
            BackBtn.BorderSize = 0;
            BackBtn.FlatAppearance.BorderSize = 0;
            BackBtn.FlatStyle = FlatStyle.Flat;
            BackBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            BackBtn.ForeColor = Color.WhiteSmoke;
            BackBtn.Location = new Point(40, 645);
            BackBtn.Name = "BackBtn";
            BackBtn.Size = new Size(90, 30);
            BackBtn.TabIndex = 27;
            BackBtn.Text = "<< Back";
            BackBtn.TextColor = Color.WhiteSmoke;
            BackBtn.UseVisualStyleBackColor = false;
            BackBtn.Click += BackBtn_Click;
            // 
            // statusLabel
            // 
            statusLabel.BackColor = Color.Transparent;
            statusLabel.Location = new Point(102, 282);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(612, 38);
            statusLabel.TabIndex = 28;
            statusLabel.TextAlign = ContentAlignment.MiddleCenter;
            statusLabel.Visible = false;
            statusLabel.Click += label9_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // mainScreenPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 26, 51);
            BackgroundImage = Properties.Resources.BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1184, 711);
            Controls.Add(statusLabel);
            Controls.Add(BackBtn);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(scanned_id);
            Controls.Add(pictureBox1);
            Controls.Add(birthday_text);
            Controls.Add(label5);
            Controls.Add(gender_text);
            Controls.Add(label4);
            Controls.Add(firstName_text);
            Controls.Add(lastName_text);
            Controls.Add(id_text);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "mainScreenPage";
            Text = "Main Screen";
            Load += MainScreenPage_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox firstName_text;
        private TextBox lastName_text;
        private TextBox id_text;
        private Label label1;
        private Label label3;
        private Label label2;
        private TextBox gender_text;
        private Label label4;
        private TextBox birthday_text;
        private Label label5;
        private PictureBox pictureBox1;
        private TextBox scanned_id;
        private Label label6;
        private Label label7;
        private System.Windows.Forms.Timer timer1;
        private Label label8;
        private Action.CustomButton button2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Time;
        private Action.CustomButton BackBtn;
        private Label statusLabel;
        private ContextMenuStrip contextMenuStrip1;
    }
}