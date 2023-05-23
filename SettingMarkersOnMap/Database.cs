using GMap.NET;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;



namespace SettingMarkersOnMap
{
    internal class Database
    {
        string connectionString = @"Data Source=REDLRAVE\SQLEXPRESS;Initial Catalog=military_vehicles;Integrated Security=True";
        public Dictionary<int, Marker> data = new Dictionary<int, Marker>();
        public void GetData()
        {
            string query = "SELECT * FROM military_vehicles";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int key = (int)reader["id"];
                            Marker value = new Marker((string)reader["name"], ConvertInPointLatLng(reader), ConvertInMarker(reader));
                            data.Add(key, value);
                        }
                    }
                }
                
            }
        }
        public void SaveCoordiantesMarkerInDatabase(int id, PointLatLng coordinates)
        {
            string query = "UPDATE military_vehicles SET lat="+ coordinates.Lat.ToString().Replace(",",".") + ", lng="+ coordinates.Lng.ToString().Replace(",", ".") + " WHERE id = " + id ;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        private PointLatLng ConvertInPointLatLng(SqlDataReader reader)
        {
            double lat =(double)(reader["lat"]);
            double lng = (double)(reader["lng"]);
            PointLatLng result = new PointLatLng(lat, lng);
            return result;
        }
        private Image ConvertInMarker(SqlDataReader reader)
        {
                byte[] imageBytes = (byte[])reader["marker"];
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Image image = Image.FromStream(ms);
                    return image;
                }
        }

    }
}
