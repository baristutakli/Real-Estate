using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.ModelBase;
using WebApp.Models;

namespace WebApp.ModelBase
{
    public interface IAdvert
    {
        int AdverticeId { get; set; }
        DateTime PublishDate { get; set; }
        bool IsActive { get; set; }
        string Title { get; set; }
        string Explaination { get; set; }

        User User { get; set; }


    }
}
