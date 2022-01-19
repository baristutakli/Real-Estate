using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilPicUrl { get; set; }
       // public HttpPostedFileBase ProfilePic { get; set; }
        public Address Address { get; set; }
    }
}