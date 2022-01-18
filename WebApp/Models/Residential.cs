using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.DataAccess;
using WebApp.ModelBase;

namespace WebApp.Models
{

  
    public class Residential : IRealEstate
    {
        public int RealEstateId { get; set; }
        public SellType SellType { get; set; }
        public double Square { get; set; }
        public Address Address { get; set; }
        public short Age { get; set; }
        public short FloorNumber { get; set; }
        public HeatingType Heating { get; set; }
        public bool Balcony { get; set; }
        public bool Furnished { get; set; }
        public ResidentialType ResidentialType { get; set; }
        public int AddressId { get; set; }


    }
}