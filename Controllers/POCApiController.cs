using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace EdPicker.Controllers
{
    public class POCApiController : ApiController
    {
        EdPicker.Edlooker_DevEntities1 _database = new EdPicker.Edlooker_DevEntities1();
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet]
        public List<String> Ramkumar(int id)
        {
            List<String> _NewList = new List<string>();
            String sd = "0";
            String sd1 = "0";
            String sd2 = "0";
            String sd3 = "0";
            _NewList.Add(sd);
            _NewList.Add(sd1);
            _NewList.Add(sd2);
            _NewList.Add(sd3);
            return _NewList;
        }
        [HttpGet]
        public List<String> GetCustomerNames()
        {
            List<String> _NewList = new List<string>();
            String sd = "Sathish";
            String sd1 = "Kumar";
            String sd2 = "Ramesh";
            String sd3 = "Suresh";
            _NewList.Add(sd);
            _NewList.Add(sd1);
            _NewList.Add(sd2);
            _NewList.Add(sd3);
            return _NewList;
        }

        [HttpGet]
        public List<PSearchTable> GetSearchTableDetails()
        {
            _database.Configuration.LazyLoadingEnabled = false;
            List<PSearchTable> _returnSearchTable= _database.PSearchTables.Take(25).ToList();
            

            return _returnSearchTable;
        }
        public List<PSearchTable> GetSearchTableDetails1()
        {
            
            List<PSearchTable> _returnSearchTable = _database.PSearchTables.Take(25).ToList();


            return _returnSearchTable;
        }
        public IEnumerable<PSearchTable> GetSearchTableDetailsEnu()
        {
            _database.Configuration.LazyLoadingEnabled = false;
            IEnumerable<PSearchTable> _returnSearchTable = _database.PSearchTables.Take(25).Where(d=>d.InstitutionType==1).ToList();


            return _returnSearchTable;
        }
        public IQueryable<PSearchTable> GetSearchTableDetailsQue()
        {
            _database.Configuration.LazyLoadingEnabled = false;
            IQueryable<PSearchTable> _returnSearchTable = _database.PSearchTables.Take(25).ToList().Where(d => d.InstitutionType == 1).AsQueryable();


            return _returnSearchTable;
        }
    }
}
