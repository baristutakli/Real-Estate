using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsoleApp1.ModelBase;

namespace ConsoleApp1.Models
{
    public class Commercial:Residential
    {
        public BuildingType BuildingType { get; set; }
    }
}