using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC2033_TeamProject.Content.Classes;

namespace CSC2033_TeamProject.Content.Forms
{
    public class Prompt : IDisposable
    {
        //Primarily used for the admin map where the admin can enter a name and description for the zone.

        private Form? prompt { get; set; } //actual prompt
        public string Result { get; private set; } //string input by the user

        public Prompt(string text, string caption) //constructor
        {
            Result = ShowDialog(text, caption);
        }
        private string ShowDialog(string text, string caption)
        {
            prompt = new Form()
            {
                Width = 500,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                TopMost = true //sit on top of all other windows.
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 90, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); }; //hook into button event
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            prompt.FormClosing += new FormClosingEventHandler(OnFormClosing);

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void OnFormClosing(object? sender, FormClosingEventArgs e)
        {
            //invalidate user input if they close the form
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Result = Utils.INVALID_FORM_STRING;
            }
        }

        public void Dispose() //clears object from memory
        {
            if (prompt != null)
                prompt.Dispose();
        }
    }
}
