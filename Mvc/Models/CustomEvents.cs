using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models
{
    public class CustomEvents
    {
        public string Title{ get; set; }
        public string Description{ get; set; }
        public DateTime EventStart { get; set; }
        public DateTime? EventEnd { get; set; }
        public string Category { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
             
    }
}