using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.ViewModel
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int City { get; set; }
        public string Country { get; set; }
        public int PostCode { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public System.DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }

        public virtual City City1 { get; set; }
    }
}