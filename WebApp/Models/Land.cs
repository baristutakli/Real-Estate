using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.ModelBase;

namespace WebApp.Models
{
    public class Land:IRealEstate
    {
        public int RealEstateId { get ; set ; }
        public SellType SellType { get ; set ; }
        public double Square { get ; set ; }
        public Address Address { get ; set ; }
        public int AddressId { get; set; }
        public int BlockNumber { get; set; }
        public int ParcelNumber { get; set; }
        public double SquarePrice { get; set; }
        public ZoningStatus ZoningStatus { get; set; }
    }
}