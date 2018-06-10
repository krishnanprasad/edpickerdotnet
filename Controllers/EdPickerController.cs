using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EdPicker;
using EdPicker.Models;

namespace EdPicker.Controllers
{
    public class EdPickerController : Controller
    {
        // GET: EdPicker
        EdPicker.Edlooker_DevEntities1 _database = new EdPicker.Edlooker_DevEntities1();
        public static String _Location = "Coimbatore";
        public ActionResult Index()
        {
             IndexPage _IndexPage = new IndexPage ();
            List<String> TrendingList = (from InstitutionData in _database.PTrendingLists
                                        select InstitutionData.InstitutionID).ToList();
           
            var TrendingQuery = "SELECT * FROM PSearchTable where InstitutionID in ('" + TrendingList[0] + "','" + TrendingList[1] + "','" + TrendingList[2] + "')";
            List<PSearchTable> TrendingData = _database.PSearchTables.SqlQuery(TrendingQuery).ToList();

            
            List<SearchTable> _TrendTable = new List<SearchTable>();

            foreach (var ed in TrendingData)
            {
                SearchTable _Trend = new SearchTable();
                _Trend.InstitutionID = ed.InstitutionID;

                _Trend.InstitutionName = ed.InstitutionName;
                _Trend.Location = ed.Location;
                _Trend.InstitutionImageURL = ed.InstitutionImageURL;
                _Trend.InstitutionType = ed.InstitutionType;
                _Trend.InstitutionURL = ed.InstitutionURL;
                _Trend.PaidStatus = ed.PaidStatus;
                _Trend.InformationRating = ed.InformationRating;
                _TrendTable.Add(_Trend);
            }

            var NewsQuery = "SELECT TOP 3 * FROM PNews order by Updateddate desc";
            List<PNEW> NewsList = _database.PNEWS.SqlQuery(NewsQuery).ToList();

            var CalenderQuery = "SELECT TOP 3 * FROM PCalender order by Updateddate desc";
            List<PCALENDER> CalenderList = _database.PCALENDERs.SqlQuery(CalenderQuery).ToList();

            var BlogQuery = "SELECT TOP 3 * FROM PBlog order by Updateddate desc";
            List<PBLOG> BlogList = _database.PBLOGs.SqlQuery(BlogQuery).ToList();


            _IndexPage.TrendingList = _TrendTable;
            _IndexPage.Location = _Location;
            _IndexPage.BlogListForIndexPage = BlogList;
            _IndexPage.CalenderListForIndexPage = CalenderList;
            _IndexPage.NewsListForIndexPage = NewsList;

            return View(_IndexPage);
        }
        public ActionResult Kindergarten(String InstitutionId)
        {
            
            
            Kindergarten _Kindergarten = new Kindergarten();

            PKGActivity Activities = (from InstitutionData in _database.PKGActivities
                                      where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                      select InstitutionData).FirstOrDefault();

            PKGDetail Detail = (from InstitutionData in _database.PKGDetails
                                where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                select InstitutionData).FirstOrDefault();
            PKGBriefDetail BriefDetail = (from InstitutionData in _database.PKGBriefDetails
                                          where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                          select InstitutionData).FirstOrDefault();
            PKGTimelineDetail TimelineDetail = (from InstitutionData in _database.PKGTimelineDetails
                                                where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                select InstitutionData).FirstOrDefault();
            PKGContactDetail ContactDetail = (from InstitutionData in _database.PKGContactDetails
                                              where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                              select InstitutionData).FirstOrDefault();

            PKGSocialMediaDetail SocialMediaDetail = (from InstitutionData in _database.PKGSocialMediaDetails
                                                      where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                      select InstitutionData).FirstOrDefault();

            List<PKGTestimonial> Testimonial = (from InstitutionData in _database.PKGTestimonials
                                                where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                select InstitutionData).ToList();

            List<PKGGallery> Gallery = (from InstitutionData in _database.PKGGalleries
                                        where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                        select InstitutionData).ToList();

            List<PKGEventsDetail> Events = (from InstitutionData in _database.PKGEventsDetails
                                            where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                            select InstitutionData).ToList();

           PKGCompetitorTable CompetitorTable= (from InstitutionData in _database.PKGCompetitorTables
                                                 where (InstitutionData.InstitutionId.Contains(InstitutionId))
                                                 select InstitutionData).FirstOrDefault();

            var CompQuery = "SELECT * FROM PSearchTable where InstitutionID in ('" + CompetitorTable.InstitutionIDOne + "','" + CompetitorTable.InstitutionIDThree + "','" + CompetitorTable.InstitutionIDTwo + "')";
            List<PSearchTable> CompData = _database.PSearchTables.SqlQuery(CompQuery).ToList();


            List<SearchTable> _CompTable = new List<SearchTable>();

            foreach (var ed in CompData)
            {
                SearchTable _Comp = new SearchTable();
                _Comp.InstitutionID = ed.InstitutionID;

                _Comp.InstitutionName = ed.InstitutionName;
                _Comp.Location = ed.Location;
                _Comp.InstitutionImageURL = ed.InstitutionImageURL;
                _Comp.InstitutionType = ed.InstitutionType;
                _Comp.InstitutionURL = ed.InstitutionURL;
                _Comp.PaidStatus = ed.PaidStatus;
                _Comp.InformationRating = ed.InformationRating;
                _CompTable.Add(_Comp);
            }


            _Kindergarten.ComptetitorList = _CompTable;
            _Kindergarten.KGTimelineDetail = TimelineDetail;
            _Kindergarten.KGActivity = Activities;
            _Kindergarten.KGBriefDetail = BriefDetail;
            _Kindergarten.KGContactDetail = ContactDetail;
            _Kindergarten.KGDetail = Detail;
            _Kindergarten.KGSocialMediaDetail = SocialMediaDetail;
            _Kindergarten.KGGalleryList = Gallery;
            _Kindergarten.KGTestimonialList = Testimonial;
            _Kindergarten.KGEventsDetailList = Events;

            var UpdateUserCount = "Update PSearchTable set viewcount=viewcount+1 where Institutionid='" + InstitutionId + "'";
            int _UpdateUserCount = _database.Database.ExecuteSqlCommand(UpdateUserCount);


            return View(_Kindergarten);
        }
        public ActionResult College(String InstitutionId)
        {
            var UpdateUserCount = "Update PSearchTable set viewcount=viewcount+1 where Institutionid='" + InstitutionId + "'";
            int _UpdateUserCount = _database.Database.ExecuteSqlCommand(UpdateUserCount);

            College _College = new College();

            List<PCOLDepartment> DepartmentList = (from InstitutionData in _database.PCOLDepartments
                                      where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                      select InstitutionData).ToList();

           
            PCOLBriefDetail BriefDetail = (from InstitutionData in _database.PCOLBriefDetails
                                          where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                          select InstitutionData).FirstOrDefault();
            PCOLTimelineDetail TimelineDetail = (from InstitutionData in _database.PCOLTimelineDetails
                                                where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                select InstitutionData).FirstOrDefault();
            PCOLContactDetail ContactDetail = (from InstitutionData in _database.PCOLContactDetails
                                               where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                              select InstitutionData).FirstOrDefault();

            PCOLSocialMediaDetail SocialMediaDetail = (from InstitutionData in _database.PCOLSocialMediaDetails
                                                      where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                      select InstitutionData).FirstOrDefault();

            PCOLTransport Transport = (from InstitutionData in _database.PCOLTransports
                                                       where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                       select InstitutionData).FirstOrDefault();
            PCOLHostel Hostel = (from InstitutionData in _database.PCOLHostels
                                                       where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                       select InstitutionData).FirstOrDefault();
            PCOLSport Sports = (from InstitutionData in _database.PCOLSports
                                 where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                 select InstitutionData).FirstOrDefault();

            List<PCOLTestimonial> Testimonial = (from InstitutionData in _database.PCOLTestimonials
                                                where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                select InstitutionData).ToList();

            List<PCOLGallery> Gallery = (from InstitutionData in _database.PCOLGalleries
                                        where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                        select InstitutionData).ToList();

            List<PCOLReview> Reviews = (from InstitutionData in _database.PCOLReviews
                                            where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                            select InstitutionData).ToList();

            List<PCOLNew> News = (from InstitutionData in _database.PCOLNews
                                        where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                        select InstitutionData).ToList();
            PCOLFaclity Facility = (from InstitutionData in _database.PCOLFaclities
                                 where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                 select InstitutionData).FirstOrDefault();
            PCOLGeneralDetail GeneralDetails = (from InstitutionData in _database.PCOLGeneralDetails
                                 where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                 select InstitutionData).FirstOrDefault();

            PCOLCompetitorTable CompetitorTable = (from InstitutionData in _database.PCOLCompetitorTables
                                               where (InstitutionData.InstitutionId.Contains(InstitutionId))
                                               select InstitutionData).FirstOrDefault();

            var CompQuery = "SELECT * FROM PSearchTable where InstitutionID in ('" + CompetitorTable.InstitutionIDOne + "','" + CompetitorTable.InstitutionIDThree + "','" + CompetitorTable.InstitutionIDTwo + "')";
            List<PSearchTable> CompData = _database.PSearchTables.SqlQuery(CompQuery).ToList();


            List<SearchTable> _CompTable = new List<SearchTable>();

            foreach (var ed in CompData)
            {
                SearchTable _Comp = new SearchTable();
                _Comp.InstitutionID = ed.InstitutionID;

                _Comp.InstitutionName = ed.InstitutionName;
                _Comp.Location = ed.Location;
                _Comp.InstitutionImageURL = ed.InstitutionImageURL;
                _Comp.InstitutionType = ed.InstitutionType;
                _Comp.InstitutionURL = ed.InstitutionURL;
                _Comp.PaidStatus = ed.PaidStatus;
                _Comp.InformationRating = ed.InformationRating;
                _CompTable.Add(_Comp);
            }


            _College.ComptetitorList = _CompTable;
            _College.PCOLTimelineDetails = TimelineDetail;
            _College.PCOLDepartmentList = DepartmentList;
            _College.PCOLBriefDetails = BriefDetail;
            _College.PCOLContactDetails = ContactDetail;
            _College.PCOLGeneralDetails = GeneralDetails;
            _College.PCOLFaclitie = Facility;
            _College.PCOLSports = Sports;
            _College.PCOLHostels = Hostel;
            _College.PCOLNewsList = News;
            _College.PCOLTransports = Transport;
            _College.PCOLSocialMediaDetails = SocialMediaDetail;
            _College.PCOLGalleryList = Gallery;
            _College.PCOLReviewList = Reviews;
            _College.PCOLTestimonialsList = Testimonial;
            _College.PCOLTestimonialsList = Testimonial;
            _College.PCOLReviewList = Reviews;

            return View(_College);
        }
        public ActionResult School(String InstitutionId)
        {
            var UpdateUserCount = "Update PSearchTable set viewcount=viewcount+1 where Institutionid='" + InstitutionId + "'";
            int _UpdateUserCount = _database.Database.ExecuteSqlCommand(UpdateUserCount);
            Models.School _School = new Models.School();

            PSCTimelineDetail PSCTimelineDetails = (from InstitutionData in _database.PSCTimelineDetails
                                                    where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                    select InstitutionData).FirstOrDefault();
            List<PSCAchievement> PSCAchievementList = (from InstitutionData in _database.PSCAchievements
                                                       where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                       select InstitutionData).ToList();
            PSCBriefDetail PSCBriefDetails = (from InstitutionData in _database.PSCBriefDetails
                                              where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                              select InstitutionData).FirstOrDefault();
            PSCContactDetail PSCContactDetails = (from InstitutionData in _database.PSCContactDetails
                                                  where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                  select InstitutionData).FirstOrDefault();
            PSCExtraCurricular PSCExtraCurriculars = (from InstitutionData in _database.PSCExtraCurriculars
                                                      where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                      select InstitutionData).FirstOrDefault();
            PSCGeneralDetail PSCGeneralDetails = (from InstitutionData in _database.PSCGeneralDetails
                                                  where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                  select InstitutionData).FirstOrDefault();
            PSCTransport PSCTransports = (from InstitutionData in _database.PSCTransports
                                          where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                          select InstitutionData).FirstOrDefault();
            PSCHostel PSCHostels = (from InstitutionData in _database.PSCHostels
                                    where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                    select InstitutionData).FirstOrDefault();
            List<PSCGallery> PSCGalleryList = (from InstitutionData in _database.PSCGalleries
                                               where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                               select InstitutionData).ToList();
            List<PSCNew> PSCNewsList = (from InstitutionData in _database.PSCNews
                                        where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                        select InstitutionData).ToList();
            PSCSocialMediaDetail PSCSocialMediaDetails = (from InstitutionData in _database.PSCSocialMediaDetails
                                                          where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                          select InstitutionData).FirstOrDefault();
            PSCSport PSCSports = (from InstitutionData in _database.PSCSports
                                                          where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                          select InstitutionData).FirstOrDefault();
            List<PSCTestimonial> PSCTestimonialList = (from InstitutionData in _database.PSCTestimonials
                                                       where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                       select InstitutionData).ToList();

            PSCCompetitorTable CompetitorTable = (from InstitutionData in _database.PSCCompetitorTables
                                                   where (InstitutionData.InstitutionId.Contains(InstitutionId))
                                                   select InstitutionData).FirstOrDefault();

            var CompQuery = "SELECT * FROM PSearchTable where InstitutionID in ('" + CompetitorTable.InstitutionIDOne + "','" + CompetitorTable.InstitutionIDThree + "','" + CompetitorTable.InstitutionIDTwo + "')";
            List<PSearchTable> CompData = _database.PSearchTables.SqlQuery(CompQuery).ToList();


            List<SearchTable> _CompTable = new List<SearchTable>();

            foreach (var ed in CompData)
            {
                SearchTable _Comp = new SearchTable();
                _Comp.InstitutionID = ed.InstitutionID;

                _Comp.InstitutionName = ed.InstitutionName;
                _Comp.Location = ed.Location;
                _Comp.InstitutionImageURL = ed.InstitutionImageURL;
                _Comp.InstitutionType = ed.InstitutionType;
                _Comp.InstitutionURL = ed.InstitutionURL;
                _Comp.PaidStatus = ed.PaidStatus;
                _Comp.InformationRating = ed.InformationRating;
                _CompTable.Add(_Comp);
            }

            _School.ComptetitorList = _CompTable;
            _School.PSCTimelineDetails = PSCTimelineDetails;
            _School.PSCTransports = PSCTransports;
            _School.PSCAchievementList = PSCAchievementList;
            _School.PSCBriefDetails = PSCBriefDetails;
            _School.PSCContactDetails = PSCContactDetails;
            _School.PSCExtraCurriculars = PSCExtraCurriculars;
            _School.PSCGalleryList = PSCGalleryList;
            _School.PSCGeneralDetails = PSCGeneralDetails;
            _School.PSCHostels = PSCHostels;
            _School.PSCTestimonialList = PSCTestimonialList;
            _School.PSCNewsList = PSCNewsList;
            _School.PSCSports = PSCSports;
            _School.PSCSocialMediaDetails = PSCSocialMediaDetails;
            return View(_School);
        }
        public ActionResult Department(String DepartmentId)
        {
            Department _Department = new Department();

            List<PDEPSubject> DepartmentList = (from InstitutionData in _database.PDEPSubjects
                                                   where (InstitutionData.DepartmentID.Contains(DepartmentId))
                                                   select InstitutionData).ToList();


            PDEPBriefDetail BriefDetail = (from InstitutionData in _database.PDEPBriefDetails
                                           where (InstitutionData.DepartmentID.Contains(DepartmentId))
                                           select InstitutionData).FirstOrDefault();

            PDEPTimeline TimelineDetail = (from InstitutionData in _database.PDEPTimelines
                                           where (InstitutionData.DepartmentID.Contains(DepartmentId))
                                                 select InstitutionData).FirstOrDefault();


            PDEPStaff Staff = (from InstitutionData in _database.PDEPStaffs
                                               where (InstitutionData.DepartmentID.Contains(DepartmentId))
                                               select InstitutionData).FirstOrDefault();

            List<PDEPSeminar> Seminar = (from InstitutionData in _database.PDEPSeminars
                                                       where (InstitutionData.DepartmentID.Contains(DepartmentId))
                                                       select InstitutionData).ToList();
            List<PDEPLecture> Lecture= (from InstitutionData in _database.PDEPLectures
                                         where (InstitutionData.DepartmentID.Contains(DepartmentId))
                                         select InstitutionData).ToList();
            List<PDEPWorkshop> Workshop = (from InstitutionData in _database.PDEPWorkshops
                                         where (InstitutionData.DepartmentID.Contains(DepartmentId))
                                         select InstitutionData).ToList();

            PDEPAchievement Achievement = (from InstitutionData in _database.PDEPAchievements
                                           where (InstitutionData.DepartmentID.Contains(DepartmentId))
                                           select InstitutionData).FirstOrDefault();

            List<PDEPPlacementCompany> PlacementCompanyList = (from InstitutionData in _database.PDEPPlacementCompanies
                                                      where (InstitutionData.DepartmentID.Contains(DepartmentId))
                                                 select InstitutionData).ToList();

            List<PDEPGallery> Gallery = (from InstitutionData in _database.PDEPGalleries
                                         where (InstitutionData.DepartmentID.Contains(DepartmentId))
                                         select InstitutionData).ToList();

            List<PDEPReview> Reviews = (from InstitutionData in _database.PDEPReviews
                                        where (InstitutionData.DepartmentID.Contains(DepartmentId))
                                        select InstitutionData).ToList();

            List<PDEPNew> News = (from InstitutionData in _database.PDEPNews
                                  where (InstitutionData.DepartmentID.Contains(DepartmentId))
                                  select InstitutionData).ToList();
            PDEPPlacementsBasic Placementbasic = (from InstitutionData in _database.PDEPPlacementsBasics
                                    where (InstitutionData.DepartmentID.Contains(DepartmentId))
                                    select InstitutionData).FirstOrDefault();
            List<PDEPLab> Lab = (from InstitutionData in _database.PDEPLabs
                                                where (InstitutionData.DepartmentID.Contains(DepartmentId))
                                                select InstitutionData).ToList();

            List<PDEPSubject> Subjects = (from InstitutionData in _database.PDEPSubjects
                                 where (InstitutionData.DepartmentID.Contains(DepartmentId))
                                 select InstitutionData).ToList();

            _Department.PDEPTimelines = TimelineDetail;
            _Department.PDEPBriefDetails = BriefDetail;
            _Department.PDEPStaffs = Staff;
            _Department.PDEPSubjectsList = Subjects;
            _Department.PDEPLabsList = Lab;
            _Department.PDEPNewsList = News;
            _Department.PDEPGalleryList = Gallery;
            _Department.PDEPAchievement = Achievement;
            _Department.PDEPWorkshopsList = Workshop;
            _Department.PDEPLectureList = Lecture;
            _Department.PDEPSeminarList = Seminar;
            _Department.PDEPPlacementsBasics = Placementbasic;
            _Department.PDEPPlacementCompaniesList = PlacementCompanyList;
            _Department.PDEPReviewList = Reviews;

            return View(_Department);
        }
        public ActionResult Search(String q,String Location)
        {

            DateTime now = DateTime.Now;
            String timeStamp = now.ToString();

            var SaveUserSearch = "Insert into PUserSearch values(" + "'" + q + "'," + "'" + Location + "'," + "'" + timeStamp + "')";
            int _SaveUserSearch = _database.Database.ExecuteSqlCommand(SaveUserSearch);


            Search _SearchList = new Search();
            List<SearchTable> _PSearchList = new List<SearchTable>();
            var SearchTerm = "," + q;
            var locationTerm = "," + Location;
            _Location = Location;
            var searchlist = (from Search in _database.PSearchTables
                              where (Search.Tags.Contains(SearchTerm) && Search.LocationTags.Contains(locationTerm))
                              
                              orderby Search.InformationRating descending                         
                              select new SearchTable
                              {
                                  InstitutionID = Search.InstitutionID,
                                  InstitutionName = Search.InstitutionName,
                                  Location = Search.Location,
                                  InstitutionImageURL = Search.InstitutionImageURL,
                                  InstitutionType = Search.InstitutionType,
                                  InstitutionURL = Search.InstitutionURL,
                                  PaidStatus = Search.PaidStatus,
                                  InformationRating = Search.InformationRating,
                                  Latitude = Search.Latitude??0,
                                  Longitude = Search.Longitude ?? 0,
                                  ViewCount = Search.ViewCount??0
                              }
                              
                              ).ToList();
            MapDetails _Map = new MapDetails();
            List<MapArray> _MapArrayList =new List<MapArray>();
            int i = 0;
            foreach (var ed in searchlist)
            {
                MapArray _MapArray = new MapArray();
                _MapArray.latitude= ed.Latitude;

                _MapArray.longitude= ed.Longitude;
               
                _MapArray.InstitutionName = ed.InstitutionName;
                _MapArrayList.Add(_MapArray);
            }

            _PSearchList =searchlist;


            _SearchList.UserLocation = _Location;
            _SearchList.SearchCount = searchlist.Count;
            _SearchList.SearchTitle = q;
            _SearchList.SearchTable= _PSearchList;
            _SearchList.MapList = _MapArrayList;

         

            return View(_SearchList);

          

        }
        //public JsonResult GetTags(String q)
        //{

        //    var SearchFitler = (from aud in _database.PTags
        //                        where (aud.Tags.Contains(q))
        //                        select aud.Tags).ToList();
        //    return Json(SearchFitler, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult GetTags(String q)
        {

            var SearchTerm = q;
            var Query = "SELECT TOP 3 * FROM PTags where Tags like '%" + SearchTerm + "%'";
            var SearchFitler = _database.PTags.SqlQuery(Query).ToList();

            if (SearchFitler.Count < 1)
            {
                var KeywordUnavailability = "Insert into PUserKeyWordSearch values(" + "'" + q + "')";
                int _KeywordUnavailability = _database.Database.ExecuteSqlCommand(KeywordUnavailability);
            }
            return Json(SearchFitler, JsonRequestBehavior.AllowGet);
        }

        public String AddCount(String SNo,String Module)
        {
            try {
                var SaveUserSearchSQL = "Insert into PUserSearch values(" + "'" + Module + "'," + "'" + SNo + "'," + "'" + DateTime.Now + "')";
                int _SaveUserSearchStatus = _database.Database.ExecuteSqlCommand(SaveUserSearchSQL);

               

                var AddCountSQL = "Update P"+Module+ " set TotalView=TotalView+1 where SNo=" + SNo;
                int _AddCountStatus = _database.Database.ExecuteSqlCommand(AddCountSQL);
                return "Success";
}
            catch {
                return "Failed";
            }
        }

        public JsonResult GetLocation(String Location)

        {
            var SearchTerm = Location;
            var Query = "SELECT TOP 3 * FROM PCityDetails where CityName like '%" + SearchTerm + "%'";
            var SearchLocation = _database.PCityDetails.SqlQuery(Query).ToList();

            if (SearchLocation.Count < 1)
            {
                var LocationUnavailability = "Insert into PUserLocationKeyword values(" + "'" + Location + "')";
                int _LocationUnavailability = _database.Database.ExecuteSqlCommand(LocationUnavailability);
            }

            return Json(SearchLocation, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLocationTrial(String Location)

        {
            var SearchTerm = Location;

            if (Location != "")
            {
                var Query = "SELECT TOP 3 * FROM PCityDetails where CityName like '%" + SearchTerm + "%'";
                var SearchLocation = _database.PCityDetails.SqlQuery(Query).ToList();
                return Json(SearchLocation, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult GoToPage(String InstitutionId)
        {
            int InstitutionType = Convert.ToInt16((from InstitutionData in _database.PSearchTables
                                where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                select InstitutionData.InstitutionType).FirstOrDefault());
            String PageName = "";
            if (InstitutionType == 1)
            {
                PageName = "Kindergarten";
               
            }
            if (InstitutionType == 2)
            {
                PageName = "School";
               
            }
            if (InstitutionType == 3)
            {
                PageName = "College";
               
            }
           if (InstitutionType == 4)
            {
                PageName = "CoachingCenter";
               
            }
            
            if (InstitutionType == 5)
            {
                PageName = "Course";

            }
            if (InstitutionType == 6)
            {
                PageName = "CoachingAcademy";

            }
            if (InstitutionType == 7)
            {
                PageName = "Sports";

            }
            if (InstitutionType == 8)
            {
                PageName = "Arts";

            }
            return RedirectToAction(PageName, new { InstitutionId });
        }
        public ActionResult CoachingCenter(String InstitutionId)
        {
            var UpdateUserCount = "Update PSearchTable set viewcount=viewcount+1 where Institutionid='" + InstitutionId + "'";
            int _UpdateUserCount = _database.Database.ExecuteSqlCommand(UpdateUserCount);

            CoachingCenter _CoachingCenter = new CoachingCenter();

            PCCBriefDetail Brief = (from InstitutionData in _database.PCCBriefDetails
                                   where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                   select InstitutionData).FirstOrDefault();


            PCCTimelineDetail Timeline = (from InstitutionData in _database.PCCTimelineDetails
                                       where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                       select InstitutionData).FirstOrDefault();


            PCCContactDetail Contact = (from InstitutionData in _database.PCCContactDetails
                                    where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                    select InstitutionData).FirstOrDefault();

            List<PCCCourseList> CourseList = (from InstitutionData in _database.PCCCourseLists
                                            where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                            select InstitutionData).ToList();


            PCCGeneralDetail General = (from InstitutionData in _database.PCCGeneralDetails
                                    where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                    select InstitutionData).FirstOrDefault();

            PCCSocialMediaDetail SocialMedia = (from InstitutionData in _database.PCCSocialMediaDetails
                                where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                select InstitutionData).FirstOrDefault();
            
            List<PCCNew> News = (from InstitutionData in _database.PCCNews
                                 where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                 select InstitutionData).ToList();

            List<PCCTestimonial> Testimonial = (from InstitutionData in _database.PCCTestimonials
                                                where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                select InstitutionData).ToList();

            List<PCCGallery> Gallery = (from InstitutionData in _database.PCCGalleries
                                        where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                        select InstitutionData).ToList();

            PCCCompetitorTable CompetitorTable = (from InstitutionData in _database.PCCCompetitorTables
                                                   where (InstitutionData.InstitutionId.Contains(InstitutionId))
                                                   select InstitutionData).FirstOrDefault();

            var CompQuery = "SELECT * FROM PSearchTable where InstitutionID in ('" + CompetitorTable.InstitutionIDOne + "','" + CompetitorTable.InstitutionIDThree + "','" + CompetitorTable.InstitutionIDTwo + "')";
            List<PSearchTable> CompData = _database.PSearchTables.SqlQuery(CompQuery).ToList();


            List<SearchTable> _CompTable = new List<SearchTable>();

            foreach (var ed in CompData)
            {
                SearchTable _Comp = new SearchTable();
                _Comp.InstitutionID = ed.InstitutionID;

                _Comp.InstitutionName = ed.InstitutionName;
                _Comp.Location = ed.Location;
                _Comp.InstitutionImageURL = ed.InstitutionImageURL;
                _Comp.InstitutionType = ed.InstitutionType;
                _Comp.InstitutionURL = ed.InstitutionURL;
                _Comp.PaidStatus = ed.PaidStatus;
                _Comp.InformationRating = ed.InformationRating;
                _CompTable.Add(_Comp);
            }

            _CoachingCenter.ComptetitorList = _CompTable;

            _CoachingCenter.PCCBriefDetails = Brief;
            _CoachingCenter.PCCTimelineDetails = Timeline;
            _CoachingCenter.PCCContactDetails = Contact;
            _CoachingCenter.PCCCourseLists = CourseList;
            _CoachingCenter.PCCGeneralDetails = General;
            _CoachingCenter.PCCSocialMediaDetails = SocialMedia;
            _CoachingCenter.PCCNews = News;
            _CoachingCenter.PCCTestimonialList = Testimonial;
            _CoachingCenter.PCCGalleryList = Gallery;

            return View(_CoachingCenter);
        }
        public ActionResult CoachingAcademy(String InstitutionId)
        {
            var UpdateUserCount = "Update PSearchTable set viewcount=viewcount+1 where Institutionid='" + InstitutionId + "'";
            int _UpdateUserCount = _database.Database.ExecuteSqlCommand(UpdateUserCount);

            CoachingCenter _CoachingCenter = new CoachingCenter();

            PCCBriefDetail Brief = (from InstitutionData in _database.PCCBriefDetails
                                    where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                    select InstitutionData).FirstOrDefault();


            PCCTimelineDetail Timeline = (from InstitutionData in _database.PCCTimelineDetails
                                          where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                          select InstitutionData).FirstOrDefault();


            PCCContactDetail Contact = (from InstitutionData in _database.PCCContactDetails
                                        where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                        select InstitutionData).FirstOrDefault();

            List<PCCCourseList> CourseList = (from InstitutionData in _database.PCCCourseLists
                                              where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                              select InstitutionData).ToList();


            PCCGeneralDetail General = (from InstitutionData in _database.PCCGeneralDetails
                                        where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                        select InstitutionData).FirstOrDefault();

            PCCSocialMediaDetail SocialMedia = (from InstitutionData in _database.PCCSocialMediaDetails
                                                where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                select InstitutionData).FirstOrDefault();

            List<PCCNew> News = (from InstitutionData in _database.PCCNews
                                 where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                 select InstitutionData).ToList();

            List<PCCTestimonial> Testimonial = (from InstitutionData in _database.PCCTestimonials
                                                where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                select InstitutionData).ToList();

            List<PCCGallery> Gallery = (from InstitutionData in _database.PCCGalleries
                                        where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                        select InstitutionData).ToList();

            PCCCompetitorTable CompetitorTable = (from InstitutionData in _database.PCCCompetitorTables
                                                  where (InstitutionData.InstitutionId.Contains(InstitutionId))
                                                  select InstitutionData).FirstOrDefault();

            var CompQuery = "SELECT * FROM PSearchTable where InstitutionID in ('" + CompetitorTable.InstitutionIDOne + "','" + CompetitorTable.InstitutionIDThree + "','" + CompetitorTable.InstitutionIDTwo + "')";
            List<PSearchTable> CompData = _database.PSearchTables.SqlQuery(CompQuery).ToList();


            List<SearchTable> _CompTable = new List<SearchTable>();

            foreach (var ed in CompData)
            {
                SearchTable _Comp = new SearchTable();
                _Comp.InstitutionID = ed.InstitutionID;

                _Comp.InstitutionName = ed.InstitutionName;
                _Comp.Location = ed.Location;
                _Comp.InstitutionImageURL = ed.InstitutionImageURL;
                _Comp.InstitutionType = ed.InstitutionType;
                _Comp.InstitutionURL = ed.InstitutionURL;
                _Comp.PaidStatus = ed.PaidStatus;
                _Comp.InformationRating = ed.InformationRating;
                _CompTable.Add(_Comp);
            }

            _CoachingCenter.ComptetitorList = _CompTable;

            _CoachingCenter.PCCBriefDetails = Brief;
            _CoachingCenter.PCCTimelineDetails = Timeline;
            _CoachingCenter.PCCContactDetails = Contact;
            _CoachingCenter.PCCCourseLists = CourseList;
            _CoachingCenter.PCCGeneralDetails = General;
            _CoachingCenter.PCCSocialMediaDetails = SocialMedia;
            _CoachingCenter.PCCNews = News;
            _CoachingCenter.PCCTestimonialList = Testimonial;
            _CoachingCenter.PCCGalleryList = Gallery;

            return View(_CoachingCenter);
        }

        public ActionResult Sports(String InstitutionId)
        {

            var UpdateUserCount = "Update PSearchTable set viewcount=viewcount+1 where Institutionid='" + InstitutionId + "'";
            int _UpdateUserCount = _database.Database.ExecuteSqlCommand(UpdateUserCount);
            CoachingCenter _CoachingCenter = new CoachingCenter();

            PCCBriefDetail Brief = (from InstitutionData in _database.PCCBriefDetails
                                    where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                    select InstitutionData).FirstOrDefault();


            PCCTimelineDetail Timeline = (from InstitutionData in _database.PCCTimelineDetails
                                          where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                          select InstitutionData).FirstOrDefault();


            PCCContactDetail Contact = (from InstitutionData in _database.PCCContactDetails
                                        where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                        select InstitutionData).FirstOrDefault();

            List<PCCCourseList> CourseList = (from InstitutionData in _database.PCCCourseLists
                                              where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                              select InstitutionData).ToList();


            PCCGeneralDetail General = (from InstitutionData in _database.PCCGeneralDetails
                                        where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                        select InstitutionData).FirstOrDefault();

            PCCSocialMediaDetail SocialMedia = (from InstitutionData in _database.PCCSocialMediaDetails
                                                where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                select InstitutionData).FirstOrDefault();

            List<PCCNew> News = (from InstitutionData in _database.PCCNews
                                 where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                 select InstitutionData).ToList();

            List<PCCTestimonial> Testimonial = (from InstitutionData in _database.PCCTestimonials
                                                where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                select InstitutionData).ToList();

            List<PCCGallery> Gallery = (from InstitutionData in _database.PCCGalleries
                                        where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                        select InstitutionData).ToList();

            PCCCompetitorTable CompetitorTable = (from InstitutionData in _database.PCCCompetitorTables
                                                  where (InstitutionData.InstitutionId.Contains(InstitutionId))
                                                  select InstitutionData).FirstOrDefault();

            var CompQuery = "SELECT * FROM PSearchTable where InstitutionID in ('" + CompetitorTable.InstitutionIDOne + "','" + CompetitorTable.InstitutionIDThree + "','" + CompetitorTable.InstitutionIDTwo + "')";
            List<PSearchTable> CompData = _database.PSearchTables.SqlQuery(CompQuery).ToList();


            List<SearchTable> _CompTable = new List<SearchTable>();

            foreach (var ed in CompData)
            {
                SearchTable _Comp = new SearchTable();
                _Comp.InstitutionID = ed.InstitutionID;

                _Comp.InstitutionName = ed.InstitutionName;
                _Comp.Location = ed.Location;
                _Comp.InstitutionImageURL = ed.InstitutionImageURL;
                _Comp.InstitutionType = ed.InstitutionType;
                _Comp.InstitutionURL = ed.InstitutionURL;
                _Comp.PaidStatus = ed.PaidStatus;
                _Comp.InformationRating = ed.InformationRating;
                _CompTable.Add(_Comp);
            }

            _CoachingCenter.ComptetitorList = _CompTable;

            _CoachingCenter.PCCBriefDetails = Brief;
            _CoachingCenter.PCCTimelineDetails = Timeline;
            _CoachingCenter.PCCContactDetails = Contact;
            _CoachingCenter.PCCCourseLists = CourseList;
            _CoachingCenter.PCCGeneralDetails = General;
            _CoachingCenter.PCCSocialMediaDetails = SocialMedia;
            _CoachingCenter.PCCNews = News;
            _CoachingCenter.PCCTestimonialList = Testimonial;
            _CoachingCenter.PCCGalleryList = Gallery;

            return View(_CoachingCenter);
        }
        public ActionResult Arts(String InstitutionId)
        {

            var UpdateUserCount = "Update PSearchTable set viewcount=viewcount+1 where Institutionid='" + InstitutionId + "'";
            int _UpdateUserCount = _database.Database.ExecuteSqlCommand(UpdateUserCount);
            CoachingCenter _CoachingCenter = new CoachingCenter();

            PCCBriefDetail Brief = (from InstitutionData in _database.PCCBriefDetails
                                    where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                    select InstitutionData).FirstOrDefault();


            PCCTimelineDetail Timeline = (from InstitutionData in _database.PCCTimelineDetails
                                          where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                          select InstitutionData).FirstOrDefault();


            PCCContactDetail Contact = (from InstitutionData in _database.PCCContactDetails
                                        where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                        select InstitutionData).FirstOrDefault();

            List<PCCCourseList> CourseList = (from InstitutionData in _database.PCCCourseLists
                                              where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                              select InstitutionData).ToList();


            PCCGeneralDetail General = (from InstitutionData in _database.PCCGeneralDetails
                                        where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                        select InstitutionData).FirstOrDefault();

            PCCSocialMediaDetail SocialMedia = (from InstitutionData in _database.PCCSocialMediaDetails
                                                where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                select InstitutionData).FirstOrDefault();

            List<PCCNew> News = (from InstitutionData in _database.PCCNews
                                 where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                 select InstitutionData).ToList();

            List<PCCTestimonial> Testimonial = (from InstitutionData in _database.PCCTestimonials
                                                where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                                select InstitutionData).ToList();

            List<PCCGallery> Gallery = (from InstitutionData in _database.PCCGalleries
                                        where (InstitutionData.InstitutionID.Contains(InstitutionId))
                                        select InstitutionData).ToList();

            PCCCompetitorTable CompetitorTable = (from InstitutionData in _database.PCCCompetitorTables
                                                  where (InstitutionData.InstitutionId.Contains(InstitutionId))
                                                  select InstitutionData).FirstOrDefault();

            var CompQuery = "SELECT * FROM PSearchTable where InstitutionID in ('" + CompetitorTable.InstitutionIDOne + "','" + CompetitorTable.InstitutionIDThree + "','" + CompetitorTable.InstitutionIDTwo + "')";
            List<PSearchTable> CompData = _database.PSearchTables.SqlQuery(CompQuery).ToList();


            List<SearchTable> _CompTable = new List<SearchTable>();

            foreach (var ed in CompData)
            {
                SearchTable _Comp = new SearchTable();
                _Comp.InstitutionID = ed.InstitutionID;

                _Comp.InstitutionName = ed.InstitutionName;
                _Comp.Location = ed.Location;
                _Comp.InstitutionImageURL = ed.InstitutionImageURL;
                _Comp.InstitutionType = ed.InstitutionType;
                _Comp.InstitutionURL = ed.InstitutionURL;
                _Comp.PaidStatus = ed.PaidStatus;
                _Comp.InformationRating = ed.InformationRating;
                _CompTable.Add(_Comp);
            }

            _CoachingCenter.ComptetitorList = _CompTable;

            _CoachingCenter.PCCBriefDetails = Brief;
            _CoachingCenter.PCCTimelineDetails = Timeline;
            _CoachingCenter.PCCContactDetails = Contact;
            _CoachingCenter.PCCCourseLists = CourseList;
            _CoachingCenter.PCCGeneralDetails = General;
            _CoachingCenter.PCCSocialMediaDetails = SocialMedia;
            _CoachingCenter.PCCNews = News;
            _CoachingCenter.PCCTestimonialList = Testimonial;
            _CoachingCenter.PCCGalleryList = Gallery;

            return View(_CoachingCenter);
        }
        public ActionResult Course(String CourseId)
        {

           


            Course _Course = new Course();
            COURGeneral General = (from InstitutionData in _database.COURGenerals
                                   where (InstitutionData.CourseID.Contains(CourseId))
                                   select InstitutionData).FirstOrDefault();


            List<COUBatchAvailable> Batch = (from InstitutionData in _database.COUBatchAvailables
                                   where (InstitutionData.CourseID.Contains(CourseId))
                                   select InstitutionData).ToList();


            COUBasicDetail Basic = (from InstitutionData in _database.COUBasicDetails
                                   where (InstitutionData.CourseID.Contains(CourseId))
                                   select InstitutionData).FirstOrDefault();

            List<COUSubjectList> Subject = (from InstitutionData in _database.COUSubjectLists
                                where (InstitutionData.CourseID.Contains(CourseId))
                                select InstitutionData).ToList();


            COUStaffDetail Staff = (from InstitutionData in _database.COUStaffDetails
                                where (InstitutionData.CourseID.Contains(CourseId))
                                select InstitutionData).FirstOrDefault();

            List<COULab> Lab = (from InstitutionData in _database.COULabs
                                              where (InstitutionData.CourseID.Contains(CourseId))
                                              select InstitutionData).ToList();

            List<COUNew> News = (from InstitutionData in _database.COUNews
                                                      where (InstitutionData.CourseID.Contains(CourseId))
                                                      select InstitutionData).ToList();

            List<COUTestimonial> Testimonial = (from InstitutionData in _database.COUTestimonials
                                                where (InstitutionData.CourseID.Contains(CourseId))
                                                select InstitutionData).ToList();

            List<COUGallery> Gallery = (from InstitutionData in _database.COUGalleries
                                        where (InstitutionData.CourseID.Contains(CourseId))
                                        select InstitutionData).ToList();

            List<COUAchievement> Achievement = (from InstitutionData in _database.COUAchievements
                                        where (InstitutionData.CourseID.Contains(CourseId))
                                        select InstitutionData).ToList();


            _Course.COURGenerals = General;
            _Course.COUBatchAvailablesList = Batch;
            _Course.COUBasicDetails = Basic;
            _Course.COUSubjectLists = Subject;
            _Course.COUStaffDetails = Staff;
            _Course.COUNews = News;
            _Course.COULabList = Lab;
            _Course.COUTestimonialList = Testimonial;
            _Course.COUGalleryList = Gallery;
            _Course.COUAchievementList = Achievement;

            return View(_Course);
        }

        public ActionResult Registration()
        {
           
            return View();
        }
        public JsonResult SaveRegistration(String InstitutionName,String Location,String CourseOffered,String ContactName,String ContactNumber)
        {
           
            var SaveRegistrationQuery = "Insert into PInstitutionRegistration values("+"'"+InstitutionName+"',"+ "'" + Location + "',"+ "'" + CourseOffered + "',"+ "'" + ContactName + "',"+ "'" + ContactNumber + "'"+")";
            int SaveRegistration = _database.Database.ExecuteSqlCommand(SaveRegistrationQuery);

            return Json("True", JsonRequestBehavior.AllowGet);
        }
        public JsonResult MessageToInstitution(String InstitutionID, String UserName, String UserEmail, String UserPhone, String UserQuestion)
        {
             var MessageToInstitutionQuery = "Insert into PMessageToInstitution values(" + "'" + InstitutionID + "'," + "'" + UserName + "'," + "'" + UserEmail + "'," + "'" + UserPhone + "'," + "'" + UserQuestion + "'"+ ")";
            int MessageToInstitution = _database.Database.ExecuteSqlCommand(MessageToInstitutionQuery);

            return Json("True", JsonRequestBehavior.AllowGet);

           


        }
        public ActionResult POCMap()
        {
            MapDetails _Map = new MapDetails();

            Double[,] _MapArray= new Double[5, 2] { { 10.66, 33.66 }, { 10.22, 31.66 }, { 10.33, 33.66 }, { 10.44, 30.66 }, { 10.55, 30.66 } };

            MapData _Map1 = new MapData();
            _Map1.Latitude = 10.66;
            _Map1.Longitude = 56.66;
            _Map1.Detail = "Check1";

            MapData _Map2 = new MapData();
            _Map2.Latitude = 11.66;
            _Map2.Longitude = 52.66;
            _Map2.Detail = "Check2";

            MapData _Map3 = new MapData();
            _Map3.Latitude = 12.66;
            _Map3.Longitude = 50.66;
            _Map3.Detail = "Check3";

            MapData _Map4 = new MapData();
            _Map4.Latitude = 13.66;
            _Map4.Longitude = 54.66;
            _Map4.Detail = "Check4";

            List<MapData> _MappieList = new List<MapData>();

            _MappieList.Add(_Map1);
            _MappieList.Add(_Map2);
            _MappieList.Add(_Map3);
            _MappieList.Add(_Map4);

            Array Denew = _MappieList.ToArray();

            _Map.MapAr = _MapArray;
            _Map.MapList = _MappieList;
            return View(_Map);
        }

        public ActionResult News()
        {
            News _News = new Models.News();
            List<PNEW> NewsList = _News.ListOfNews("");

            _News.NewsList = NewsList;
            return View(_News);
        }
        public JsonResult GetNewsJSON(String Tags)
        {
            if (Tags == "" || Tags == null)
            {
                var Query = "SELECT  * FROM PNEWS order by Updateddate desc";
                var NewsVar = _database.PCityDetails.SqlQuery(Query).ToList();
                return Json(NewsVar, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var Query = "SELECT * FROM PNEWS where Tags like %" + Tags + "% order by updatedDate desc";
                var NewsVar = _database.PCityDetails.SqlQuery(Query).ToList();
                return Json(NewsVar, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Blog()
        {
            Blog _Blog = new Models.Blog();
            List<PBLOG> BlogList = _Blog.ListOfBlogData("");

            _Blog.BlogList = BlogList;
            return View(_Blog);
        }
        public JsonResult GetBlogJSON(String Tags)
        {
            if (Tags == "" || Tags == null)
            {
                var Query = "SELECT * FROM PBLOG order by updatedDate desc";
                var BlogVar = _database.PCityDetails.SqlQuery(Query).ToList();
                return Json(BlogVar, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var Query = "SELECT * FROM PBLOG where Tags like %" + Tags + "% order by updatedDate desc";
                var BlogVar = _database.PCityDetails.SqlQuery(Query).ToList();
                return Json(BlogVar, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Events()
        {
            return View();
        }

        

        public ActionResult Social()
        {
            return View();
        }

        public ActionResult Calender()
        {
            Calender _Calender = new Models.Calender();
            List<PCALENDER> CalenderList = _Calender.ListOfCalenderData("");

            _Calender.CalenderList = CalenderList;
            return View(_Calender);
        }
        public JsonResult GetCalenderJSON(String Tags)
        {
            if (Tags == "" || Tags == null)
            {
                var Query = "SELECT * FROM PCalender order by updatedDate desc";
                var CalenderVar = _database.PCityDetails.SqlQuery(Query).ToList();
                return Json(CalenderVar, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var Query = "SELECT * FROM PCalender where Tags like %" + Tags + "% order by updatedDate desc";
                var CalenderVar = _database.PCityDetails.SqlQuery(Query).ToList();
                return Json(CalenderVar, JsonRequestBehavior.AllowGet);
            }
        }

        
    }
}