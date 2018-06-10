using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using EdPicker.Models;
using Newtonsoft.Json;

namespace EdPicker.Controllers
{
    public class POCController : Controller
    {
        EdPicker.Edlooker_DevEntities1 _database = new EdPicker.Edlooker_DevEntities1();
        // GET: POC
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MapTrial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ImageUploader(TestUploadImage model,HttpPostedFileBase image1)
        {
            var db = new Edlooker_DevEntities1();
            
            if (image1 != null)
            {
                String ImageFileName = Path.GetFileName(image1.FileName);
                String FolderPath = Path.Combine(Server.MapPath("~/Images"), ImageFileName);
                image1.SaveAs(FolderPath);
                model.Name = image1.FileName;
                model.Size = image1.ContentLength;
                model.ImageData = new byte[image1.ContentLength];
                image1.InputStream.Read(model.ImageData, 0, image1.ContentLength);
                
                
            }
            db.TestUploadImages.Add(model);
            db.SaveChanges();
            return View();
        }
        public ActionResult ImageUploader()
        {
            TestUploadImage _Test = new TestUploadImage();

            return View(_Test);
        }
        public ActionResult LoadImages()
        {
            List<TestUploadImage> ImagesList = (from Images in _database.TestUploadImages
                                         select Images).ToList();
            List<POCImageLoad> _ListOfImages = new List<POCImageLoad>();
            POCImageLoadList _POCListOfImages = new POCImageLoadList();
            foreach (var gg in ImagesList)
            {
                POCImageLoad _NewImage = new POCImageLoad();
                _NewImage.ImageName = gg.Name;
                String StrBase64 = Convert.ToBase64String(gg.ImageData);
                _NewImage.ImageURL= "data:Image/png:base64," + StrBase64;
                _ListOfImages.Add(_NewImage);
            }
            //_POCListOfImages._ListOfImages = _ListOfImages;
            String _ListOfPhotosJSON = JsonConvert.SerializeObject(_ListOfImages);
            return View(_ListOfPhotosJSON);
        }
    }
}