using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using CSC2033_TeamProject.Content.Classes;

namespace CSC2033_TeamProject.Content.Forms
{
    public partial class AdminMap : Form
    {
        GMapOverlay polyOverlay = new GMapOverlay("ZoneOverlay");
        GMapOverlay mapMarkerOverlay = new GMapOverlay();

        List<PointLatLng> NewZonePoints = new List<PointLatLng>();
        List<PointLatLng> ZoneDrawPoints = new List<PointLatLng>();
        List<PointLatLng> pointBuffer = new List<PointLatLng>();

        List<Zone> LocallySavedZones = new List<Zone>();
        List<Zone> DBZonesToRemove = new List<Zone>();

        bool isMapSatellite = false;
        public AdminMap()
        {
            InitializeComponent();
            adminMap_gMapControl.Position = new PointLatLng(54, -2);
            adminMap_gMapControl.MapProvider = OpenStreetMapProvider.Instance;
            adminMap_gMapControl.Zoom = 5;

            NewZonePoints = pointBuffer.ToList();
            ZoneDrawPoints.Clear();

            LoadZonesFromDatabase();

        }

        bool isDrawingMap = false;

        private void adminMap_btnAddZone_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Drawing Enabled");
            adminMap_btnAddZone.BackColor = Color.Chartreuse;
            isDrawingMap = true;
        }

        private void adminMap_gMapControl_Load(object sender, EventArgs e) { }

        private void LoadZonesFromDatabase()
        {
            List<Zone> zonesFromDatabase = DatabaseHelper.LoadZones(); // Retrieve zones from the database

            foreach (Zone zone in zonesFromDatabase)
            {
                // Create map polygon for each zone and add it to the overlay
                GMapPolygon polygon = new GMapPolygon(zone.Points, zone.Name);
                polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                polygon.Stroke = new Pen(Color.Red, 2);
                polygon.Stroke.DashStyle = DashStyle.Dot;

                // Add the polygon to the overlay
                polyOverlay.Polygons.Add(polygon);

                // Add zone to the list box
                adminMap_lstbxAllZones.Items.Add(zone);

            }

            // Add the overlay to the map control
            adminMap_gMapControl.Overlays.Add(polyOverlay);
        }

        private void HandleMapPoint(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isDrawingMap)
            {

                //Get clicked point
                PointLatLng pt = adminMap_gMapControl.FromLocalToLatLng(e.X, e.Y);

                //Create a new marker for the point
                GMarkerGoogle marker = new GMarkerGoogle(pt, GMarkerGoogleType.red_small);

                mapMarkerOverlay.Markers.Add(marker);
                adminMap_gMapControl.Overlays.Add(mapMarkerOverlay);

                //Add the point to the listb
                NewZonePoints.Add(pt);
                ZoneDrawPoints.Add(pt);

                //If this is not the first point, draw a line to previous point
                if (NewZonePoints.Count > 1)
                {
                    List<PointLatLng> pts = new List<PointLatLng>
                    {
                        ZoneDrawPoints[ZoneDrawPoints.Count - 2],
                        ZoneDrawPoints[ZoneDrawPoints.Count - 1]
                    };
                    GMapRoute constructionLine = new GMapRoute(pts, "constructionLine");
                    constructionLine.Stroke = new Pen(Color.Chartreuse, 3);
                    mapMarkerOverlay.Routes.Add(constructionLine);
                }
                adminMap_gMapControl.Invalidate();
                adminMap_gMapControl.Update();
            }
        }

        //Switches the zone between satellite and vector view
        private void adminMap_btnSwitchMapModes_Click(object sender, EventArgs e)
        {
            switch (isMapSatellite)
            {
                case false:
                    isMapSatellite = true;
                    adminMap_gMapControl.MapProvider = GoogleSatelliteMapProvider.Instance;

                    break;
                case true:
                    isMapSatellite = false;
                    adminMap_gMapControl.MapProvider = OpenStreetMapProvider.Instance;
                    break;
            }
        }

        private void ConfirmMap(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && isDrawingMap)
            {
                //Validation for zone name and description prompts
                bool isNameValid = false;
                bool isDescValid = false;

                string zoneName = "";
                string zoneDesc = "";

                while (isNameValid != true)
                {
                    Prompt zoneNamePrompt = new Prompt("Enter zone name", "Admin Zone Manager");
                    zoneName = zoneNamePrompt.Result;

                    if (zoneName .Length > 0) //and zone doesnt exist in db
                    {        
                        if (DatabaseHelper.CheckZoneByName(zoneName))
                        {
                            MessageBox.Show("Zone already exists in database, points updating...");
                        }

                        if (zoneName == Utils.INVALID_FORM_STRING) //if user cancels input
                        {
                            MessageBox.Show("Zone creation cancelled by user");
                            return;
                        }

                        isNameValid = true;
                    }
                }

                while (isDescValid != true)
                {
                    Prompt zoneDescPrompt = new Prompt("Enter zone description", "Admin Zone Manager");
                    zoneDesc = zoneDescPrompt.Result;

                    if (zoneDesc.Length > 0) //and zone doesnt exist in db
                    {
                        if (zoneDesc == Utils.INVALID_FORM_STRING) //if user cancels input
                        {
                            MessageBox.Show("Zone creation cancelled by user");
                            return;
                        }
                        isDescValid = true;
                    }
                }

                GMapPolygon polygon = new GMapPolygon(NewZonePoints, zoneName);
                polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                polygon.Stroke = new Pen(Color.Red, 2);
                polygon.Stroke.DashStyle = DashStyle.Dot;

                polyOverlay.Polygons.Add(polygon);

                //Add polygon overlay to map and clear markers & route overlays.
                adminMap_gMapControl.Overlays.Add(polyOverlay);
                adminMap_gMapControl.UpdatePolygonLocalPosition(polygon);
                mapMarkerOverlay.Markers.Clear();
                mapMarkerOverlay.Routes.Clear();

                //update map
                adminMap_gMapControl.Invalidate();
                adminMap_gMapControl.Update();

                Zone newZone = new Zone(zoneName, zoneDesc, new List<PointLatLng>(NewZonePoints)); // Copy points to new zone
                LocallySavedZones.Add(newZone);

                NewZonePoints.Clear(); // Clear the points for the next zone

                adminMap_lstbxAllZones.Items.Add(newZone);
                adminMap_lstbxAllZones.DisplayMember = "Name";

                adminMap_btnAddZone.BackColor = Color.White;
                isDrawingMap = false;
            }
        }

        private void adminMap_btnSaveZones_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Saving zones to database");

            foreach (Zone zone in LocallySavedZones)
            {
                // Get zone name and description
                string zoneName = zone.Name;
                string zoneDescription = zone.Description;
                Debug.WriteLine($"Zone Name: {zoneName}, Description: {zoneDescription}");

                // Get latitude and longitude lists from the zone points
                List<double> latitudes = new List<double>();
                List<double> longitudes = new List<double>();
                foreach (PointLatLng point in zone.Points)
                {
                    // Print latitude and longitude for debugging
                    Debug.WriteLine($"Latitude: {point.Lat}, Longitude: {point.Lng}");
                    latitudes.Add(point.Lat);
                    longitudes.Add(point.Lng);
                }
                Debug.WriteLine($"Number of points in the zone: {latitudes.Count}");

                // Save the zone to the database
                DatabaseHelper.SaveZones(zoneName, zoneDescription, latitudes, longitudes);
                Debug.WriteLine("Zone saved to database");
            }

            // Clear the locally saved zones list
            LocallySavedZones.Clear();

            Debug.WriteLine("Locally saved zones cleared");
        }

        private void adminMap_btnRemoveZone_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Removing zones from the database");
            if (adminMap_lstbxAllZones.SelectedItems.Count > 0)
            {
                LocallySavedZones.Clear();
                foreach (var item in adminMap_lstbxAllZones.Items)
                {
                    if (item is Zone zone)
                    {
                        LocallySavedZones.Add(zone);
                    }
                }
                List<Zone> zonesToRemove = new List<Zone>();
                foreach (var selectedItem in adminMap_lstbxAllZones.SelectedItems)
                {
                    Zone? selectedZone = selectedItem as Zone;
                    Debug.WriteLine($"Selected zone: {selectedZone.Name}, {selectedZone.Description}");
                    if (selectedZone != null)
                    {
                        Zone? zoneToRemove = LocallySavedZones.FirstOrDefault(zone => zone.Name == selectedZone.Name);
                        Debug.WriteLine($"Removing zone: {zoneToRemove.Name}, {zoneToRemove.Description}");


                        if (zoneToRemove != null)
                        {
                            zonesToRemove.Add(zoneToRemove);
                        }
                    }
                }
                foreach (Zone zone in zonesToRemove)
                {

                    GMapPolygon? polygonToRemove = polyOverlay.Polygons.FirstOrDefault(polygon => polygon.Name == zone.Name);
                    if (polygonToRemove != null)
                        polyOverlay.Polygons.Remove(polygonToRemove);


                    LocallySavedZones.Remove(zone);
                    DBZonesToRemove.Add(zone);
                }

                // Remove the zones from the database
                DatabaseHelper.DeleteZones(zonesToRemove);
                DBZonesToRemove.Clear();

                foreach (var zone in zonesToRemove)
                {
                    adminMap_lstbxAllZones.Items.Remove(zone);
                }
            }
        }

        private void MoveMapToZone(object sender, EventArgs e)
        {
            if (adminMap_lstbxAllZones.SelectedItems.Count > 0)
            {
                //find position of zone and set map to it
                Zone? selectedZone = adminMap_lstbxAllZones.SelectedItems[0] as Zone;
                if (selectedZone != null)
                {
                    adminMap_gMapControl.Position = selectedZone.GetCentre();
                }
            }
        }

        private void adminMap_btnRefreshZone_Click(object sender, EventArgs e)
        {

        }

        private void adminMap_btnImportData_Click(object sender, EventArgs e)
        {

            // Create OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set dialog properties
            openFileDialog.InitialDirectory = "c:\\"; // Set initial directory
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"; // Set file filter
            openFileDialog.FilterIndex = 1; // Set filter index
            openFileDialog.RestoreDirectory = true; // Restore the directory to the previously selected one

            // Show the dialog and process the result
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Get the selected CSV file path
                    string csvFilePath = openFileDialog.FileName;

                    

                    // Create an instance of RestrictionDataImport
                    RestrictionDataImport dataImport = new RestrictionDataImport(DatabaseManager.connectionString);

                    // Import data from CSV file
                    dataImport.ImportDataFromCSV(csvFilePath);

                    MessageBox.Show("Data imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

