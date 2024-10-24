namespace CSC2033_TeamProject.Content.Forms
{
    partial class RegisterPage
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
            RegisterLabel = new Label();
            EmailLabel = new Label();
            PasswordLabel = new Label();
            ConfirmLabel = new Label();
            EmailText = new TextBox();
            PasswordText = new TextBox();
            ConfirmText = new TextBox();
            waveBackground = new PictureBox();
            pictureBox2 = new PictureBox();
            RegisterButton = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)waveBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // RegisterLabel
            // 
            RegisterLabel.AutoSize = true;
            RegisterLabel.Font = new Font("Impact", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            RegisterLabel.ForeColor = SystemColors.ControlLightLight;
            RegisterLabel.Location = new Point(17, 9);
            RegisterLabel.Name = "RegisterLabel";
            RegisterLabel.Size = new Size(141, 43);
            RegisterLabel.TabIndex = 0;
            RegisterLabel.Text = "Register";
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.BackColor = Color.FromArgb(79, 172, 247);
            EmailLabel.Font = new Font("Cascadia Mono", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            EmailLabel.ForeColor = SystemColors.ControlLightLight;
            EmailLabel.Location = new Point(9, 65);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(63, 20);
            EmailLabel.TabIndex = 1;
            EmailLabel.Text = "Email:";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.BackColor = Color.FromArgb(79, 172, 247);
            PasswordLabel.Font = new Font("Cascadia Mono", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            PasswordLabel.ForeColor = SystemColors.ControlLightLight;
            PasswordLabel.Location = new Point(9, 123);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(90, 20);
            PasswordLabel.TabIndex = 2;
            PasswordLabel.Text = "Password:";
            // 
            // ConfirmLabel
            // 
            ConfirmLabel.AutoSize = true;
            ConfirmLabel.BackColor = Color.FromArgb(79, 172, 247);
            ConfirmLabel.Font = new Font("Cascadia Mono", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ConfirmLabel.ForeColor = SystemColors.ControlLightLight;
            ConfirmLabel.Location = new Point(9, 190);
            ConfirmLabel.Name = "ConfirmLabel";
            ConfirmLabel.Size = new Size(162, 20);
            ConfirmLabel.TabIndex = 3;
            ConfirmLabel.Text = "Confirm Password:";
            // 
            // EmailText
            // 
            EmailText.Font = new Font("Sitka Banner", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EmailText.Location = new Point(9, 88);
            EmailText.Name = "EmailText";
            EmailText.Size = new Size(165, 28);
            EmailText.TabIndex = 4;
            // 
            // PasswordText
            // 
            PasswordText.Font = new Font("Sitka Banner", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PasswordText.Location = new Point(9, 146);
            PasswordText.Name = "PasswordText";
            PasswordText.PasswordChar = '*';
            PasswordText.Size = new Size(165, 28);
            PasswordText.TabIndex = 5;
            PasswordText.TextChanged += PasswordText_TextChanged;
            // 
            // ConfirmText
            // 
            ConfirmText.Font = new Font("Sitka Banner", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ConfirmText.Location = new Point(9, 213);
            ConfirmText.Name = "ConfirmText";
            ConfirmText.PasswordChar = '*';
            ConfirmText.Size = new Size(165, 28);
            ConfirmText.TabIndex = 6;
            ConfirmText.TextChanged += ConfirmText_TextChanged;
            // 
            // waveBackground
            // 
            waveBackground.Image = Properties.Resources.layered_waves_haikei;
            waveBackground.Location = new Point(-5, -48);
            waveBackground.Margin = new Padding(3, 2, 3, 2);
            waveBackground.Name = "waveBackground";
            waveBackground.Size = new Size(220, 457);
            waveBackground.TabIndex = 8;
            waveBackground.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.fish_logo;
            pictureBox2.Location = new Point(24, 153);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(158, 153);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // RegisterButton
            // 
            RegisterButton.BackColor = SystemColors.HotTrack;
            RegisterButton.FlatAppearance.BorderColor = Color.CornflowerBlue;
            RegisterButton.FlatAppearance.BorderSize = 5;
            RegisterButton.FlatStyle = FlatStyle.Flat;
            RegisterButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            RegisterButton.ForeColor = Color.White;
            RegisterButton.Location = new Point(27, 303);
            RegisterButton.Margin = new Padding(2, 3, 2, 3);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(131, 39);
            RegisterButton.TabIndex = 10;
            RegisterButton.Text = "Submit";
            RegisterButton.UseVisualStyleBackColor = false;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(96, 177, 248);
            panel1.Controls.Add(EmailLabel);
            panel1.Controls.Add(RegisterButton);
            panel1.Controls.Add(RegisterLabel);
            panel1.Controls.Add(EmailText);
            panel1.Controls.Add(PasswordLabel);
            panel1.Controls.Add(ConfirmText);
            panel1.Controls.Add(PasswordText);
            panel1.Controls.Add(ConfirmLabel);
            panel1.Location = new Point(230, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(189, 361);
            panel1.TabIndex = 11;
            // 
            // RegisterPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(159, 202, 251);
            ClientSize = new Size(431, 408);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(waveBackground);
            Name = "RegisterPage";
            Text = "RegisterPage";
            ((System.ComponentModel.ISupportInitialize)waveBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label RegisterLabel;
        private Label EmailLabel;
        private Label PasswordLabel;
        private Label ConfirmLabel;
        private TextBox EmailText;
        private TextBox PasswordText;
        private TextBox ConfirmText;
        private PictureBox waveBackground;
        private PictureBox pictureBox2;
        private Button RegisterButton;
        private Panel panel1;
    }
}