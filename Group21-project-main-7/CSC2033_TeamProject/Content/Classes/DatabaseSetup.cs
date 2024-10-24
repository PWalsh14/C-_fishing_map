using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Threading;


namespace CSC2033_TeamProject.Content.Classes
{
    public static class DatabaseSetup
    {
        public static void InitialiseDatabase()
        {
            // Docker-related parts are commented out
            /*
            string databaseContainerName = "sqlite_container"; // Updated container name
            if (!DoesDockerContainerExist(databaseContainerName))
            {
                Debug.WriteLine("Creating SQLite Docker container...");
                CreateSQLiteDockerContainer(databaseContainerName);
            }
            else if (!IsDockerContainerRunning(databaseContainerName))
            {
                Debug.WriteLine("Starting existing SQLite Docker container...");
                StartDockerContainer(databaseContainerName);
            }

            Debug.WriteLine("Waiting for SQLite to start up...");
            Thread.Sleep(10000); // Adjust this wait time as needed
            */

            string databaseFilePath = GetDatabaseFilePath();
            if (!File.Exists(databaseFilePath))
            {
                Debug.WriteLine("SQLite database does not exist. Creating...");
                CreateSQLiteDatabase(databaseFilePath);
            }

            ConnectToSQLiteDatabase(databaseFilePath);
        }

        public static string GetDatabaseFilePath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "big_fishues_database.sqlite");
        }

        private static void CreateSQLiteDatabase(string databaseFilePath)
        {
            SQLiteConnection.CreateFile(databaseFilePath);
        }

        private static void ConnectToSQLiteDatabase(string databaseFilePath)
        {
            string connectionString = $"Data Source={databaseFilePath};Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Debug.WriteLine("Connected to SQLite database!");

                    string dbschemaSqlPath = GetDbSchemaSqlPath();
                    string dbschemaSql = File.ReadAllText(dbschemaSqlPath);

                    ExecuteNonQuery(connection, dbschemaSql);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private static string GetDbSchemaSqlPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "CSC2033_TeamProject", "Properties", "dbschema.sql");
        }

        private static void ExecuteNonQuery(SQLiteConnection connection, string sql)
        {
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        // Docker-related methods
        /*
        private static bool DoesDockerContainerExist(string containerName)
        {
            return RunDockerCommand($"inspect {containerName}", out _).Contains("No such object");
        }

        private static bool IsDockerContainerRunning(string containerName)
        {
            return RunDockerCommand($"inspect -f {{.State.Running}} {containerName}", out _).Contains("true");
        }

        private static void StartDockerContainer(string containerName)
        {
            RunDockerCommand($"start {containerName}", out _);
        }

        private static void CreateSQLiteDockerContainer(string containerName)
        {
            string databaseFilePath = Path.GetFullPath("big_fishues_database.sqlite"); // Updated database file name
            RunDockerCommand($"run --name {containerName} -v \"{databaseFilePath}:/app/big_fishues_database.sqlite\" -d busybox tail -f /dev/null", out string error);

            if (error.Contains("Error"))
            {
                throw new Exception("Failed to create Docker container: " + error);
            }
        }

        private static string RunDockerCommand(string arguments, out string error)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "docker";
                process.StartInfo.Arguments = arguments;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                Debug.WriteLine("Docker command output: " + output);
                Debug.WriteLine("Docker command error: " + error);

                return output;
            }
        }
        */
    }
}