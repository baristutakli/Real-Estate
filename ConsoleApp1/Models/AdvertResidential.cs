using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsoleApp1.DataAccess;
using ConsoleApp1.ModelBase;

namespace ConsoleApp1.Models
{
    
    public class AdvertResidential : IAdvert
    {
        public int AdverticeId { get; set; }
       
        public DateTime PublishDate { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public string Explaination { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Residential RealEstate { get; set; }
        public int ResidentalId { get; set; }
        public AdvertType AdvertType { get; set; }
    }
}