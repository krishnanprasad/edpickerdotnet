using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EdPicker.Models
{
    public class Department
    {
        public PDEPTimeline PDEPTimelines { get; set; }
        public PDEPBriefDetail PDEPBriefDetails { get; set; }
        public PDEPStaff PDEPStaffs { get; set; }
        public List<PDEPSubject> PDEPSubjectsList { get; set; }
        public List<PDEPLab> PDEPLabsList { get; set; }
        public List<PDEPNew> PDEPNewsList { get; set; }
        public List<PDEPGallery> PDEPGalleryList { get; set; }
        public PDEPAchievement PDEPAchievement { get; set; }
        public List<PDEPWorkshop> PDEPWorkshopsList { get; set; }
        public List<PDEPLecture> PDEPLectureList { get; set; }
        public List<PDEPSeminar> PDEPSeminarList { get; set; }
        public PDEPPlacementsBasic PDEPPlacementsBasics { get; set; }
        public List<PDEPPlacementCompany> PDEPPlacementCompaniesList { get; set; }
        public List<PDEPReview> PDEPReviewList { get; set; }

    }
}