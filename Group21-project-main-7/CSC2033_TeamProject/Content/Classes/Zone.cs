using GMap.NET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC2033_TeamProject.Content.Classes
{
    // A zone is an area drawn on the map, defined as a series of points that form a 2D mesh.
    public class Zone
    {
        // The name of this zone.
        public string Name { get; private set; }

        // Description of this zone's restrictions
        public string Description { get; private set; }

        // The points that compose this zone's boundaries.
        public List<PointLatLng> Points { get; private set; }

        public Zone(string name, string desc, List<PointLatLng> pts)
        {
            Name = name;
            Points = pts;
            Description = desc;
            // Logging
            Debug.WriteLine($"Zone created: Name={Name}, Description={Description}, PointsCount={Points.Count}");
        }

        // Calculates the bounding box for this zone.
        public (double minLat, double maxLat, double minLon, double maxLon) GetBoundingBox()
        {
            if (Points == null || Points.Count == 0)
            {
                // Return default values if no points
                return (0, 0, 0, 0);
            }

            double minLat = Points[0].Lat;
            double maxLat = Points[0].Lat;
            double minLon = Points[0].Lng;
            double maxLon = Points[0].Lng;
            foreach (PointLatLng point in Points)
            {
                minLat = Math.Min(minLat, point.Lat);
                maxLat = Math.Max(maxLat, point.Lat);
                minLon = Math.Min(minLon, point.Lng);
                maxLon = Math.Max(maxLon, point.Lng);
            }
            return (minLat, maxLat, minLon, maxLon);
        }

        // Returns the centre point of the zone.
        public PointLatLng GetCentre()
        {
            if (Points == null || Points.Count == 0)
            {
                // Return default point if no points
                return new PointLatLng(0, 0);
            }

            (double minLat, double maxLat, double minLon, double maxLon) = GetBoundingBox();
            return new PointLatLng((maxLat + minLat) / 2, (maxLon + minLon) / 2);
        }

        // Returns whether this zone contains the point given via parameter using bool inversion
        public bool Contains(double latitude, double longitude)
        {
            if (Points == null || Points.Count == 0)
            {
                // If no points, return false
                return false;
            }

            bool result = false;
            int j = Points.Count - 1;
            for (int i = 0; i < Points.Count; i++)
            {
                if ((Points[i].Lat < latitude && Points[j].Lat >= latitude) ||
                    (Points[j].Lat < latitude && Points[i].Lat >= latitude))
                {
                    if (Points[i].Lng + (latitude - Points[i].Lat) / (Points[j].Lat - Points[i].Lat) * (Points[j].Lng - Points[i].Lng) < longitude)
                        result = !result; //bool inversion
                }
                j = i;
            }
            return result; //once all inversions pass, return the result.
        }

        public override string ToString()
        {
            return (Name + ", " + Description);
        }
    }
}
