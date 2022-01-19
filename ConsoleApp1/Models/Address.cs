using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleApp1.Models
{
    public class Address
    {
        public  int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string Description { get; set; }
    }
}