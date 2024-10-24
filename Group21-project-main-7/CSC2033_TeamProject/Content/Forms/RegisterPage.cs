using CSC2033_TeamProject.Content.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CSC2033_TeamProject.Content.Forms
{
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();

        }

        private void PasswordText_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConfirmText_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string email = EmailText.Text;
            string password = PasswordText.Text;
            string confirm = ConfirmText.Text;

            if (!Validation.ValidateEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            if (!Validation.ValidatePasswordLength(password))
            {
                MessageBox.Show("Password must be at least 8 characters long.");
                return;
            }

            if (!Validation.ValidateCases(password))
            {
                MessageBox.Show("Password must contain at least one uppercase and one lowercase letter.");
                return;
            }

            if (!Validation.ValidateNumber(password))
            {
                MessageBox.Show("Password must contain at least one number.");
                return;
            }

            if (!Validation.ValidateSpecialCharacter(password))
            {
                MessageBox.Show("Password must contain at least one special character.");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Password and confirm password do not match.");
                return;
            }

            if (DatabaseManager.EmailExists(email))
            {
                MessageBox.Show("Email already exists. Please enter another email or log in.");
                return;
            }

            DatabaseManager.RegisterUser(email, password);
            this.Close();
        }
    }
}
