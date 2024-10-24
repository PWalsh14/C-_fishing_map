using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using CSC2033_TeamProject.Content.Classes;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
namespace CSC2033_TeamProject.Content.Forms
{
    public partial class Frontend : Form
    {
        bool isMainMapSatellite = false; //whether the map is in vector or satellite view
        GMapOverlay polyOverlay = new GMapOverlay("ZoneOverlay");
        private Dictionary<GMapPolygon, Zone> polygonZoneMap;
        private GMapPolygon currentPolygon;
        private ToolTip mapToolTip;

        // Defining connection string
        private string connectionString;
        // List to keep track of which tabs are hidden
        private List<TabPage> hiddenTabs;
        private int userEmail;

        public Frontend()
        {
            InitializeComponent();
            this.connectionString = $"Data Source={DatabaseSetup.GetDatabaseFilePath()};Version=3;";

            // Initialize map control properties
            frontendMap_gMapControl.Position = new PointLatLng(54, -2);
            frontendMap_gMapControl.MapProvider = OpenStreetMapProvider.Instance;
            frontendMap_gMapControl.Zoom = 5;

            polygonZoneMap = new Dictionary<GMapPolygon, Zone>();
            RefreshFrontendMapZones();

            currentPolygon = null;
            mapToolTip = new ToolTip();

            // Initialise list to store hidden tabs
            hiddenTabs = new List<TabPage>();
            HideTabsExceptLogin();

            DatabaseInitialiser.Initialise();

            LoadFishingLogs();
        }

        // Hides all tabs apart from the login tab when application is run
        private void HideTabsExceptLogin()
        {
            foreach (TabPage tabPage in frontend_MainTabControl.TabPages)
            {
                // If the tab is not login tab, add it to the hiddenTabs list
                if (tabPage != tabLoginMain)
                {
                    hiddenTabs.Add(tabPage);
                }
            }
            // Remove all the tabs in the hiddenTabs list from TabControl
            foreach (TabPage tabPage in hiddenTabs)
            {
                frontend_MainTabControl.TabPages.Remove(tabPage);
            }
        }

        // Shows all tabs apart from the login tab once user is logged in
        private void ShowTabsExceptLogin()
        {
            // Add all the tabs in the hiddenTabs list back to the TabControl
            foreach (TabPage tabPage in hiddenTabs)
            {
                frontend_MainTabControl.TabPages.Add(tabPage);
            }
            hiddenTabs.Clear(); // Clear list
            frontend_MainTabControl.TabPages.Remove(tabLoginMain); // Remove login tab
        }

        //loads restriction zones from db onto the frontend map.
        private void RefreshFrontendMapZones()
        {
            List<Zone> localZones = DatabaseHelper.LoadZones();

            //refined lookup logic
            HashSet<string> currentZoneNames = new HashSet<string>(localZones.Select(zone => zone.Name));
            var polygonsToRemove = polyOverlay.Polygons.Where(polygon => !currentZoneNames.Contains(polygon.Name)).ToList();
            foreach (var polygon in polygonsToRemove)
            {
                polyOverlay.Polygons.Remove(polygon);
                polygonZoneMap.Remove(polygon);
            }
            foreach (Zone zone in localZones)
            {
                var existingPolygon = polyOverlay.Polygons.FirstOrDefault(p => p.Name == zone.Name);
                if (existingPolygon != null)
                {
                    existingPolygon.Points.Clear();
                    existingPolygon.Points.AddRange(zone.Points);
                }
                else
                {
                    GMapPolygon polygon = new GMapPolygon(zone.Points, zone.Name);
                    polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                    polygon.Stroke = new Pen(Color.Red, 2);
                    polygon.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

                    polyOverlay.Polygons.Add(polygon);
                    polygonZoneMap.Add(polygon, zone);
                }
            }
            if (frontendMap_gMapControl.Overlays.Contains(polyOverlay))
                frontendMap_gMapControl.Overlays.Remove(polyOverlay);

            frontendMap_gMapControl.Overlays.Add(polyOverlay);
            frontendMap_gMapControl.Refresh();
        }


        //Toggles the mode of the map between satellite and vector view.
        private void frontendMap_btnToggleMapMode_Click(object sender, EventArgs e)
        {
            switch (isMainMapSatellite)
            {
                case false:
                    isMainMapSatellite = true;
                    frontendMap_gMapControl.MapProvider = GoogleSatelliteMapProvider.Instance;

                    break;
                case true:
                    isMainMapSatellite = false;
                    frontendMap_gMapControl.MapProvider = OpenStreetMapProvider.Instance;
                    break;
            }
        }

        // Button opens a new form facilitating the admin functions of the map
        private void frontendMap_btnOpenAdminMap_Click(object sender, EventArgs e)
        {
            AdminMap adminMapForm = new AdminMap();
            adminMapForm.ShowDialog();
        }

        // Loads the logs for the user into the ListViewItem component
        private void LoadFishingLogs()
        {
            Debug.WriteLine("Loading fishing logs..."); // Print a debug message indicating the start of the method
            logsListView.Items.Clear(); // Clear existing items in the list view

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString)) // Create a new SQLite connection
                {
                    connection.Open(); // Open the created connection
                    Debug.WriteLine("Database connection opened successfully."); // Print a debug message indicating successful database connection

                    // SQL query to select logs for the current user
                    string query = @"
                    SELECT trips.trip_description, zones.zone_name, trips.timestamp 
                    FROM trips 
                    JOIN zones ON trips.zone_id = zones.zone_id 
                    WHERE trips.email = @userEmail";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection)) // Create a new SQLite command
                    {
                        cmd.Parameters.AddWithValue("@userEmail", userEmail); // Add the user email parameter to the command
                        Debug.WriteLine("Executing SQL query..."); // Print a debug message indicating the execution of the SQL query

                        using (SQLiteDataReader reader = cmd.ExecuteReader()) // Execute the command and get a data reader
                        {
                            Debug.WriteLine("Reading data from database..."); // Print a debug message indicating reading data from the database

                            while (reader.Read()) // Read each row
                            {
                                // Create a new ListViewItem with log details with '??' providing default values for null fields
                                ListViewItem item = new ListViewItem(new string[] {
                            reader["trip_description"].ToString() ?? string.Empty,
                            reader["zone_name"].ToString() ?? string.Empty,
                            reader["timestamp"].ToString() ?? string.Empty
                        });
                                logsListView.Items.Add(item); // Add item to the list view
                            }
                        }
                    }
                }

                Debug.WriteLine("Fishing logs loaded successfully."); // Print a debug message indicating successful loading of fishing logs
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during database operations
                Debug.WriteLine("Error loading fishing logs: " + ex.Message); // Print an error message if an exception occurs
                MessageBox.Show("Error loading fishing logs: " + ex.Message); // Display an error message to the user
            }
        }
        
        // Adds the user's new log entry to the database
        private void addEntryButton_Click(object sender, EventArgs e)
        {
            string description = logEntryBox.Text; // Get description from the text box
            string zoneName = zoneInputTextBox.Text; // Get the zone name from the text box

            using (SQLiteConnection connection = new SQLiteConnection(connectionString)) // Create new SQLite connection
            {
                connection.Open();

                // Check if the entered zone name exists in the zones table
                string checkZoneQuery = "SELECT zone_id FROM zones WHERE zone_name = @zoneName";
                int? zoneId = null;

                using (SQLiteCommand checkZoneCmd = new SQLiteCommand(checkZoneQuery, connection)) // Create a new SQLite command for checking zone
                {
                    checkZoneCmd.Parameters.AddWithValue("@zoneName", zoneName); // Add the zone name parameter
                    using (SQLiteDataReader reader = checkZoneCmd.ExecuteReader()) // Execute the command and get a data reader
                    {
                        if (reader.Read()) // If a record is found
                        {
                            zoneId = reader.GetInt32(0); // Get the zone_id
                        }
                    }
                }

                if (zoneId == null) // If the zone does not exist
                {
                    MessageBox.Show("Zone does not exist. Please enter a valid zone name.");
                }
                else
                {
                    // Insert new log entry
                    string insertLogQuery = "INSERT INTO trips (email, trip_description, zone_id) VALUES (@userEmail, @description, @zoneId)";
                    using (SQLiteCommand insertLogCmd = new SQLiteCommand(insertLogQuery, connection)) // Create a new SQLite command
                    {
                        // Add the necessary parameters to command
                        insertLogCmd.Parameters.AddWithValue("@userEmail", userEmail);
                        insertLogCmd.Parameters.AddWithValue("@description", description);
                        insertLogCmd.Parameters.AddWithValue("@zoneId", zoneId);
                        insertLogCmd.ExecuteNonQuery(); // Execute command
                    }

                    LoadFishingLogs(); // Reload fishing logs to include new entry
                                       // Clear both text boxes
                    logEntryBox.Clear();
                    zoneInputTextBox.Clear();
                }
            }
        }

        // Button click that refreshes map view
        private void frontendMap_btnRefreshMap_Click(object sender, EventArgs e)
        {
            RefreshFrontendMapZones();
        }

        // Displays zone restrictions in a tooltip for polygon under the cursor
        private void InspectZoneInfo(object sender, MouseEventArgs e)
        {
            PointLatLng point = frontendMap_gMapControl.FromLocalToLatLng(e.X, e.Y);
            foreach (GMapPolygon polygon in polyOverlay.Polygons)
            {
                if (polygon.IsInside(point))
                {
                    if (currentPolygon != polygon)
                    {
                        currentPolygon = polygon;
                        if (polygonZoneMap.TryGetValue(polygon, out Zone zone))
                            mapToolTip.SetToolTip(frontendMap_gMapControl, "Restrictions: " + zone.Description);
                    }
                    return;
                }
            }
            if (currentPolygon != null)
            {
                currentPolygon = null;
                mapToolTip.SetToolTip(frontendMap_gMapControl, null);
            }
        }

        // Checks if the current user is an admin (needed for admin tab access control)
        private bool IsCurrentUserAdmin()
        {
            // Set variable to false assuming user is not admin
            bool isAdmin = false;
            {
                try
                {
                    if (SessionManager.UserRole == "admin")
                    {
                        isAdmin = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            // Return the isAdmin value (will be true if user is an admin, false if not)
            return isAdmin;
        }

        // Function that prevents the user from accessing the Admin tab if they are not an admin, currently refuses access all the time
        private void frontend_MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frontend_MainTabControl.SelectedTab == adminPage)
            {
                // Call the method to check if user is admin
                if (!IsCurrentUserAdmin())
                {
                    MessageBox.Show("Unable to load tab due to missing admin privileges");
                    frontend_MainTabControl.SelectedTab = MapPage;
                }
            }
            else if (frontend_MainTabControl.SelectedTab == LogoutTab)
            {
                Logout();
                HideTabsExceptLogin();
            }

        }

        // Button click that opens the quiz page
        private void Quizbt_Click(object sender, EventArgs e)
        {
            QuizPage quiz = new QuizPage();
            quiz.Show();
        }

        // Submit button to log the user in after credentials entered
        private void SubmitClickEvent(object sender, EventArgs e)
        {
            string username = userNameBox.Text;
            string password = passwordBox.Text;


            try
            {
                if (DatabaseManager.ValidateLogin(username, password))
                {
                    MessageBox.Show("Login successful!");
                    ShowTabsExceptLogin();
                    CheckAdmin();
                    frontend_MainTabControl.SelectedTab = MapPage;
                    CheckAdmin();
                    if (username != null)
                    {
                        myAccountEmail.Text = SessionManager.UserEmail;
                    }

                }
                else
                {
                    MessageBox.Show("Incorrect username or password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        // Method to log the user out, called by the logout button pressed
        private void Logout()
        {
            SessionManager.EndSession();
            frontend_MainTabControl.SelectedTab = tabLoginMain;
            frontend_MainTabControl.TabPages.Add(tabLoginMain);
        }

        // Allows user to change their password by entering a new one
        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            string currentPassword = CurrentPasswordtxt.Text;
            string newPassword = NewPasswordtxt.Text;
            string email = SessionManager.UserEmail;

            DatabaseManager.ChangePassword(email, currentPassword, newPassword);

        }

        // Opens a new window to register a new user
        private void linkLabelToRegister_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterPage register = new RegisterPage();
            register.Show();
        }

        // For an admin to promote a standard user to admin in the control panel
        private void makeAdminButton_Click(object sender, EventArgs e)
        {
            // Get the email entered in the text box on the admin page
            string userEmail = adminPageUserSearch.Text;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Update user's role to admin where the email matches
                    string updateQuery = "UPDATE Users SET Role = 'admin' WHERE Email = @userEmail";

                    using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
                    {
                        // Add the userEmail parameter to the command
                        command.Parameters.AddWithValue("@userEmail", userEmail);
                        // Execute query and get the number of rows updated
                        int rowsUpdated = command.ExecuteNonQuery();
                        // Check if any rows were updated
                        if (rowsUpdated > 0)
                        {
                            MessageBox.Show("Admin privileges successfully applied for user.");
                        }
                        else
                        {
                            // If no rows were updated, show a user not found message
                            MessageBox.Show("User not found. Please try entering the email address again.");
                        }
                        adminPageUserSearch.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // For an admin to delete a user in the control panel
        private void deleteUserButton_Click(object sender, EventArgs e)
        {
            // Get the email entered in the text box on the admin page
            string userEmail = adminPageUserSearch.Text;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    //  Delete the user where the email matches what was entered in the box
                    string deleteQuery = "DELETE FROM Users WHERE Email = @userEmail";

                    using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
                    {
                        // Add the userEmail parameter to the command
                        command.Parameters.AddWithValue("@userEmail", userEmail);
                        // Execute query and get the number of rows updated
                        int rowsUpdated = command.ExecuteNonQuery();
                        // Check if any rows were deleted
                        if (rowsUpdated > 0)
                        {
                            MessageBox.Show("User deleted successfully.");
                        }
                        else
                        {
                            // If no rows were updated, show a user not found message
                            MessageBox.Show("User not found.");
                        }
                        adminPageUserSearch.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Controls the admin map button visibility depending on user role being admin
        private void CheckAdmin()
        {
            if (SessionManager.UserRole == "admin")
            {
                frontendMap_btnOpenAdminMap.Visible = true;
            }
            else
            {
                frontendMap_btnOpenAdminMap.Visible = false;
            }
        }

        //Moves map camera position to latitude and longitude given by the input textboxes.
        private void frontendMap_btnMoveCamera_Click(object sender, EventArgs e)
        {
            double lat = frontendMap_gMapControl.Position.Lat;
            double lon = frontendMap_gMapControl.Position.Lng;
            bool isValidCoords = true;

            if (frontendMap_txbLatitudeInput.Text != "")
            {
                if (double.TryParse(frontendMap_txbLatitudeInput.Text, out double parsedLat))
                {
                    if (parsedLat >= -90 && parsedLat <= 90)
                        lat = parsedLat;
                    else
                    {
                        isValidCoords = false;
                        MessageBox.Show("Latitude must be between -90 and 90.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    isValidCoords = false;
                    MessageBox.Show("Invalid latitude format.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (frontendMap_txbLongitudeInput.Text != "")
            {
                if (double.TryParse(frontendMap_txbLongitudeInput.Text, out double parsedLon))
                {
                    if (parsedLon >= -180 && parsedLon <= 180)
                        lon = parsedLon;
                    else
                    {
                        isValidCoords = false;
                        MessageBox.Show("Longitude must be between -180 and 180.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    isValidCoords = false;
                    MessageBox.Show("Invalid longitude format.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            //only adjust map position if both inputs are valid
            if (isValidCoords)
                frontendMap_gMapControl.Position = new PointLatLng(lat, lon);
        }
    }
}
