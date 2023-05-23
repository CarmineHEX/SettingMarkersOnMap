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

namespace SettingMarkersOnMap
{
    public partial class Form1 : Form
    {
        Map map = new Map();
        Database d = new Database();
        private int idSelectMarker=-1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            map.LoadMap(gMapControl1, d);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void gMapControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && gMapControl1.Overlays.Count > 0)
            {
                GMapOverlay overlay = gMapControl1.Overlays[0];
                if (overlay.Markers.Count > 0)
                {
                    foreach(KeyValuePair<int, Marker> entry in d.data) {
                        int lat = (int)entry.Value.GetCoordinates().Lat;
                        int lng = (int)entry.Value.GetCoordinates().Lng;
                        int mouselat = (int)gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
                        int mouselng = (int)gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;

                        if ((Math.Abs(lat - mouselat) <= 2 && (Math.Abs(lng - mouselng) <= 2) || entry.Value.isSelect))
                        {
                            idSelectMarker = entry.Key;
                            entry.Value.isSelect = true;
                            PointLatLng point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                            foreach (var marker in overlay.Markers)
                            {
                                if((int)marker.Position.Lat==lat && (int)marker.Position.Lng==lng)
                                {
                                    marker.Position = point;
                                }                       
                            }
                            entry.Value.UpdateCoordinates(point);          
                        }
                    }
                }
            }

        }

        private void gMapControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (idSelectMarker != -1)
            {
                d.data[idSelectMarker].isSelect = false;
                d.SaveCoordiantesMarkerInDatabase(idSelectMarker, d.data[idSelectMarker].GetCoordinates());
            }
        }
    }
}
