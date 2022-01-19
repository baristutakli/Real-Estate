using ConsoleApp1.ModelBase;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleApp1.DataAccess
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

            string query = $"INSERT INTO Residentials (SellType,Square, Age, FloorNumber,Heating,Balcony,Furnished,AddressId,ResidentialType) VALUES" +
                $"('{ Convert.ToInt16( residential.SellType)}','{residential.Square}','{residential.Age}','{residential.FloorNumber}','{Convert.ToInt16(residential.Heating)}','{residential.Balcony}','{residential.Furnished}','{residential.AddressId}','{Convert.ToInt16(residential.ResidentialType)}');select CAST(scope_identity() as int);";

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
            string query = $"select * from Residentials where ResidentialId ={id};";
            return DbTools.Connection.ReadResidentials(query)[0];
        }
       
        public bool Update(Residential residential)
        {
            string query = $"Update Residentials set SellType='{Convert.ToInt16(residential.SellType)}', Square='{residential.Square}',Age='{residential.Age}',FloorNumber='{residential.FloorNumber}',Heating='{Convert.ToInt16(residential.Heating)}',Balcony='{residential.Balcony}',Furnished='{residential.Furnished}',ResidentialType='{Convert.ToInt16(residential.ResidentialType)}',AddressId='{residential.AddressId}' where ResidentialId='{residential.RealEstateId}';";
            return DbTools.Connection.Execute(query);
        }
        public bool Delete(int id)
        {
            string query = $"Delete from Residentials where ResidentialId ={id};";
            return  DbTools.Connection.Execute(query);
        }



    }
}