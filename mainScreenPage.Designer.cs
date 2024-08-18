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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // firstName_text
            // 
            firstName_text.Location = new Point(379, 219);
            firstName_text.Name = "firstName_text";
            firstName_text.Size = new Size(175, 23);
            firstName_text.TabIndex = 12;
            // 
            // lastName_text
            // 
            lastName_text.Location = new Point(379, 257);
            lastName_text.Name = "lastName_text";
            lastName_text.Size = new Size(175, 23);
            lastName_text.TabIndex = 13;
            // 
            // id_text
            // 
            id_text.HideSelection = false;
            id_text.Location = new Point(-2, 429);
            id_text.Name = "id_text";
            id_text.Size = new Size(175, 23);
            id_text.TabIndex = 14;
            id_text.TextChanged += txtId_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(247, 252);
            label1.Name = "label1";
            label1.Size = new Size(107, 28);
            label1.TabIndex = 10;
            label1.Text = "Last Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(247, 214);
            label3.Name = "label3";
            label3.Size = new Size(110, 28);
            label3.TabIndex = 9;
            label3.Text = "First Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(247, 171);
            label2.Name = "label2";
            label2.Size = new Size(112, 28);
            label2.TabIndex = 11;
            label2.Text = "ID Number:";
            // 
            // gender_text
            // 
            gender_text.Location = new Point(379, 340);
            gender_text.Name = "gender_text";
            gender_text.Size = new Size(175, 23);
            gender_text.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(247, 335);
            label4.Name = "label4";
            label4.Size = new Size(80, 28);
            label4.TabIndex = 15;
            label4.Text = "Gender:";
            // 
            // birthday_text
            // 
            birthday_text.Location = new Point(379, 303);
            birthday_text.Name = "birthday_text";
            birthday_text.Size = new Size(175, 23);
            birthday_text.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(247, 298);
            label5.Name = "label5";
            label5.Size = new Size(89, 28);
            label5.TabIndex = 17;
            label5.Text = "Birthday:";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(47, 143);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(167, 231);
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // scanned_id
            // 
            scanned_id.Location = new Point(379, 176);
            scanned_id.Name = "scanned_id";
            scanned_id.Size = new Size(175, 23);
            scanned_id.TabIndex = 20;
            // 
            // mainScreenPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 26, 51);
            ClientSize = new Size(800, 450);
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
            Name = "mainScreenPage";
            Text = "mainScreenPage";
            Load += mainScreenPage_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
    }
}