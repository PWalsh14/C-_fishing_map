using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using CSC2033_TeamProject.Content.Classes;

namespace CSC2033_TeamProject.Content.Forms
{
    public partial class RestrictionsManager : Form
    {


    // this has been temporarily commented out as it made everything explode - camina

        //public RestrictionsManager()
        //{
        //    InitializeComponent();
        //}

    //    private void RestrictionsManager_Load(object sender, EventArgs e)
    //    {
    //        // Load existing restrictions from the database and display them in the list box
    //        LoadRestrictions();
    //    }

    //    private void LoadRestrictions()
    //    {
    //        // Retrieve existing restrictions from the database
    //        List<Restriction> restrictions = DatabaseHelper.LoadRestrictions();

    //        // Clear existing items in the list box
    //        adminMap_lstbxRestrictions.Items.Clear();

    //        // Add each restriction to the list box
    //        foreach (var restriction in restrictions)
    //        {
    //            adminMap_lstbxRestrictions.Items.Add(restriction);
    //        }
    //    }

    //    private void adminMap_btnEditRestriction_Click(object sender, EventArgs e)
    //    {
    //        // Code to edit a restriction...
    //    }

    //    private void adminMap_btnCreateRestriction_Click(object sender, EventArgs e)
    //    {
    //        // Code to create a new restriction...
    //    }

    //    private void adminMap_btnUpdateRestrictions_Click(object sender, EventArgs e)
    //    {
    //        // Code to update restrictions...
    //    }

    //    private void adminMap_btnImportData_Click(object sender, EventArgs e)
    //    {
    //        OpenFileDialog openFileDialog = new OpenFileDialog();
    //        openFileDialog.Filter = "CSV Files|*.csv";
    //        openFileDialog.Title = "Select a CSV File";

    //        if (openFileDialog.ShowDialog() == DialogResult.OK)
    //        {
    //            string filePath = openFileDialog.FileName;

    //            // Read CSV file and import data
    //            ImportDataFromCSV(filePath);
    //        }
    //    }

    //    private void ImportDataFromCSV(string filePath)
    //    {
    //        try
    //        {
    //            using (var reader = new StreamReader(filePath))
    //            {
    //                // Skip the header line
    //                reader.ReadLine();

    //                while (!reader.EndOfStream)
    //                {
    //                    var line = reader.ReadLine();
    //                    var values = line.Split(',');

    //                    // Extract data from CSV columns
    //                    string siteName = values[2]; // Column C
    //                    string summary = values[3]; // Column D

    //                    // Map site name to zone name (assuming they are equivalent)
    //                    string zoneName = siteName;

    //                    // Check if the zone exists in the database
    //                    Zone zone = DatabaseHelper.GetZoneByName(zoneName);

    //                    if (zone == null)
    //                    {
    //                        // If the zone doesn't exist, create a new zone
    //                        zone = new Zone { Name = zoneName, Description = "Automatically created zone" };
    //                        DatabaseHelper.AddZone(zone);
    //                    }

    //                    // Create restriction
    //                    Restriction restriction = new Restriction
    //                    {
    //                        Description = summary,
    //                        Type = "", // Leave type empty for user input
    //                        ZoneId = zone.Id
    //                    };

    //                    // Add restriction to the database
    //                    DatabaseHelper.AddRestriction(restriction);
    //                }

    //                MessageBox.Show("Data imported successfully!");
    //                LoadRestrictions(); // Refresh the UI to display imported data
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show($"Error importing data: {ex.Message}");
    //        }
    //    }
    }
}