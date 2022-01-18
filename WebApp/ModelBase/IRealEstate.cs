using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.ModelBase
{

    public interface IRealEstate
    {
        int RealEstateId { get; set; }
        SellType SellType { get; set; }
        double Square { get; set; }
        Address Address { get; set; }
    }
}
