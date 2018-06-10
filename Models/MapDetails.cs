using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdPicker.Models
{
    public class MapDetails
    {
        public List<MapData> MapList { get; set; }

        public Double[,] MapAr { get; set; }
    }
    public class MapData
    {
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
        public String Detail { get; set; }
    }
}