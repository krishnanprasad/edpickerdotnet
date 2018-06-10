using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdPicker.Models
{
    public class POC
    {
    }
    public class POCImageLoad
    {
        public String ImageName { get; set; }
        public String ImageURL { get; set; }
    }
    public class POCImageLoadList
    {
       public String JSONListImage { get; set; }
       //public List<POCImageLoad> _ListOfImages { get; set; }
    }
}