using System;
using System.Collections.Generic;
using System.Data.SQLite;
using BCrypt.Net;

namespace CSC2033_TeamProject.Content.Classes
{
    public static class DatabaseInitialiser
    {
        public static void Initialise()
        {
            string connectionString = DatabaseManager.connectionString;

            if (!AdminUserExists(connectionString))
            {
                CreateAdminUser(connectionString);
            }

            InsertFishQuestions(connectionString);
        }

        private static bool AdminUserExists(string connectionString)
        {
            bool result = false;
            string query = "SELECT COUNT(*) FROM Users WHERE Role = 'admin'";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    result = count > 0;
                }
            }
            return result;
        }

        private static void CreateAdminUser(string connectionString)
        {
            string email = "admin@gmail.com";
            string password = "Password1!";
            string hashedPassword = HashPassword(password);

            string insertQuery = "INSERT INTO Users (Email, Password, Role) VALUES (@Email, @Password, 'admin')";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", hashedPassword);
                    command.ExecuteNonQuery();
                }
            }
        }

        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private static void InsertFishQuestions(string connectionString)
        {
            int currentQuestionCount = GetCurrentQuestionCount(connectionString);

            if (currentQuestionCount < 5)
            {
                List<string[]> fishQuestions = new List<string[]>()
        {
            new string[]{"What is the largest species of fish?", "Shark", "Whale Shark", "Tuna", "2"},
            new string[]{"Which fish has the longest migration route?", "Salmon", "Tuna", "Eel", "1"},
            new string[]{"Which fish can produce electric shocks?", "Electric Eel", "Stingray", "Tuna", "1"},
            new string[]{"Which fish is known as the 'King of the Ocean'?", "Shark", "Marlin", "Dolphin", "2"},
            new string[]{"Which fish has the ability to change its gender?", "Parrotfish", "Clownfish", "Angelfish", "1"}
        };

                string insertQuery = "INSERT INTO Questions (Question, Option1, Option2, Option3, CorrectOption) " +
                                     "VALUES (@Question, @Option1, @Option2, @Option3, @CorrectOption)";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    foreach (string[] question in fishQuestions)
                    {
                        using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Question", question[0]);
                            command.Parameters.AddWithValue("@Option1", question[1]);
                            command.Parameters.AddWithValue("@Option2", question[2]);
                            command.Parameters.AddWithValue("@Option3", question[3]);
                            command.Parameters.AddWithValue("@CorrectOption", question[4]);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private static int GetCurrentQuestionCount(string connectionString)
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM Questions";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    count = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return count;
        }


    }
}