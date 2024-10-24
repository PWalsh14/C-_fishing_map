using CSC2033_TeamProject.Content.Classes;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CSC2033_TeamProject.Content.Forms
{
    public partial class QuizPage : Form
    {
        private List<Bubble> BubbleList = new List<Bubble>();
        private Random random = new Random();
        private Quiz quiz;

        public QuizPage()
        {
            InitializeComponent();
            InitializeForm();
            CheckAdmin();
        }

        private void InitializeForm()
        {
            QuizForm.Visible = false;
            ScorePanel.Visible = false;
            AdminForm.Visible = false;
            this.DoubleBuffered = true;
            MakeBubbles();
        }

        private void MakeBubbles()
        {
            for (int i = 0; i < 300; i++)
            {
                Bubble newBubble = new Bubble();
                BubbleList.Add(newBubble);
            }
        }

        private void BubbleTimerEvent(object sender, EventArgs e)
        {
            foreach (Bubble tempBubble in BubbleList)
            {
                tempBubble.MoveBubble();
                tempBubble.posY -= tempBubble.speedY;
                tempBubble.posX += tempBubble.speedX;
                if (tempBubble.posY < tempBubble.topLimit)
                {
                    tempBubble.posY = 700;
                    tempBubble.posX = random.Next(0, 800);
                }
            }
            this.Invalidate();
        }

        private void BubblePaintEvent(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;
            foreach (Bubble tempBubble in BubbleList)
            {
                Canvas.DrawImage(tempBubble.bubble, tempBubble.posX, tempBubble.posY, tempBubble.width, tempBubble.height);
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            SetupQuiz();
        }

        private void SetupQuiz()
        {
            submitButton.Visible = false;
            Adminbt.Visible = false;
            QuizForm.Visible = true;
            option1.Visible = true;
            option2.Visible = true;
            option3.Visible = true;
            submitbt.Visible = true;

            var (questions, options, correctIndices) = Quiz.RandomQuestions(5);
            quiz = new Quiz(questions, options, correctIndices);
            DisplayNextQuestion();
        }

        private void submitbt_Click(object sender, EventArgs e)
        {
            SubmitAnswer();
        }

        private void SubmitAnswer()
        {
            int selectedOptionIndex = GetSelectedOptionIndex();

            if (selectedOptionIndex == -1)
            {
                MessageBox.Show("Please select an option before submitting.", "No Option Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                quiz.SubmitAnswer(selectedOptionIndex);
                DisplayNextQuestion();
            }
        }

        private int GetSelectedOptionIndex()
        {
            if (option1.Checked)
            {
                option1.Checked = false;
                return 0;
            }
            if (option2.Checked)
            {
                option2.Checked = false;
                return 1;
            }
            if (option3.Checked)
            {
                option3.Checked = false;
                return 2;
            }
            return -1;
        }

        private void DisplayNextQuestion()
        {
            if (!quiz.IsQuizCompleted())
            {
                questionlbl.Text = quiz.GetCurrentQuestion();
                string[] options = quiz.GetCurrentOptions();
                option1.Text = options[0];
                option2.Text = options[1];
                option3.Text = options[2];
            }
            else
            {
                EndQuiz();
            }
        }

        private void EndQuiz()
        {
            option1.Visible = false;
            option2.Visible = false;
            option3.Visible = false;
            submitbt.Visible = false;
            QuizForm.Visible = false;
            ScorePanel.Visible = true;
            Scorelbl.Text = "Quiz Completed! Your Score: " + quiz.GetScore();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScorePanel.Visible = false;
            submitButton.Visible = true;
            CheckAdmin();
        }

        private void Adminbt_Click(object sender, EventArgs e)
        {
            AdminForm.Visible = true;
            submitButton.Visible = false;
            Adminbt.Visible = false;
        }

        private void AddQbt_Click(object sender, EventArgs e)
        {
            AddQuestion();
        }

        private void AddQuestion()
        {
            string question = QuestionTextBox.Text;
            string option1 = option1txt.Text;
            string option2 = option2txt.Text;
            string option3 = option3txt.Text;
            string CorrectOption = CorrectOptiontxt.Text;

            if (Validation.IsEmpty(question) || Validation.IsEmpty(option1) || Validation.IsEmpty(option2) || Validation.IsEmpty(option3) || Validation.IsEmpty(CorrectOption))
            {
                MessageBox.Show("Please fill out all fields.");
                return;
            }

            if (!Validation.IsCorrectOptionValid(CorrectOption, option1, option2, option3))
            {
                MessageBox.Show("Correct option must match exactly one of the options 1-3.");
                return;
            }

            int correctOption = GetCorrectOptionIndex(CorrectOption, option1, option2, option3);

            string connectionString = DatabaseManager.connectionString;
            string query = "INSERT INTO questions (question, option1, option2, option3, correctOption) VALUES (@question, @option1, @option2, @option3, @correctOption)";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@question", question);
                    command.Parameters.AddWithValue("@option1", option1);
                    command.Parameters.AddWithValue("@option2", option2);
                    command.Parameters.AddWithValue("@option3", option3);
                    command.Parameters.AddWithValue("@correctOption", correctOption);
                    command.ExecuteNonQuery();
                }
            }

            ClearQuestionFields();
            MessageBox.Show("Question added successfully.");
        }

        private int GetCorrectOptionIndex(string CorrectOption, string option1, string option2, string option3)
        {
            if (CorrectOption == option1) return 0;
            if (CorrectOption == option2) return 1;
            return 2;
        }

        private void ClearQuestionFields()
        {
            QuestionTextBox.Clear();
            option1txt.Clear();
            option2txt.Clear();
            option3txt.Clear();
            CorrectOptiontxt.Clear();
        }

        private void Backbt_Click(object sender, EventArgs e)
        {
            submitButton.Visible = true;
            AdminForm.Visible = false;
            CheckAdmin();
        }

        private void CheckAdmin()
        {
            if (SessionManager.UserRole == "admin")
            {
                Adminbt.Visible = true;
            }
            else
            {
                Adminbt.Visible = false;
            }
        }
    }
}

