using ConsoleApp1.DataAccess;
using ConsoleApp1.ModelBase;
using ConsoleApp1.Models;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

               // AdvertResidentialDal advertResidentialDal = new AdvertResidentialDal(new ResidentialDal());
            ResidentialDal residentialDal = new ResidentialDal();
            //foreach (var item in residentialDal.GetResidential())
            //{
            //    Console.WriteLine(item.Age);
            //}
            //residentialDal.Create(new Residential()
            //{
            //    SellType = ModelBase.SellType.ForRent,
            //    Age = 6,
            //    Balcony = true,
            //    FloorNumber = 6,
            //    Furnished = true,
            //    Heating = ModelBase.HeatingType.Gas,
            //    ResidentialType = ModelBase.ResidentialType.Flat,
            //    Square = 100,
            //    AddressId = 1
            //});

            //residentialDal.Update(new Residential()
            //{
            //    RealEstateId=1003,
            //    SellType = ModelBase.SellType.ForRent,
            //    Age = 6,
            //    Balcony = true,
            //    FloorNumber = 6,
            //    Furnished = true,
            //    Heating = ModelBase.HeatingType.Gas,
            //    ResidentialType = ModelBase.ResidentialType.Flat,
            //    Square = 100,
            //    AddressId = 1
            //});
            //residentialDal.Delete(2008);

            AdvertResidentialDal advertResidentialDal = new AdvertResidentialDal(residentialDal);

            advertResidentialDal.Delete(
                new AdvertResidential
                {
                    AdverticeId=1008,
                    PublishDate = DateTime.Now,
                    IsActive = true,
                    Title = "Merhaba",
                    Explaination = "OOOO kral ooooo",
                    UserId = 1,
                    RealEstate = new Residential
                    {
                        RealEstateId = 2014,
                        SellType = ModelBase.SellType.ForRent,
                        Age = 12,
                        Balcony = true,
                        FloorNumber = 10,
                        Furnished = true,
                        Heating = ModelBase.HeatingType.Gas,
                        ResidentialType = ModelBase.ResidentialType.Flat,
                        Square = 100,
                        AddressId = 1

                    },
                    AdvertType = AdvertType.Residential
                }

                ); 


            //advertResidentialDal.Create(new AdvertResidential
            //{
            //    PublishDate = DateTime.Now,
            //    IsActive = true,
            //    Title = "Merhaba",
            //    Explaination = "OOOO kral ooooo",
            //    UserId = 1,
            //    RealEstate = new Residential
            //    {
            //        SellType = ModelBase.SellType.ForRent,
            //        Age = 12,
            //        Balcony = true,
            //        FloorNumber = 10,
            //        Furnished = true,
            //        Heating = ModelBase.HeatingType.Gas,
            //        ResidentialType = ModelBase.ResidentialType.Flat,
            //        Square = 100,
            //        AddressId = 1

            //    },
            //    AdvertType = AdvertType.Residential
            //});
            
           // Console.WriteLine("---"+advertResidentialDal.GetResidentialById(1010).IsActive);

            //foreach (var item in advertResidentialDal.GetAdvertResidentials())
            //{
            //    Console.WriteLine("title"+item.Title+item.RealEstate.Heating+item.RealEstate.Square+"---"+item.RealEstate.SellType);
            //}

            // Console.WriteLine("++++" + Convert.ToInt16(SellType.ForRent));
            //foreach (var item in residentialDal.GetResidential())
            //{
            //    Console.WriteLine(item.Age);
            //}
            //Console.WriteLine("balcony "+residentialDal.GetResidentialById(5).Balcony);
        }
    }
}
