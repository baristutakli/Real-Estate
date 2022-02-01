using WebApp.ModelBase;
using WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Common;

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
            object insertedsId = DBTools.Connection.CreateResidential(StoreProcedureNames.CreateResidential, Convert.ToInt16(residential.SellType), residential.Square, residential.Age, residential.FloorNumber, Convert.ToInt16(residential.Heating), residential.Balcony, residential.Furnished, residential.AddressId, Convert.ToInt16(residential.ResidentialType));
            return insertedsId;
        }



        public List<Residential> GetResidential()
        {
            return DBTools.Connection.ReadResidentials(StoreProcedureNames.SelectAllResidentials);
        }
        public Residential GetResidentialById(int id)
        {
           
            return DBTools.Connection.ReadResidentialById(StoreProcedureNames.SelectResidentialById,id)[0];
        }
       
        public bool Update(Residential residential)
        {

            return DBTools.Connection.UpdateResidential(StoreProcedureNames.UpdateResidential,residential.RealEstateId, Convert.ToInt16(residential.SellType), residential.Square, residential.Age, residential.FloorNumber, Convert.ToInt16(residential.Heating), residential.Balcony, residential.Furnished, residential.AddressId, Convert.ToInt16(residential.ResidentialType));
        }
        public bool Delete(int id)
        {
            
            return  DBTools.Connection.DeleteResidential(StoreProcedureNames.DeleteResidentialById,id);
        }




    }
}