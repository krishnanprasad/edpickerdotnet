using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdPicker.Models
{
    public class CoachingCenter
    {
        public PCCBriefDetail PCCBriefDetails { get; set; }
        public PCCTimelineDetail PCCTimelineDetails { get; set; }
        public PCCContactDetail PCCContactDetails { get; set; }
        public PCCGeneralDetail PCCGeneralDetails { get; set; }
        public List<PCCNew> PCCNews { get; set; }
        public List<PCCCourseList> PCCCourseLists { get; set; }
        public PCCSocialMediaDetail PCCSocialMediaDetails { get; set; }
        public List<PCCTestimonial> PCCTestimonialList { get; set; }
        public List<PCCGallery> PCCGalleryList { get; set; }
        public List<SearchTable> ComptetitorList { get; set; }
    }
}