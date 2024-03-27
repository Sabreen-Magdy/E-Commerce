namespace HOTEL_SYSTEM
{
    partial class Form1
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
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label6 = new Label();
            label7 = new Label();
            checkBox1 = new CheckBox();
            label8 = new Label();
            label9 = new Label();
            pictureBox2 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 192, 192);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(12, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(357, 652);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.WhatsApp_Image_2024_02_06_at_11_05_12_PM_removebg_preview;
            pictureBox1.Location = new Point(3, 67);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(347, 421);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Mongolian Baiti", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(611, 104);
            label1.Name = "label1";
            label1.Size = new Size(146, 43);
            label1.TabIndex = 0;
            label1.Text = "lOG IN";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonHighlight;
            label2.Font = new Font("Mongolian Baiti", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(460, 221);
            label2.Name = "label2";
            label2.Size = new Size(94, 19);
            label2.TabIndex = 1;
            label2.Text = "UserName";
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(460, 256);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(235, 27);
            textBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonHighlight;
            label3.Font = new Font("Mongolian Baiti", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(462, 312);
            label3.Name = "label3";
            label3.Size = new Size(86, 19);
            label3.TabIndex = 3;
            label3.Text = "Password";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(460, 343);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(235, 27);
            textBox2.TabIndex = 10;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.AppWorkspace;
            label5.Location = new Point(462, 350);
            label5.Name = "label5";
            label5.Size = new Size(94, 17);
            label5.TabIndex = 11;
            label5.Text = "EnterPassword";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.ForeColor = Color.FromArgb(0, 192, 192);
            label4.Location = new Point(624, 388);
            label4.Name = "label4";
            label4.Size = new Size(157, 20);
            label4.TabIndex = 12;
            label4.Text = "Forget Your Password?";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.LightGray;
            flowLayoutPanel1.Controls.Add(label7);
            flowLayoutPanel1.Controls.Add(label6);
            flowLayoutPanel1.Location = new Point(460, 455);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(108, 33);
            flowLayoutPanel1.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 0;
            label6.Text = "Log in";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Mongolian Baiti", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(16, 6);
            label7.Name = "label7";
            label7.Size = new Size(69, 21);
            label7.TabIndex = 1;
            label7.Text = "Log in";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.Location = new Point(460, 388);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(138, 24);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "Rembember Me";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.AppWorkspace;
            label8.Location = new Point(448, 536);
            label8.Name = "label8";
            label8.Size = new Size(177, 20);
            label8.TabIndex = 15;
            label8.Text = "Don't Have Any Account?";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.Teal;
            label9.Location = new Point(624, 536);
            label9.Name = "label9";
            label9.Size = new Size(61, 20);
            label9.TabIndex = 16;
            label9.Text = "Sign Up";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.hotel_removebg_preview;
            pictureBox2.Location = new Point(987, 25);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(93, 56);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1113, 689);
            Controls.Add(pictureBox2);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(checkBox1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Label label5;
        private Label label4;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label6;
        private Label label7;
        private CheckBox checkBox1;
        private Label label8;
        private Label label9;
        private PictureBox pictureBox2;
    }
}
