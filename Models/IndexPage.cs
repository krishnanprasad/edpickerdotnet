using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdPicker.Models
{
    public class IndexPage
    {
        public List<SearchTable> TrendingList { get; set; }
        public String Location { get; set; }
        public List<PNEW> NewsListForIndexPage { get; set; }
        public List<PCALENDER> CalenderListForIndexPage { get; set; }
        public List<PBLOG> BlogListForIndexPage { get; set; }
    }
}