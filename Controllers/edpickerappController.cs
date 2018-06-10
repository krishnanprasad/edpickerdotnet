using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EdPicker.Controllers
{
    public class edpickerappController : Controller
    {
        // GET: edpickerapp
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult InstitutionRegistration()
        {
            return View();
        }

        public ActionResult Searchbg()
        {
            
            return View();
        }
        public ActionResult eventsbg()
        {
            return View();
        }
        public ActionResult Newsbg()
        {
            //Add News
            
            return View();
        }
        public ActionResult Blogbg()
        {
            return View();
        }
        public ActionResult Calenderbg()
        {
            return View();
        }
        public String InsertNewsbg(String Headings,String URL,String Description,String Tags,String FrmSrc,String ImgSrc)
        {
            using (var context = new Edlooker_DevEntities1())
            {
                try
                {
                    PNEW _NewNews = new PNEW();
                    _NewNews.Heading = Headings;
                    _NewNews.URL = URL;
                    _NewNews.Description = Description;
                    _NewNews.Tags = Tags;
                    _NewNews.FromSource = FrmSrc;
                    _NewNews.ImageSrc = ImgSrc;
                    _NewNews.UpdatedDate = DateTime.Now;
                    _NewNews.TotalView =0;
                    context.PNEWS.Add(_NewNews);
                    context.SaveChanges();
                    return "Success";
                }
                catch (DbEntityValidationException e)
                {
                    //Create empty list to capture Validation error(s)
                    var outputLines = new List<string>();

                    foreach (var eve in e.EntityValidationErrors)
                    {
                        outputLines.Add(
                            $"{DateTime.Now}: Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                        outputLines.AddRange(eve.ValidationErrors.Select(ve =>
                            $"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\""));
                    }
                    //Write to external file
                    string RE = outputLines.ToString();
                    return "Failed";
                }
            }            
        }
        public bool Insertblogbg(String Headings, String URL, String Description, String Tags, String FrmSrc, String ImgSrc)
        {
            using (var context = new Edlooker_DevEntities1())
            {
                try
                {
                    PBLOG _NewBlog = new PBLOG();
                    _NewBlog.Heading = Headings;
                    _NewBlog.URL = URL;
                    _NewBlog.Description = Description;
                    _NewBlog.Tags = Tags;
                    _NewBlog.FromSource = FrmSrc;
                    _NewBlog.ImageSource= ImgSrc;
                    _NewBlog.UpdatedDate = DateTime.Now;
                    context.PBLOGs.Add(_NewBlog);
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}