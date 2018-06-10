using EdPicker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdPicker.Models
{
    public class Kindergarten
    {
        public PKGTimelineDetail KGTimelineDetail { get; set; }
        public PKGBriefDetail KGBriefDetail { get; set; }
        public PKGActivity KGActivity { get; set; }
        public PKGDetail KGDetail { get; set; }
        public PKGContactDetail KGContactDetail { get; set; }
        public PKGSocialMediaDetail KGSocialMediaDetail { get; set; }
        public List<PKGTestimonial> KGTestimonialList { get; set; }
        public List<PKGEventsDetail> KGEventsDetailList { get; set; }
        public List<PKGGallery> KGGalleryList { get; set; }

        public List<SearchTable> ComptetitorList { get; set; }
    }
}