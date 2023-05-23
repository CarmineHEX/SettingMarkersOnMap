using GMap.NET.WindowsForms;
using System.Drawing;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;


namespace SettingMarkersOnMap
{
    internal class Marker 
    {

        private GMapMarker marker;
        private string name;
        private PointLatLng coordinates;
        private Image imageMarker;
        public bool isSelect= false;

        public Marker(string name, PointLatLng coordinates, Image imageMarker )
        {
            this.name = name;
            this.coordinates = coordinates;
            this.imageMarker = imageMarker;
            SetMarker();
        }

        public void UpdateCoordinates (PointLatLng coordinates)
        {
            this.coordinates = coordinates;
        }
        public GMapMarker GetMarker() { return marker; }
        public PointLatLng GetCoordinates() { return coordinates; }
        private void SetMarker()
        {
            marker = new GMarkerGoogle(coordinates, new Bitmap(imageMarker));
            marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
            marker.ToolTipText = name; 
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver; 
        }
         
    }
}
