using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdPicker.Models
{
    public class News
    {
        public List<PNEW> NewsList { get; set; }
        public List<PNEW> ListOfNews(String Search)
        {
            EdPicker.Edlooker_DevEntities1 _database = new EdPicker.Edlooker_DevEntities1();
            DateTime now = DateTime.Now;
            String timeStamp = now.ToString();

           

            var SearchTerm = Search;
            var Query = "";
            if (SearchTerm == null || SearchTerm == "")
            {
               Query = "SELECT * FROM PNews";
            }
            else {
               Query = "SELECT * FROM PNews where Tags like '%" + SearchTerm + "%'";
            }
            
            List<PNEW> NewsList = _database.PNEWS.SqlQuery(Query).ToList();

            return NewsList;
        }
    }
}