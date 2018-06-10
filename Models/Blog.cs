using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdPicker.Models
{
    public class Blog
    {
        public List<PBLOG> BlogList { get; set; }
        public List<PBLOG> ListOfBlogData(String Search)
        {
            EdPicker.Edlooker_DevEntities1 _database = new EdPicker.Edlooker_DevEntities1();
            DateTime now = DateTime.Now;
            String timeStamp = now.ToString();



            var SearchTerm = Search;
            var Query = "";
            if (SearchTerm == null || SearchTerm == "")
            {
                Query = "SELECT * FROM PBLOG";
            }
            else
            {
                Query = "SELECT * FROM PBLOG where Tags like '%" + SearchTerm + "%'";
            }

            List<PBLOG> BlogList = _database.PBLOGs.SqlQuery(Query).ToList();

            return BlogList;
        }
    }
}