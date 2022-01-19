using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1.ModelBase
{

    public interface IRealEstate
    {
        int RealEstateId { get; set; }
        SellType SellType { get; set; }
        double Square { get; set; }
        Address Address { get; set; }
    }
}
