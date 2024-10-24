using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using CSC2033_TeamProject.Content.Classes;

namespace CSC2033_TeamProject
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            DatabaseSetup.InitialiseDatabase();
            ApplicationConfiguration.Initialize();
            // Proceed with running the application
            Application.Run(new Content.Forms.Frontend());
        }
    }
}
