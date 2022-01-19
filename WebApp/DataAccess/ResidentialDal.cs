using WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.DataAccess
{
    public class ResidentialDal
    {
        private static ResidentialDal _Current { get; set; }
        public static ResidentialDal Current
        {
            get
            {
                if (_Current == null)
                {
                    _Current = new ResidentialDal();
                }
                return _Current;
            }
        }
        public object Create(Residential residential)
        {
            
            string query = $"Insert into Residentials (ResidentalType,SellType,Square,Address,Age,FloorNumber,Heating,Balcony,Furnished) VALUES  (" +
                $"'{residential.ResidentialType}','{residential.SellType}','{residential.Square}','{residential.Address}','{residential.Age}','{residential.FloorNumber}'," +
                $"'{residential.Heating}','{residential.Balcony}','{residential.Furnished}');select CAST(scope_identity() as int);";
            object insertedsId = DbTools.Connection.Create(query);
            return insertedsId;
        }

        public List<Residential> GetResidential()
        {
            string query = "select * from Residentials";

            return DbTools.Connection.ReadResidentials(query);
        }
        public Residential GetResidentialById(int id)
        {
            string query = $"select * from Residentials where ID ={id};";
            return DbTools.Connection.ReadResidentials(query)[0];
        }
        public bool Update(Residential residential)
        {
            string query = $"Update Residentials set RealEstateID='{residential.RealEstateId}',SellType='{residential.SellType}', Square='{residential.Square}',Age='{residential.RealEstateId}',FloorNumber='{residential.FloorNumber}',Heating='{residential.Heating}',Balcony='{residential.Balcony}',Furnished='{residential.Furnished}',ResidentialType='{residential.ResidentialType}',AddressID='{residential.AddressId}', where AddressID='{residential.AddressId}';";
            return DbTools.Connection.Execute(query);
        }
        public bool Delete(Residential residential)
        {
            string query = $"Delete from Residentials where Id ={residential.RealEstateId};";
            return DbTools.Connection.Execute(query);
        }



    }
}