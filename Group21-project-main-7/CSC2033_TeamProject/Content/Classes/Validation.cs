using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSC2033_TeamProject.Content.Classes
{
    public static class Validation
    {
        //Makes sure entered email is in a valid email format e.g "john1@gmail.com"
        public static bool ValidateEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        //Makes sure passwords are at least 8 characters long
        public static bool ValidatePasswordLength(string password)
        {
            return password.Length >= 8;
        }

        //Makes sure Passwords contain both lowercase and uppercase letters
        public static bool ValidateCases(string password)
        {
            password = password.Trim();
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            return hasUpperCase && hasLowerCase;
        }

        //Makes sure passwords contain a special character
        public static bool ValidateSpecialCharacter(string password)
        {
            return password.Any(ch => !char.IsLetterOrDigit(ch));
        }

        //Makes sure passwords contain a number
        public static bool ValidateNumber(string password)
        {
            return password.Any(char.IsDigit);
        }

        //Checks whether entry fields are empty
        public static bool IsEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsCorrectOptionValid(string correctOption, string option1, string option2, string option3)
        {
            int count = 0;
            if (correctOption == option1) count++;
            if (correctOption == option2) count++;
            if (correctOption == option3) count++;

            return count == 1;
        }
    }
}
