using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.ModelBase;

namespace WebApp.Models
{
    public class AdvertCommercial : IAdvert
    {
        public int AdvertiseId { get ; set ; }
        public DateTime PublishDate { get ; set ; }
        public bool IsActive { get ; set ; }
        public string Title { get ; set ; }
        public string Explaination { get ; set ; }
        public User User { get ; set ; }
        public Commercial RealEstate { get; set; }
    }
}