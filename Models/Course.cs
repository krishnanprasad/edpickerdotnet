using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdPicker.Models
{
    public class Course
    {
        public COURGeneral COURGenerals { get; set; }
        public List<COUBatchAvailable> COUBatchAvailablesList { get; set; }
        public COUBasicDetail COUBasicDetails { get; set; }
        public List<COUSubjectList> COUSubjectLists { get; set; }
        public COUStaffDetail COUStaffDetails { get; set; }
        public List<COUNew> COUNews { get; set; }
        public List<COULab> COULabList { get; set; }
        public List<COUTestimonial> COUTestimonialList { get; set; }
        public List<COUGallery> COUGalleryList { get; set; }
        public List<COUAchievement> COUAchievementList { get; set; }

    }
}