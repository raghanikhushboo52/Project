using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.ViewModel
{
    public class CityViewModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }

       
    }
}