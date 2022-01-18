using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.ModelBase;

namespace WebApp.Models
{
    public class Commercial:Residential
    {
        public BuildingType BuildingType { get; set; }
    }
}