using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdPicker.Models
{
    public class Search
    {
        public Int32 SearchCount { get; set; }
        public String SearchTitle { get; set; }
        public List<SearchTable> SearchTable { get; set; }
        public String UserLocation { get; set; }

        public List<MapArray> MapList { get; set; }
    }
    public class SearchTable
    {
        public int SerialNo { get; set; }
        public string InstitutionID { get; set; }
        public string InstitutionName { get; set; }
        public string Location { get; set; }
        public string InstitutionImageURL { get; set; }
        public string InstitutionURL { get; set; }
        public string Tags { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal InformationRating { get; set; }

        public int ViewCount { get; set; }
        public int CityId { get; set; }
        public Nullable<bool> PaidStatus { get; set; }
        public Nullable<int> InstitutionType { get; set; }
    }

    public class MapArray
    {
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public string InstitutionName { get; set; }
        
    }
}