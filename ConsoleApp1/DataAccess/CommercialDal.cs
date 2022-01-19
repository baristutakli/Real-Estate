using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleApp1.DataAccess
{
    public class CommercialDal
    {
        private static CommercialDal _Current { get; set; }
        public static CommercialDal Current
        {
            get
            {
                if (_Current == null)
                {
                    _Current = new CommercialDal();
                }
                return _Current;
            }
        }
        public object Create(Commercial commercial)
        {
            string query = $"Insert into Commercials (RealEstateId,ResidentalType,SellType,Square,Address,Age,FloorNumber,Heating,Balcony,Furnished,BuildingType) VALUES  ('{commercial.RealEstateId}'," +
                $"'{commercial.ResidentialType}','{commercial.SellType}','{commercial.Square}','{commercial.Address}','{commercial.Age}','{commercial.FloorNumber}'," +
                $"'{commercial.Heating}','{commercial.Balcony}','{commercial.Furnished}','{commercial.BuildingType}');select CAST(scope_identity() as int);";
            object insertedsId = DbTools.Connection.Create(query);
            return insertedsId;
        }
        //public List<Commercial> GetCommercial()
        //{
        //    string query = "select * from Commercials";

        //    return DbTools.Connection.ReadCommercials(query);
        //}
        public Commercial GetCommercialById(int id)
        {
            string query = $"select * from Commercials where ID ={id};";
            return DbTools.Connection.ReadCommercials(query)[0];
        }
        public bool Update(Commercial commercial)
        {
            string query = $"Update Commercials set RealEstateID='{commercial.RealEstateId}',SellType='{commercial.SellType}', Square='{commercial.Square}',Age='{commercial.RealEstateId}',FloorNumber='{commercial.FloorNumber}',Heating='{commercial.Heating}',Balcony='{commercial.Balcony}',Furnished='{commercial.Furnished}',ResidentialType='{commercial.ResidentialType}' where AddressID='{commercial.AddressId}';";
            return DbTools.Connection.Execute(query);
        }
        public bool Delete(Commercial commercial)
        {
            string query = $"Delete from Commercials where Id ={commercial.RealEstateId};";
            return DbTools.Connection.Execute(query);
        }



    }
}