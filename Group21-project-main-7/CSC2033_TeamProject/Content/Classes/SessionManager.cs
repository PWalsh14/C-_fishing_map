using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC2033_TeamProject.Content.Classes
{
    public static class SessionManager
    {
        public static string UserEmail { get; private set; }
        public static string UserRole { get; private set; }

        public static void StartSession(string email, string role)
        {
            UserEmail = email;
            UserRole = role;
        }

        public static void EndSession()
        {
            UserEmail = null;
            UserRole = null;
        }

        public static bool IsSessionActive()
        {
            return UserEmail != null && UserRole != null;
        }
    }
}
