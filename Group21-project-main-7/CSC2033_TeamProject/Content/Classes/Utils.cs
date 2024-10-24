using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC2033_TeamProject.Content.Classes
{
    //Utility methods and values for various purposes.
    internal static class Utils
    {
        public static string INVALID_FORM_STRING = "ZONE_INVALID_INPUT_USER_CLOSE";

        public static void DrawPolygon(GMapControl gMapControl, string overlayName, Zone zone, Color colour)
        {
            List<PointLatLng> points = zone.Points;

            GMapOverlay overlay = new GMapOverlay(overlayName);
            GMapPolygon polygon = new GMapPolygon(points, zone.Name);
            polygon.Fill = new SolidBrush(Color.FromArgb(50, colour));

            overlay.Polygons.Add(polygon);
            gMapControl.Overlays.Add(overlay);

            gMapControl.Refresh();
        }
    }
}
