using System;
using System.Data.SQLite;
namespace CSC2033_TeamProject.Content.Classes
{
    public class RestrictionDataImport
    {
        private string connectionString;

        public RestrictionDataImport(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void ImportDataFromCSV(string csvFilePath)
        {
            // Read the CSV file
            string[] lines = File.ReadAllLines(csvFilePath);

            // Establish connection
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                foreach (string line in lines)
                {
                    // Split the CSV line by comma
                    string[] columns = line.Split(',');

                    // Ensure that the line has enough columns
                    if (columns.Length >= 4)
                    {
                        // Extract data from CSV columns
                        string siteName = columns[2];
                        string summary = columns[3];

                        // Check if the zone exists
                        int zoneId = GetZoneId(connection, siteName);
                        if (zoneId == -1)
                        {
                            // Zone doesn't exist, create a new zone
                            zoneId = CreateNewZone(connection, siteName);
                        }

                        // Insert restriction into the restrictions table
                        InsertRestriction(connection, zoneId, summary);
                    }
                    else
                    {
                        // Log or handle the case where the line doesn't have enough columns
                        Console.WriteLine("Error: CSV line does not have enough columns.");
                    }
                }
            }
        }

        private int GetZoneId(SQLiteConnection connection, string zoneName)
        {
            // Check if the zone exists in the zones table
            string query = "SELECT zone_id FROM zones WHERE zone_name = @ZoneName;";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ZoneName", zoneName);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return -1; // Zone doesn't exist
                }
            }
        }

        private int CreateNewZone(SQLiteConnection connection, string zoneName)
        {
            // Insert a new zone into the zones table
            string query = "INSERT INTO zones (zone_name) VALUES (@ZoneName); SELECT last_insert_rowid();";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ZoneName", zoneName);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private void InsertRestriction(SQLiteConnection connection, int zoneId, string summary)
        {
            // Insert the restriction into the restrictions table
            string query = "INSERT INTO restrictions (restriction_type, restriction_description, zone_id) " +
                           "VALUES (@RestrictionType, @RestrictionDescription, @ZoneId);";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RestrictionType", ""); // Type will be left empty
                command.Parameters.AddWithValue("@RestrictionDescription", summary);
                command.Parameters.AddWithValue("@ZoneId", zoneId);
                command.ExecuteNonQuery();
            }
        }
    }
}