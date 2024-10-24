using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using GMap.NET;
using System.Diagnostics;
namespace CSC2033_TeamProject.Content.Classes
{
    public static class DatabaseHelper
    {
        private static string connectionString = $"Data Source={GetDatabaseFilePath()};Version=3;";

        private static string GetDatabaseFilePath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "big_fishues_database.sqlite");
        }

        public static List<Zone> LoadZones()
        {
            List<Zone> zones = new List<Zone>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT zone_id, zone_name, zone_description FROM zones;";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int zoneId = reader.GetInt32(0);
                            string zoneName = reader.GetString(1);
                            string zoneDescription = reader.IsDBNull(2) ? null : reader.GetString(2);

                            List<PointLatLng> points = LoadZonePoints(connection, zoneId);

                            zones.Add(new Zone(zoneName, zoneDescription, points));
                        }
                    }
                }
            }

            return zones;
        }

        private static List<PointLatLng> LoadZonePoints(SQLiteConnection connection, int zoneId)
        {
            List<PointLatLng> points = new List<PointLatLng>();

            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT latitude, longitude FROM zone_points WHERE zone_id = @zoneId;";
                command.Parameters.AddWithValue("@zoneId", zoneId);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        double latitude = reader.GetDouble(0);
                        double longitude = reader.GetDouble(1);

                        points.Add(new PointLatLng(latitude, longitude));
                    }
                }
            }

            return points;
        }

        public static void SaveZones(string zoneName, string zoneDescription, List<double> latitudes, List<double> longitudes)
        {
            // Open a connection to the SQLite database
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Check if the zone already exists in the database
                bool zoneExists = CheckZoneByName(zoneName);

                if (zoneExists)
                {
                    // If the zone exists, update its description
                    UpdateZone(connection, zoneName, zoneDescription);

                    // Update or insert the points of the zone into the zone_points table
                    UpdateOrInsertZonePoints(connection, zoneName, latitudes, longitudes);
                }
                else
                {
                    // If the zone doesn't exist, insert it along with its points
                    InsertZoneWithPoints(connection, zoneName, zoneDescription, latitudes, longitudes);
                }
            }
        }

        private static void UpdateZone(SQLiteConnection connection, string zoneName, string zoneDescription)
        {
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE zones SET zone_description = @description WHERE zone_name = @name;";
                command.Parameters.AddWithValue("@description", zoneDescription);
                command.Parameters.AddWithValue("@name", zoneName);
                command.ExecuteNonQuery();
            }
        }

        private static void UpdateOrInsertZonePoints(SQLiteConnection connection, string zoneName, List<double> latitudes, List<double> longitudes)
        {
            // First, delete all existing points for the zone
            DeleteZonePoints(connection, zoneName);

            // Then, insert the new points
            long zoneId = GetZoneId(connection, zoneName);
            for (int i = 0; i < latitudes.Count; i++)
            {
                InsertZonePoint(connection, zoneId, latitudes[i], longitudes[i]);
            }
        }

        private static void InsertZoneWithPoints(SQLiteConnection connection, string zoneName, string zoneDescription, List<double> latitudes, List<double> longitudes)
        {
            // Insert the zone into the zones table
            long zoneId = InsertZone(connection, zoneName, zoneDescription);

            // Insert the points of the zone into the zone_points table
            for (int i = 0; i < latitudes.Count; i++)
            {
                InsertZonePoint(connection, zoneId, latitudes[i], longitudes[i]);
            }
        }

        private static long GetZoneId(SQLiteConnection connection, string zoneName)
        {
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT zone_id FROM zones WHERE zone_name = @name;";
                command.Parameters.AddWithValue("@name", zoneName);
                return (long)command.ExecuteScalar();
            }
        }

        private static void DeleteZonePoints(SQLiteConnection connection, string zoneName)
        {
            long zoneId = GetZoneId(connection, zoneName);
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM zone_points WHERE zone_id = @zoneId;";
                command.Parameters.AddWithValue("@zoneId", zoneId);
                command.ExecuteNonQuery();
            }
        }


        private static long InsertZone(SQLiteConnection connection, string zoneName, string zoneDescription)
        {
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO zones (zone_name, zone_description) VALUES (@name, @description); SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@name", zoneName);
                command.Parameters.AddWithValue("@description", zoneDescription);

                // Execute the command and return the ID of the inserted zone
                return (long)command.ExecuteScalar();
            }
        }

        private static void InsertZonePoint(SQLiteConnection connection, long zoneId, double latitude, double longitude)
        {
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO zone_points (zone_id, latitude, longitude) VALUES (@zoneId, @latitude, @longitude);";
                command.Parameters.AddWithValue("@zoneId", zoneId);
                command.Parameters.AddWithValue("@latitude", latitude);
                command.Parameters.AddWithValue("@longitude", longitude);

                // Execute the command to insert the point
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteZones(List<Zone> zonesToDelete)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                foreach (Zone zone in zonesToDelete)
                {
                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        Debug.WriteLine($"Deleting zone: {zone.Name}, {zone.Description}");

                        // Check if the zone has a corresponding record in the database
                        bool zoneExists = CheckZoneExists(connection, zone.Name, zone.Description);

                        // If the zone exists in the database, delete it
                        if (zoneExists)
                        {
                            command.CommandText = "DELETE FROM zones WHERE zone_name = @name AND zone_description = @description;";
                            command.Parameters.AddWithValue("@name", zone.Name);
                            command.Parameters.AddWithValue("@description", zone.Description);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            Debug.WriteLine($"Zone not found in the database: {zone.Name}, {zone.Description}");
                        }
                    }
                }
            }
        }

        //Validation function used in adminmap to keep zone names unique.
        public static bool CheckZoneByName(string zoneName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT COUNT(*) FROM zones WHERE zone_name = @name;";
                    command.Parameters.AddWithValue("@name", zoneName);

                    long count = (long)command.ExecuteScalar();

                    if (count > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        private static bool CheckZoneExists(SQLiteConnection connection, string zoneName, string zoneDescription)
        {
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM zones WHERE zone_name = @name AND zone_description = @description;";
                command.Parameters.AddWithValue("@name", zoneName);
                command.Parameters.AddWithValue("@description", zoneDescription);

                // Execute the command to check if the zone exists in the database
                long count = (long)command.ExecuteScalar();

                // If count > 0, the zone exists in the database
                return count > 0;
            }
        }
    }
}