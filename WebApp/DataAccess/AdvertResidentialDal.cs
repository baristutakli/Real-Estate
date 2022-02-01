using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Common;
using WebApp.Models;

namespace WebApp.DataAccess
{
    public class AdvertResidentialDal
    {
        private static AdvertResidentialDal _current { get; set; }
        public static AdvertResidentialDal Current
        {
            get
            {

                return _current;
            }
        }
        private ResidentialDal _residentialDal;

        public AdvertResidentialDal(ResidentialDal residentialDal)
        {
            _residentialDal = residentialDal;
        }
        public object Create(AdvertResidential advertResidential)
        {
            int insertedId = Convert.ToInt32(_residentialDal.Create(advertResidential.RealEstate));
            //.ToString("MM/dd/yyyy HH:MM")
            object Id = DBTools.Connection.CreateAdvert(StoreProcedureNames.CreateAdvertResidential, advertResidential.PublishDate, advertResidential.IsActive, advertResidential.Title, advertResidential.Explaination, 1, insertedId, 1);
            return Id;
        }



        public List<AdvertResidential> GetAdvertResidentials()
        {
            
            return DBTools.Connection.ReadAdverts(StoreProcedureNames.SelectAdverts);
        }
        public AdvertResidential GetResidentialById(int id)
        {
          return DBTools.Connection.ReadAdvertResidentailById(StoreProcedureNames.GetAdvertResidentialById,id)[0];
        }
        public bool Update(AdvertResidential advertResidential)
        {
            int insertedId = Convert.ToInt32(_residentialDal.Update(advertResidential.RealEstate));

            return DBTools.Connection.UpdateAdvert(StoreProcedureNames.UpdateAdvertById,advertResidential.AdverticeId, advertResidential.PublishDate, advertResidential.IsActive, advertResidential.Title, advertResidential.Explaination, advertResidential.UserId,advertResidential.ResidentalId,Convert.ToInt16( advertResidential.AdvertType));
        }
        public bool Delete(AdvertResidential advertResidential)
        {

            _residentialDal.Delete(advertResidential.RealEstate.RealEstateId);
            
            return DBTools.Connection.DeleteAdvert(StoreProcedureNames.DeleteAdvertById, advertResidential.AdverticeId);
        }



    }
}
