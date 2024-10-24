namespace CSC2033_TeamProject.Content.Forms
{
    partial class AdminMap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            adminMap_gMapControl = new GMap.NET.WindowsForms.GMapControl();
            adminMap_btnSwitchMapModes = new Button();
            adminMap_btnAddZone = new Button();
            adminMap_btnRemoveZone = new Button();
            adminMap_btnRefreshZone = new Button();
            adminMap_btnSaveZones = new Button();
            adminMap_btnImportData = new Button();
            adminMap_lstbxAllZones = new ListBox();
            adminMap_lblListView = new Label();
            SuspendLayout();
            // 
            // adminMap_gMapControl
            // 
            adminMap_gMapControl.Bearing = 0F;
            adminMap_gMapControl.CanDragMap = true;
            adminMap_gMapControl.EmptyTileColor = Color.Navy;
            adminMap_gMapControl.GrayScaleMode = false;
            adminMap_gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            adminMap_gMapControl.LevelsKeepInMemory = 5;
            adminMap_gMapControl.Location = new Point(10, 11);
            adminMap_gMapControl.Margin = new Padding(3, 2, 3, 2);
            adminMap_gMapControl.MarkersEnabled = true;
            adminMap_gMapControl.MaxZoom = 20;
            adminMap_gMapControl.MinZoom = 1;
            adminMap_gMapControl.MouseWheelZoomEnabled = true;
            adminMap_gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            adminMap_gMapControl.Name = "adminMap_gMapControl";
            adminMap_gMapControl.NegativeMode = false;
            adminMap_gMapControl.PolygonsEnabled = true;
            adminMap_gMapControl.RetryLoadTile = 0;
            adminMap_gMapControl.RoutesEnabled = true;
            adminMap_gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            adminMap_gMapControl.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            adminMap_gMapControl.ShowTileGridLines = false;
            adminMap_gMapControl.Size = new Size(826, 493);
            adminMap_gMapControl.TabIndex = 0;
            adminMap_gMapControl.Zoom = 0D;
            adminMap_gMapControl.Load += adminMap_gMapControl_Load;
            adminMap_gMapControl.KeyDown += ConfirmMap;
            adminMap_gMapControl.MouseClick += HandleMapPoint;
            // 
            // adminMap_btnSwitchMapModes
            // 
            adminMap_btnSwitchMapModes.Location = new Point(10, 513);
            adminMap_btnSwitchMapModes.Margin = new Padding(3, 2, 3, 2);
            adminMap_btnSwitchMapModes.Name = "adminMap_btnSwitchMapModes";
            adminMap_btnSwitchMapModes.Size = new Size(163, 43);
            adminMap_btnSwitchMapModes.TabIndex = 1;
            adminMap_btnSwitchMapModes.Text = "Toggle Map Mode";
            adminMap_btnSwitchMapModes.UseVisualStyleBackColor = true;
            adminMap_btnSwitchMapModes.Click += adminMap_btnSwitchMapModes_Click;
            // 
            // adminMap_btnAddZone
            // 
            adminMap_btnAddZone.Location = new Point(178, 513);
            adminMap_btnAddZone.Margin = new Padding(3, 2, 3, 2);
            adminMap_btnAddZone.Name = "adminMap_btnAddZone";
            adminMap_btnAddZone.Size = new Size(163, 43);
            adminMap_btnAddZone.TabIndex = 2;
            adminMap_btnAddZone.Text = "Add Zone";
            adminMap_btnAddZone.UseVisualStyleBackColor = true;
            adminMap_btnAddZone.Click += adminMap_btnAddZone_Click;
            // 
            // adminMap_btnRemoveZone
            // 
            adminMap_btnRemoveZone.Location = new Point(346, 513);
            adminMap_btnRemoveZone.Margin = new Padding(3, 2, 3, 2);
            adminMap_btnRemoveZone.Name = "adminMap_btnRemoveZone";
            adminMap_btnRemoveZone.Size = new Size(163, 43);
            adminMap_btnRemoveZone.TabIndex = 3;
            adminMap_btnRemoveZone.Text = "Remove Zone";
            adminMap_btnRemoveZone.UseVisualStyleBackColor = true;
            adminMap_btnRemoveZone.Click += adminMap_btnRemoveZone_Click;
            // 
            // adminMap_btnRefreshZone
            // 
            adminMap_btnRefreshZone.Location = new Point(514, 513);
            adminMap_btnRefreshZone.Margin = new Padding(3, 2, 3, 2);
            adminMap_btnRefreshZone.Name = "adminMap_btnRefreshZone";
            adminMap_btnRefreshZone.Size = new Size(163, 43);
            adminMap_btnRefreshZone.TabIndex = 4;
            adminMap_btnRefreshZone.Text = "Refresh Map";
            adminMap_btnRefreshZone.UseVisualStyleBackColor = true;
            adminMap_btnRefreshZone.Click += adminMap_btnRefreshZone_Click;
            // 
            // adminMap_btnSaveZones
            // 
            adminMap_btnSaveZones.Location = new Point(842, 513);
            adminMap_btnSaveZones.Margin = new Padding(3, 2, 3, 2);
            adminMap_btnSaveZones.Name = "adminMap_btnSaveZones";
            adminMap_btnSaveZones.Size = new Size(266, 43);
            adminMap_btnSaveZones.TabIndex = 5;
            adminMap_btnSaveZones.Text = "Save Zones to Database";
            adminMap_btnSaveZones.UseVisualStyleBackColor = true;
            adminMap_btnSaveZones.Click += adminMap_btnSaveZones_Click;
            //
            // adminMap_btnImportData
            //
            adminMap_btnImportData.Location = new Point(10, 513);
            adminMap_btnImportData.Margin = new Padding(3, 2, 3, 2);
            adminMap_btnImportData.Name = "adminMap_btnImportData";
            adminMap_btnImportData.Size = new Size(163, 43);
            adminMap_btnImportData.TabIndex = 8;
            adminMap_btnImportData.Text = "Import Data";
            adminMap_btnImportData.UseVisualStyleBackColor = true;
            adminMap_btnImportData.Click += adminMap_btnImportData_Click;
            Controls.Add(adminMap_btnImportData);
            // 
            // adminMap_lstbxAllZones
            // 
            adminMap_lstbxAllZones.FormattingEnabled = true;
            adminMap_lstbxAllZones.ItemHeight = 15;
            adminMap_lstbxAllZones.Location = new Point(842, 35);
            adminMap_lstbxAllZones.Margin = new Padding(3, 2, 3, 2);
            adminMap_lstbxAllZones.Name = "adminMap_lstbxAllZones";
            adminMap_lstbxAllZones.Size = new Size(266, 469);
            adminMap_lstbxAllZones.TabIndex = 6;
            adminMap_lstbxAllZones.SelectedIndexChanged += MoveMapToZone;
            // 
            // adminMap_lblListView
            // 
            adminMap_lblListView.AutoSize = true;
            adminMap_lblListView.Location = new Point(854, 9);
            adminMap_lblListView.Name = "adminMap_lblListView";
            adminMap_lblListView.Size = new Size(242, 15);
            adminMap_lblListView.TabIndex = 7;
            adminMap_lblListView.Text = "Click on a zone below to focus the map on it";
            // 
            // AdminMap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 567);
            Controls.Add(adminMap_lblListView);
            Controls.Add(adminMap_lstbxAllZones);
            Controls.Add(adminMap_btnSaveZones);
            Controls.Add(adminMap_btnRefreshZone);
            Controls.Add(adminMap_btnRemoveZone);
            Controls.Add(adminMap_btnAddZone);
            Controls.Add(adminMap_btnSwitchMapModes);
            Controls.Add(adminMap_gMapControl);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AdminMap";
            Text = "AdminMap";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl adminMap_gMapControl;
        private Button adminMap_btnSwitchMapModes;
        private Button adminMap_btnAddZone;
        private Button adminMap_btnRemoveZone;
        private Button adminMap_btnRefreshZone;
        private Button adminMap_btnSaveZones;
        private Button adminMap_btnImportData;
        private ListBox adminMap_lstbxAllZones;
        private Label adminMap_lblListView;
    }
}