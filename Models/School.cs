using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdPicker.Models
{
    public class School
    {
        public PSCTimelineDetail PSCTimelineDetails { get; set; }
        public List<PSCAchievement> PSCAchievementList { get; set; }
        public PSCBriefDetail PSCBriefDetails { get; set; }
        public PSCContactDetail PSCContactDetails { get; set; }
        public PSCExtraCurricular PSCExtraCurriculars { get; set; }
        public PSCGeneralDetail PSCGeneralDetails { get; set; }
        public PSCTransport PSCTransports { get; set; }
        public PSCHostel PSCHostels { get; set; }

        public PSCSport PSCSports { get; set; }
        public List<PSCGallery> PSCGalleryList { get; set; }
        public List<PSCNew> PSCNewsList { get; set; }
        public PSCSocialMediaDetail PSCSocialMediaDetails { get; set; }
        public List<PSCTestimonial> PSCTestimonialList { get; set; }

        public List<SearchTable> ComptetitorList { get; set; }
    }
}