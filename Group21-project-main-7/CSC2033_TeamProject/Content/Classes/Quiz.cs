using CSC2033_TeamProject.Content.Classes;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace CSC2033_TeamProject.Content.Forms
{
    public class Quiz
    {
        private int currentQuestionIndex = 0;
        private int score = 0;

        private string[] questions;
        private string[][] options;
        private int[] correctIndices;

        public Quiz(string[] questions, string[][] options, int[] correctIndices)
        {
            this.questions = questions;
            this.options = options;
            this.correctIndices = correctIndices;
        }

        //Gets the current question from the question list
        public string GetCurrentQuestion()
        {
            return questions[currentQuestionIndex];
        }

        //gets the current options for possible answers of that question
        public string[] GetCurrentOptions()
        {
            return options[currentQuestionIndex];
        }

        //Checks that an answer has been selected and checks it against the correct answer
        public void SubmitAnswer(int selectedOptionIndex)
        {
            if (selectedOptionIndex >= 0 && selectedOptionIndex < options[currentQuestionIndex].Length)
            {
                if (selectedOptionIndex == correctIndices[currentQuestionIndex])
                {
                    score++;
                }
            }
            currentQuestionIndex++;
        }

        public bool IsQuizCompleted()
        {
            return currentQuestionIndex >= questions.Length;
        }

        //Gets the user's score
        public int GetScore()
        {
            return score;
        }

        //Generates a quiz made of 5 random questions
        public static Quiz GenerateRandomQuiz(int count)
        {
            var (questions, options, correctIndices) = RandomQuestions(count);
            return new Quiz(questions, options, correctIndices);
        }

        //gets random question from the database, including it's possible answers
        public static (string[], string[][], int[]) RandomQuestions(int count)
        {
            string connectionString = DatabaseManager.connectionString;
            List<string> questions = new List<string>();
            List<string[]> options = new List<string[]>();
            List<int> correctIndices = new List<int>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT question, option1, option2, option3, correctOption FROM questions ORDER BY RANDOM() LIMIT {count}";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            questions.Add(reader.GetString(0));
                            options.Add(new string[]
                            {
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3)
                            });
                            correctIndices.Add(reader.GetInt32(4));
                        }
                    }
                }
            }

            return (questions.ToArray(), options.ToArray(), correctIndices.ToArray());
        }
    }
}

