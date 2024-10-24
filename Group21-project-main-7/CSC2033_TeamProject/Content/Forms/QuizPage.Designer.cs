namespace CSC2033_TeamProject.Content.Forms
{
    partial class QuizPage
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
            BubbleTimer = new System.Windows.Forms.Timer(components);
            questionlbl = new Label();
            submitbt = new Button();
            option3 = new RadioButton();
            option2 = new RadioButton();
            option1 = new RadioButton();
            label1 = new Label();
            submitButton = new Button();
            QuizForm = new Panel();
            pictureBox3 = new PictureBox();
            ScorePanel = new Panel();
            button1 = new Button();
            Scorelbl = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            Backbt = new Button();
            AddQbt = new Button();
            CorrectOptiontxt = new TextBox();
            option3txt = new TextBox();
            option2txt = new TextBox();
            option1txt = new TextBox();
            QuestionTextBox = new TextBox();
            Correctlbl = new Label();
            option3lbl = new Label();
            option2lbl = new Label();
            option1lbl = new Label();
            EnterQlbl = new Label();
            Addlbl = new Label();
            Adminbt = new Button();
            AdminForm = new Panel();
            QuizForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ScorePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            AdminForm.SuspendLayout();
            SuspendLayout();
            // 
            // BubbleTimer
            // 
            BubbleTimer.Enabled = true;
            BubbleTimer.Interval = 20;
            BubbleTimer.Tick += BubbleTimerEvent;
            // 
            // questionlbl
            // 
            questionlbl.AutoSize = true;
            questionlbl.BackColor = Color.FromArgb(81, 173, 222);
            questionlbl.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            questionlbl.ForeColor = SystemColors.ControlLightLight;
            questionlbl.Location = new Point(10, 14);
            questionlbl.MaximumSize = new Size(456, 0);
            questionlbl.Name = "questionlbl";
            questionlbl.Size = new Size(82, 21);
            questionlbl.TabIndex = 6;
            questionlbl.Text = "Question";
            // 
            // submitbt
            // 
            submitbt.BackColor = SystemColors.HotTrack;
            submitbt.FlatAppearance.BorderColor = Color.CornflowerBlue;
            submitbt.FlatAppearance.BorderSize = 5;
            submitbt.FlatStyle = FlatStyle.Flat;
            submitbt.Font = new Font("Cascadia Mono", 12F, FontStyle.Bold, GraphicsUnit.Point);
            submitbt.ForeColor = Color.White;
            submitbt.Location = new Point(11, 189);
            submitbt.Margin = new Padding(2, 3, 2, 3);
            submitbt.Name = "submitbt";
            submitbt.Size = new Size(135, 41);
            submitbt.TabIndex = 5;
            submitbt.Text = "Submit";
            submitbt.UseVisualStyleBackColor = false;
            submitbt.Click += submitbt_Click;
            // 
            // option3
            // 
            option3.AutoSize = true;
            option3.Font = new Font("Cascadia Mono", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            option3.ForeColor = SystemColors.ControlLightLight;
            option3.Location = new Point(29, 141);
            option3.Name = "option3";
            option3.Size = new Size(90, 24);
            option3.TabIndex = 3;
            option3.TabStop = true;
            option3.Text = "option3";
            option3.UseVisualStyleBackColor = true;
            // 
            // option2
            // 
            option2.AutoSize = true;
            option2.Font = new Font("Cascadia Mono", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            option2.ForeColor = SystemColors.ControlLightLight;
            option2.Location = new Point(29, 111);
            option2.Name = "option2";
            option2.Size = new Size(90, 24);
            option2.TabIndex = 2;
            option2.TabStop = true;
            option2.Text = "option2";
            option2.UseVisualStyleBackColor = true;
            // 
            // option1
            // 
            option1.AutoSize = true;
            option1.Font = new Font("Cascadia Mono", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            option1.ForeColor = SystemColors.ControlLightLight;
            option1.Location = new Point(29, 81);
            option1.Name = "option1";
            option1.Size = new Size(90, 24);
            option1.TabIndex = 1;
            option1.TabStop = true;
            option1.Text = "option1";
            option1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Cascadia Code", 39.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(71, 0);
            label1.Name = "label1";
            label1.Size = new Size(402, 70);
            label1.TabIndex = 1;
            label1.Text = "Fishing Quiz";
            // 
            // submitButton
            // 
            submitButton.BackColor = SystemColors.HotTrack;
            submitButton.FlatAppearance.BorderColor = Color.CornflowerBlue;
            submitButton.FlatAppearance.BorderSize = 5;
            submitButton.FlatStyle = FlatStyle.Flat;
            submitButton.Font = new Font("Cascadia Mono", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            submitButton.ForeColor = Color.White;
            submitButton.Location = new Point(157, 347);
            submitButton.Margin = new Padding(2, 3, 2, 3);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(233, 53);
            submitButton.TabIndex = 4;
            submitButton.Text = "Start!";
            submitButton.UseVisualStyleBackColor = false;
            submitButton.Click += submitButton_Click;
            // 
            // QuizForm
            // 
            QuizForm.BackColor = Color.FromArgb(129, 215, 238);
            QuizForm.BorderStyle = BorderStyle.Fixed3D;
            QuizForm.Controls.Add(pictureBox3);
            QuizForm.Controls.Add(submitbt);
            QuizForm.Controls.Add(questionlbl);
            QuizForm.Controls.Add(option3);
            QuizForm.Controls.Add(option1);
            QuizForm.Controls.Add(option2);
            QuizForm.Location = new Point(44, 100);
            QuizForm.Name = "QuizForm";
            QuizForm.Size = new Size(466, 246);
            QuizForm.TabIndex = 7;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.seaweed2;
            pictureBox3.Location = new Point(249, 40);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(215, 206);
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // ScorePanel
            // 
            ScorePanel.BackColor = Color.FromArgb(129, 215, 238);
            ScorePanel.BorderStyle = BorderStyle.Fixed3D;
            ScorePanel.Controls.Add(button1);
            ScorePanel.Controls.Add(Scorelbl);
            ScorePanel.Controls.Add(pictureBox2);
            ScorePanel.Controls.Add(pictureBox1);
            ScorePanel.Location = new Point(44, 100);
            ScorePanel.Name = "ScorePanel";
            ScorePanel.Size = new Size(466, 246);
            ScorePanel.TabIndex = 7;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.HotTrack;
            button1.FlatAppearance.BorderColor = Color.CornflowerBlue;
            button1.FlatAppearance.BorderSize = 5;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Cascadia Mono", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(20, 182);
            button1.Margin = new Padding(2, 3, 2, 3);
            button1.Name = "button1";
            button1.Size = new Size(121, 45);
            button1.TabIndex = 8;
            button1.Text = "Try Again";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Scorelbl
            // 
            Scorelbl.AutoSize = true;
            Scorelbl.Font = new Font("Cascadia Mono", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Scorelbl.ForeColor = Color.DarkOrange;
            Scorelbl.Location = new Point(20, 16);
            Scorelbl.MaximumSize = new Size(300, 0);
            Scorelbl.Name = "Scorelbl";
            Scorelbl.Size = new Size(67, 25);
            Scorelbl.TabIndex = 2;
            Scorelbl.Text = "Score";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.OrangeFish;
            pictureBox2.Location = new Point(153, 139);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(103, 93);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Seaweed;
            pictureBox1.Location = new Point(235, 67);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(231, 179);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Backbt
            // 
            Backbt.BackColor = SystemColors.HotTrack;
            Backbt.FlatAppearance.BorderColor = Color.CornflowerBlue;
            Backbt.FlatAppearance.BorderSize = 5;
            Backbt.FlatStyle = FlatStyle.Flat;
            Backbt.Font = new Font("Cascadia Mono", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Backbt.ForeColor = Color.White;
            Backbt.Location = new Point(367, 11);
            Backbt.Margin = new Padding(2, 3, 2, 3);
            Backbt.Name = "Backbt";
            Backbt.Size = new Size(76, 38);
            Backbt.TabIndex = 9;
            Backbt.Text = "Back";
            Backbt.UseVisualStyleBackColor = false;
            Backbt.Click += Backbt_Click;
            // 
            // AddQbt
            // 
            AddQbt.BackColor = SystemColors.HotTrack;
            AddQbt.FlatAppearance.BorderColor = Color.CornflowerBlue;
            AddQbt.FlatAppearance.BorderSize = 5;
            AddQbt.FlatStyle = FlatStyle.Flat;
            AddQbt.Font = new Font("Cascadia Mono", 12F, FontStyle.Bold, GraphicsUnit.Point);
            AddQbt.ForeColor = Color.White;
            AddQbt.Location = new Point(302, 195);
            AddQbt.Margin = new Padding(2, 3, 2, 3);
            AddQbt.Name = "AddQbt";
            AddQbt.Size = new Size(141, 37);
            AddQbt.TabIndex = 8;
            AddQbt.Text = "Add";
            AddQbt.UseVisualStyleBackColor = false;
            AddQbt.Click += AddQbt_Click;
            // 
            // CorrectOptiontxt
            // 
            CorrectOptiontxt.Location = new Point(111, 206);
            CorrectOptiontxt.Name = "CorrectOptiontxt";
            CorrectOptiontxt.Size = new Size(158, 23);
            CorrectOptiontxt.TabIndex = 10;
            // 
            // option3txt
            // 
            option3txt.Location = new Point(111, 164);
            option3txt.Name = "option3txt";
            option3txt.Size = new Size(158, 23);
            option3txt.TabIndex = 9;
            // 
            // option2txt
            // 
            option2txt.Location = new Point(111, 135);
            option2txt.Name = "option2txt";
            option2txt.Size = new Size(158, 23);
            option2txt.TabIndex = 8;
            // 
            // option1txt
            // 
            option1txt.Location = new Point(111, 106);
            option1txt.Name = "option1txt";
            option1txt.Size = new Size(158, 23);
            option1txt.TabIndex = 7;
            // 
            // QuestionTextBox
            // 
            QuestionTextBox.Location = new Point(111, 55);
            QuestionTextBox.Name = "QuestionTextBox";
            QuestionTextBox.Size = new Size(220, 23);
            QuestionTextBox.TabIndex = 6;
            // 
            // Correctlbl
            // 
            Correctlbl.AutoSize = true;
            Correctlbl.BackColor = Color.FromArgb(43, 102, 170);
            Correctlbl.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Correctlbl.ForeColor = SystemColors.ControlLightLight;
            Correctlbl.Location = new Point(11, 206);
            Correctlbl.Name = "Correctlbl";
            Correctlbl.Size = new Size(82, 21);
            Correctlbl.TabIndex = 5;
            Correctlbl.Text = "Correct:";
            // 
            // option3lbl
            // 
            option3lbl.AutoSize = true;
            option3lbl.BackColor = Color.FromArgb(43, 102, 170);
            option3lbl.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            option3lbl.ForeColor = SystemColors.ControlLightLight;
            option3lbl.Location = new Point(9, 164);
            option3lbl.Name = "option3lbl";
            option3lbl.Size = new Size(91, 21);
            option3lbl.TabIndex = 4;
            option3lbl.Text = "Option 3:";
            // 
            // option2lbl
            // 
            option2lbl.AutoSize = true;
            option2lbl.BackColor = Color.FromArgb(43, 102, 170);
            option2lbl.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            option2lbl.ForeColor = SystemColors.ControlLightLight;
            option2lbl.Location = new Point(9, 135);
            option2lbl.Name = "option2lbl";
            option2lbl.Size = new Size(91, 21);
            option2lbl.TabIndex = 3;
            option2lbl.Text = "Option 2:";
            // 
            // option1lbl
            // 
            option1lbl.AutoSize = true;
            option1lbl.BackColor = Color.FromArgb(43, 102, 170);
            option1lbl.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            option1lbl.ForeColor = SystemColors.ControlLightLight;
            option1lbl.Location = new Point(9, 106);
            option1lbl.Name = "option1lbl";
            option1lbl.Size = new Size(91, 21);
            option1lbl.TabIndex = 2;
            option1lbl.Text = "Option 1:";
            // 
            // EnterQlbl
            // 
            EnterQlbl.AutoSize = true;
            EnterQlbl.BackColor = Color.FromArgb(43, 102, 170);
            EnterQlbl.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EnterQlbl.ForeColor = SystemColors.ControlLightLight;
            EnterQlbl.Location = new Point(11, 57);
            EnterQlbl.Name = "EnterQlbl";
            EnterQlbl.Size = new Size(91, 21);
            EnterQlbl.TabIndex = 1;
            EnterQlbl.Text = "Question:";
            // 
            // Addlbl
            // 
            Addlbl.AutoSize = true;
            Addlbl.BackColor = Color.FromArgb(43, 102, 170);
            Addlbl.Font = new Font("Cascadia Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            Addlbl.ForeColor = SystemColors.ControlLightLight;
            Addlbl.Location = new Point(-2, 0);
            Addlbl.Name = "Addlbl";
            Addlbl.Size = new Size(156, 28);
            Addlbl.TabIndex = 0;
            Addlbl.Text = "Add Question";
            // 
            // Adminbt
            // 
            Adminbt.BackColor = SystemColors.HotTrack;
            Adminbt.FlatAppearance.BorderColor = Color.CornflowerBlue;
            Adminbt.FlatAppearance.BorderSize = 5;
            Adminbt.FlatStyle = FlatStyle.Flat;
            Adminbt.Font = new Font("Cascadia Mono", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Adminbt.ForeColor = Color.White;
            Adminbt.Location = new Point(215, 406);
            Adminbt.Margin = new Padding(2, 3, 2, 3);
            Adminbt.Name = "Adminbt";
            Adminbt.Size = new Size(115, 36);
            Adminbt.TabIndex = 8;
            Adminbt.Text = "Admin";
            Adminbt.UseVisualStyleBackColor = false;
            Adminbt.Click += Adminbt_Click;
            // 
            // AdminForm
            // 
            AdminForm.BackColor = Color.FromArgb(32, 81, 150);
            AdminForm.BorderStyle = BorderStyle.Fixed3D;
            AdminForm.Controls.Add(Backbt);
            AdminForm.Controls.Add(Addlbl);
            AdminForm.Controls.Add(AddQbt);
            AdminForm.Controls.Add(EnterQlbl);
            AdminForm.Controls.Add(CorrectOptiontxt);
            AdminForm.Controls.Add(option1lbl);
            AdminForm.Controls.Add(option3txt);
            AdminForm.Controls.Add(option2lbl);
            AdminForm.Controls.Add(option2txt);
            AdminForm.Controls.Add(option3lbl);
            AdminForm.Controls.Add(option1txt);
            AdminForm.Controls.Add(Correctlbl);
            AdminForm.Controls.Add(QuestionTextBox);
            AdminForm.Location = new Point(46, 100);
            AdminForm.Name = "AdminForm";
            AdminForm.Size = new Size(466, 246);
            AdminForm.TabIndex = 11;
            // 
            // QuizPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Ocean_background;
            ClientSize = new Size(555, 454);
            Controls.Add(Adminbt);
            Controls.Add(submitButton);
            Controls.Add(label1);
            Controls.Add(QuizForm);
            Controls.Add(AdminForm);
            Controls.Add(ScorePanel);
            Name = "QuizPage";
            Text = "QuizPage";
            Paint += BubblePaintEvent;
            QuizForm.ResumeLayout(false);
            QuizForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ScorePanel.ResumeLayout(false);
            ScorePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            AdminForm.ResumeLayout(false);
            AdminForm.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer BubbleTimer;
        private Label label1;
        private Button submitButton;
        private RadioButton option3;
        private RadioButton option2;
        private RadioButton option1;
        private Button submitbt;
        private Label questionlbl;
        private Panel QuizForm;
        private Panel ScorePanel;
        private Label Scorelbl;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button button1;
        private Button Adminbt;
        private Button Backbt;
        private Button AddQbt;
        private TextBox CorrectOptiontxt;
        private TextBox option3txt;
        private TextBox option2txt;
        private TextBox option1txt;
        private TextBox QuestionTextBox;
        private Label Correctlbl;
        private Label option3lbl;
        private Label option2lbl;
        private Label option1lbl;
        private Label EnterQlbl;
        private Label Addlbl;
        private Panel AdminForm;
        private PictureBox pictureBox3;
    }
}