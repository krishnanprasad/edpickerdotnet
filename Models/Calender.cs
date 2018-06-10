using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdPicker.Models
{
    public class Calender
    {
        public List<PCALENDER> CalenderList { get; set; }
        public List<PCALENDER> ListOfCalenderData(String Search)
        {
            EdPicker.Edlooker_DevEntities1 _database = new EdPicker.Edlooker_DevEntities1();
            DateTime now = DateTime.Now;
            String timeStamp = now.ToString();



            var SearchTerm = Search;
            var Query = "";
            if (SearchTerm == null || SearchTerm == "")
            {
                Query = "SELECT * FROM PCalender";
            }
            else
            {
                Query = "SELECT * FROM PCalender where Tags like '%" + SearchTerm + "%'";
            }

            List<PCALENDER> CalenderList = _database.PCALENDERs.SqlQuery(Query).ToList();

            return CalenderList;
        }
    }
}