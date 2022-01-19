using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            //int insertedId =Convert.ToInt32( _residentialDal.Create(advertResidential.RealEstate));
            Console.WriteLine("-----------------------------------");
            string query = $"insert into Adverts (PublishDate,IsActive,Title,Explanation,UserId, ResidentialId,AdvertType) VALUES " +
                $"('{advertResidential.PublishDate}','{advertResidential.IsActive}','{advertResidential.Title}','{advertResidential.Explaination}','{1}','{5}','{1}')" +
                $";select CAST(scope_identity() as int);";
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(query);
            object insertedsId = DbTools.Connection.Create(query);
            return insertedsId;
        }

        public List<AdvertResidential> GetAdvertResidential()
        {
            string query = $"select * from Adverts where AdvertType={1}";

            return DbTools.Connection.ReadAdvertResidentials(query);
        }
        public AdvertResidential GetResidentialById(int id)
        {
            string query = $"select * from Adverts where Id ={id};";
            return DbTools.Connection.ReadAdvertResidentials(query)[0];
        }
        public bool Update(AdvertResidential advertResidential)
        {
            int insertedId = Convert.ToInt32(_residentialDal.Update(advertResidential.RealEstate));

            string query = $"Update Adverts set PublishDate='{advertResidential.PublishDate}',IsActive='{advertResidential.IsActive}',Title='{advertResidential.Title}',Explanation='{advertResidential.Explaination}',UserId='{advertResidential.User.Id}', ResidentialId='{ insertedId}',AdvertType='{1}') where Id={advertResidential.AdvertiseId}" +
                
                $";select CAST(scope_identity() as int);";

            return DbTools.Connection.Execute(query);
        }
        public bool Delete(AdvertResidential advertResidential)
        {
            
            _residentialDal.Delete(advertResidential.RealEstate);
            string query = $"Delete from Adverts where Id ={advertResidential.AdvertiseId};";
            return DbTools.Connection.Execute(query);
        }



    }
}
