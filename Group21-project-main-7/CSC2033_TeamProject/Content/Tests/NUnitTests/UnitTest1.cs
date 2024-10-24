using CSC2033_TeamProject.Content.Classes;
using NUnit.Framework;

namespace NUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //Test to make sure the email validation is working correctly
            string email = "c2031226@gmail.com";
            bool email_expected=true;
            bool email_actual = Validation.ValidateEmail(email);
            Assert.Equals(email_expected,email_actual);

            //Test to make sure the password length validation is working correctly
            string long_password = "12345678";
            bool password_length_expected=true;
            bool password_length_actual=Validation.ValidatePasswordLength(long_password);
            Assert.Equals(password_length_expected,password_length_actual);

            //Test to make sure the validation detecting whether a password has both lower and upper case letters is working
            string upper_case_password = "Hello123";
            bool cases_expected=true;
            bool cases_actual=Validation.ValidateCases(upper_case_password);
            Assert.Equals(cases_expected, cases_actual);

            //Test to make sure password number detection is working correctly
            string number_password = "12345678";
            bool number_password_expected=true;
            bool number_password_actual = Validation.ValidateNumber(number_password);
            Assert.Equals(number_password_expected, number_password_actual);

            //Test to make sure special character detection works
            string special_character_password = "Hello123!";
            bool special_character_password_expected=true;
            bool special_character_password_actual = Validation.ValidateSpecialCharacter(special_character_password);
            Assert.Equals(special_character_password_expected, special_character_password_actual);


        }
    }
}