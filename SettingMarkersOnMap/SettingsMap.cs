using GMap.NET.WindowsForms;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;


namespace SettingMarkersOnMap
{
    internal class SettingsMap
    {
        private double DEFUALT_POSITION_X = 0;
        private double DEFUALT_POSITION_Y = 0;

        private int MIN_ZOOM = 1;
        private int MAX_ZOOM = 20;
        private int DEFAULT_ZOOM = 3;
        private MouseWheelZoomType modeMouseWheelZoom = MouseWheelZoomType.MousePositionAndCenter;

        private AccessMode modeAccess = AccessMode.ServerAndCache;

        private bool isDragMap = true;
        private MouseButtons buttonMouse = MouseButtons.Left;

        private bool isCenter = false;
        private bool isTileGridLines = false;

        public void SetSettingsMap(GMapControl gMapControl)
        {
            SetAccessMode(modeAccess);
            SetProvider(gMapControl);
            SetZoom (gMapControl,MIN_ZOOM,MAX_ZOOM,DEFAULT_ZOOM,modeMouseWheelZoom);
            SetPosition (gMapControl, DEFUALT_POSITION_X, DEFUALT_POSITION_Y);
            SetDragMap(gMapControl, isDragMap, buttonMouse);
            SetShowElementsMap (gMapControl, isCenter, isTileGridLines);
        }
        private void SetZoom (GMapControl gMapControl, int minZoom, int maxZoom, int defualtZoom, MouseWheelZoomType mode )
        {
            gMapControl.MinZoom = minZoom; 
            gMapControl.MaxZoom = maxZoom; 
            gMapControl.Zoom = defualtZoom;
            gMapControl.MouseWheelZoomType = mode;
        }
        private void SetProvider (GMapControl gMapControl)
        {
            gMapControl.MapProvider = GoogleMapProvider.Instance;
        }
        private void SetPosition (GMapControl gMapControl, double DEFUALT_POSITION_X, double DEFUALT_POSITION_Y )
        {
            gMapControl.Position = new PointLatLng(DEFUALT_POSITION_X, DEFUALT_POSITION_Y);
        }
        private void SetAccessMode (AccessMode mode)
        {
            GMaps.Instance.Mode = mode;
        }
        private void SetDragMap (GMapControl gMapControl, bool isDragMap, MouseButtons buttonMouse)
        {
            gMapControl.CanDragMap = isDragMap;
             if(isDragMap == true)
            {
                gMapControl.DragButton = buttonMouse;
            }

        }
        private void SetShowElementsMap (GMapControl gMapControl, bool isCenter, bool isTileGredLines )
        {
            gMapControl.ShowCenter = isCenter; 
            gMapControl.ShowTileGridLines = isTileGredLines;
            gMapControl.Dock = DockStyle.Fill;
        }
    }
}
