using WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.DataAccess
{
    public class LandDal
    {
        private static LandDal _Current { get; set; }
        public static LandDal Current
        {
            get
            {
                if (_Current == null)
                {
                    _Current = new LandDal();
                }
                return _Current;
            }
        }
        public object Create(Land land)
        {
            string query = $"Insert into Lands (RealEstateId,SellType,Square,AddressId,BlockNumber,ParcelNumber,SquarePrice,ZoningStatus) VALUES  ('{land.RealEstateId}','{land.SellType}','{land.Square}','{land.AddressId}','{land.BlockNumber}','{land.ParcelNumber}','{land.SquarePrice}','{land.ZoningStatus}');select CAST(scope_identity() as int);";
            object insertedsId = DbTools.Connection.Create(query);
            return insertedsId;
        }
        public List<Land> GetResidential()
        {
            string query = "select * from Lands";

            return DbTools.Connection.ReadLand(query);
        }
        public Land GetResidentialById(int id)
        {
            string query = $"select * from Lands where ID ={id};";
            return DbTools.Connection.ReadLand(query)[0];
        }
        public bool Update(Land land)
        {
            string query = $"Update Lands set RealEstateID='{land.RealEstateId}',SellType='{land.SellType}', Square='{land.Square}',AddressId='{land.AddressId}',BlockNumber='{land.BlockNumber}',ParcelNumber='{land.ParcelNumber}',SquarePrice='{land.SquarePrice}',ZoningStatus='{land.ZoningStatus}' where AddressID='{land.RealEstateId}';";
            return DbTools.Connection.Execute(query);
        }
        public bool Delete(Land land)
        {
            string query = $"Delete from Lands where Id ={land.RealEstateId};";
            return DbTools.Connection.Execute(query);
        }



    }
}


