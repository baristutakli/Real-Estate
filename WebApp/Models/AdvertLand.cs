using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.ModelBase;

namespace WebApp.Models
{
    public class AdvertLand : IAdvert
    {
        public int AdverticeId { get ; set ; }
        public DateTime PublishDate { get ; set ; }
        public bool IsActive { get ; set ; }
        public string Title { get ; set ; }
        public string Explaination { get ; set ; }
        public User User { get ; set ; }
        public Land RealEstate { get; set; }
    }
}