using GMap.NET.WindowsForms;
using System.Collections.Generic;


namespace SettingMarkersOnMap
{
    internal class Map
    {
        
        public void LoadMap(GMapControl gMapControl, Database d)
        {
            d.GetData();
            SettingsMap settingsMap = new SettingsMap();
            settingsMap.SetSettingsMap(gMapControl);
            gMapControl.Overlays.Add(GetOverlayMarkers(d.data));
        }
        private GMapOverlay GetOverlayMarkers(Dictionary<int, Marker> data)
        {
            GMapOverlay markers = new GMapOverlay("markers");
            foreach (KeyValuePair <int, Marker> entry in data)
            {
               markers.Markers.Add(entry.Value.GetMarker());
            }
            return markers;
        }



    }
}
