using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using BCrypt.Net;

namespace CSC2033_TeamProject.Content.Classes
{
    public static class DatabaseManager
    {
        public static string databaseFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "big_fishues_database.sqlite");
        public static string connectionString = $"Data Source={databaseFilePath};Version=3;";

        public static void RegisterUser(string email, string password)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string hashedPassword = HashPassword(password);
                string insertQuery = "INSERT INTO Users (Email, Password, Role) VALUES (@Email, @Password, 'user')";
                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", hashedPassword);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Registration successful.");
                }
            }
        }

        public static bool ValidateLogin(string email, string password)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string getUserQuery = "SELECT Password, Role FROM Users WHERE Email = @Email";
                using (SQLiteCommand command = new SQLiteCommand(getUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHashedPassword = reader.GetString(0);
                            string role = reader.GetString(1);

                            if (VerifyPassword(password, storedHashedPassword))
                            {
                                SessionManager.StartSession(email, role);
                                return true;
                            }
                        }
                    }
                }
                return false; 
            }
        }

        public static bool EmailExists(string email)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                using (SQLiteCommand cmd = new SQLiteCommand(checkEmailQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    int emailCount = Convert.ToInt32(cmd.ExecuteScalar());
                    return emailCount > 0;
                }
            }
        }

        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private static bool VerifyPassword(string inputPassword, string storedHashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, storedHashedPassword);
        }

        public static bool ChangePassword(string email, string oldPassword, string newPassword)
        {
            if (!ValidateLogin(email, oldPassword))
            {
                MessageBox.Show("Invalid email or old password.");
                return false;
            }

            if (oldPassword == newPassword)
            {
                MessageBox.Show("New password cannot be the same as the old password.");
                return false;
            }

            if (!Validation.ValidatePasswordLength(newPassword) ||
                !Validation.ValidateCases(newPassword) ||
                !Validation.ValidateNumber(newPassword) ||
                !Validation.ValidateSpecialCharacter(newPassword))
            {
                MessageBox.Show("Invalid new password format.");
                return false;
            }

            string hashedNewPassword = HashPassword(newPassword);

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE Users SET Password = @Password WHERE Email = @Email";
                using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Password", hashedNewPassword);
                    command.Parameters.AddWithValue("@Email", email);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Password updated successfully.");
            return true;
        }

    }

}


