using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdPicker.Models
{
    public class College
    {
        public List<PCOLDepartment> PCOLDepartmentList { get; set; }
        public PCOLTimelineDetail PCOLTimelineDetails { get; set; }
        public PCOLBriefDetail PCOLBriefDetails { get; set; }
        public PCOLGeneralDetail PCOLGeneralDetails { get; set; }
        public PCOLFaclity PCOLFaclitie { get; set; }
        public PCOLTransport PCOLTransports { get; set; }
        public PCOLHostel PCOLHostels { get; set; }
        public PCOLContactDetail PCOLContactDetails { get; set; }
        public List<PCOLNew> PCOLNewsList { get; set; }
        public PCOLSocialMediaDetail PCOLSocialMediaDetails { get; set; }
        public List<PCOLTestimonial> PCOLTestimonialsList { get; set; }
        public List<PCOLGallery> PCOLGalleryList { get; set; }
        public PCOLSport PCOLSports { get; set; }
        public List<PCOLReview> PCOLReviewList { get; set; }

        public List<SearchTable> ComptetitorList { get; set; }



    }
}