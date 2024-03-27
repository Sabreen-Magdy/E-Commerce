namespace Hotel_Management_System
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            comboBox1 = new ComboBox();
            label7 = new Label();
            pictureBox2 = new PictureBox();
            linkLabel1 = new LinkLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(103, 177, 198);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-59, -40);
            panel1.Name = "panel1";
            panel1.Size = new Size(349, 531);
            panel1.TabIndex = 12;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.WhatsApp_Image_2024_02_06_at_11_05_12_PM_removebg_preview;
            pictureBox1.Location = new Point(31, 127);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(299, 295);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.MenuHighlight;
            label5.Location = new Point(579, 405);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 21;
            label5.Text = "Login";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(338, 66);
            label4.Name = "label4";
            label4.Size = new Size(150, 47);
            label4.TabIndex = 19;
            label4.Text = "Sign Up";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.MenuHighlight;
            label3.Location = new Point(338, 358);
            label3.Name = "label3";
            label3.Size = new Size(129, 15);
            label3.TabIndex = 18;
            label3.Text = "Forgot Your PassWord?";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(338, 223);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Enter UserName";
            textBox1.Size = new Size(243, 34);
            textBox1.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(338, 196);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 15;
            label1.Text = "UserName";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(103, 177, 198);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(511, 358);
            button1.Name = "button1";
            button1.Size = new Size(105, 37);
            button1.TabIndex = 17;
            button1.Text = "SignUp";
            button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(338, 271);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 16;
            label2.Text = "Password";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(338, 293);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.PlaceholderText = "Enter Password";
            textBox2.Size = new Size(243, 34);
            textBox2.TabIndex = 14;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(338, 158);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(243, 23);
            comboBox1.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(338, 133);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 24;
            label7.Text = "User Type";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(679, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(127, 101);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 25;
            pictureBox2.TabStop = false;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.DisabledLinkColor = Color.Silver;
            linkLabel1.Font = new Font("Mongolian Baiti", 9.75F);
            linkLabel1.LinkColor = Color.DimGray;
            linkLabel1.Location = new Point(427, 406);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(146, 14);
            linkLabel1.TabIndex = 26;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Already Have an Account";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(linkLabel1);
            Controls.Add(pictureBox2);
            Controls.Add(label7);
            Controls.Add(comboBox1);
            Controls.Add(panel1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Label label2;
        private TextBox textBox2;
        private ComboBox comboBox1;
        private Label label7;
        private PictureBox pictureBox2;
        private LinkLabel linkLabel1;
    }
}