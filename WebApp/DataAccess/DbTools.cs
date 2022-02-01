using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApp.ModelBase;
using WebApp.Models;

namespace WebApp.DataAccess
{
    public class DBTools
    {

        static string strConnection = @"Server=(localdb)\MSSQLLocalDB; Database=Db_Emlak;Trusted_Connection=true;";
        public SqlConnection con = new SqlConnection(strConnection);

        public ResidentialDal residentialDal { get { return new ResidentialDal(); } set { residentialDal = value; } }


        private static DBTools _Con { get; set; }
        public static DBTools Connection
        {
            get
            {
                if (_Con == null)

                    _Con = new DBTools();
                return _Con;
            }
        }
        public bool ConnectDB()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DisconnectDB()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // **************************** Residential Sorguları**********************
        public List<Residential> ReadResidentials(string query)
        {
            List<Residential> residentials = new List<Residential>();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader;
            try
            {
                ConnectDB();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    residentials.Add(
                        new Residential
                        {
                            RealEstateId = int.Parse(reader["ResidentialId"].ToString()),
                            SellType = (SellType)short.Parse(reader["SellType"].ToString()),
                            Square = double.Parse(reader["Square"].ToString()),
                            Age = short.Parse(reader["Age"].ToString()),
                            FloorNumber = byte.Parse(reader["FloorNumber"].ToString()),
                            Heating = (HeatingType)short.Parse(reader["Heating"].ToString()),
                            Balcony = bool.Parse(reader["Balcony"].ToString()),
                            Furnished = bool.Parse(reader["Furnished"].ToString()),
                            AddressId = int.Parse(reader["AddressId"].ToString()),
                            ResidentialType = (ResidentialType)short.Parse(reader["ResidentialType"].ToString()),
                        }
                        );
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                DisconnectDB();
            }
            return residentials;
        }
        public List<Residential> ReadResidentialById(string query, int id)
        {
            List<Residential> residentials = new List<Residential>();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader;
            try
            {
                ConnectDB();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    residentials.Add(
                        new Residential
                        {
                            RealEstateId = int.Parse(reader["ResidentialId"].ToString()),
                            SellType = (SellType)short.Parse(reader["SellType"].ToString()),
                            Square = double.Parse(reader["Square"].ToString()),
                            Age = short.Parse(reader["Age"].ToString()),
                            FloorNumber = byte.Parse(reader["FloorNumber"].ToString()),
                            Heating = (HeatingType)short.Parse(reader["Heating"].ToString()),
                            Balcony = bool.Parse(reader["Balcony"].ToString()),
                            Furnished = bool.Parse(reader["Furnished"].ToString()),
                            AddressId = int.Parse(reader["AddressId"].ToString()),
                            ResidentialType = (ResidentialType)short.Parse(reader["ResidentialType"].ToString()),
                        }
                        );
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                DisconnectDB();
            }
            return residentials;
        }
        public object CreateResidential(string query, short selltype, double area, short age, short floorNumber, short heating, bool balcony, bool furnished, int addressId, short residentialType)
        {
            SqlCommand cmd;
            object insertedID = -1;
            try
            {
                cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@Selltype", SqlDbType.SmallInt).Value = selltype;
                cmd.Parameters.Add("@Area", SqlDbType.Float).Value = area;
                cmd.Parameters.Add("@Age", SqlDbType.SmallInt).Value = age;
                cmd.Parameters.Add("@FloorNumber", SqlDbType.SmallInt).Value = floorNumber;
                cmd.Parameters.Add("@Heating", SqlDbType.SmallInt).Value = heating;
                cmd.Parameters.Add("@Balcony", SqlDbType.Bit).Value = balcony;
                cmd.Parameters.Add("@Furnished", SqlDbType.Bit).Value = furnished;
                cmd.Parameters.Add("@AddressId", SqlDbType.Int).Value = addressId;
                cmd.Parameters.Add("@ResidentialType", SqlDbType.SmallInt).Value = residentialType;
                cmd.CommandType = CommandType.StoredProcedure;
                ConnectDB();
                insertedID = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("HATA LOGU Yaz." + ex);
            }
            finally
            {
                DisconnectDB();
            }
            return insertedID;

        }

        public bool UpdateResidential(string query,int Id, short selltype, double area, short age, short floorNumber, short heating, bool balcony, bool furnished, int addressId, short residentialType)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            int affectedRows = -1;
            try
            {
                cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@ResidentialId", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@Selltype", SqlDbType.SmallInt).Value = selltype;
                cmd.Parameters.Add("@Area", SqlDbType.Float).Value = area;
                cmd.Parameters.Add("@Age", SqlDbType.SmallInt).Value = age;
                cmd.Parameters.Add("@FloorNumber", SqlDbType.SmallInt).Value = floorNumber;
                cmd.Parameters.Add("@Heating", SqlDbType.SmallInt).Value = heating;
                cmd.Parameters.Add("@Balcony", SqlDbType.Bit).Value = balcony;
                cmd.Parameters.Add("@Furnished", SqlDbType.Bit).Value = furnished;
                cmd.Parameters.Add("@AddressId", SqlDbType.Int).Value = addressId;
                cmd.Parameters.Add("@ResidentialType", SqlDbType.SmallInt).Value = residentialType;
                cmd.CommandType = CommandType.StoredProcedure;
                ConnectDB();
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                DisconnectDB();
            }
            if (affectedRows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteResidential(string query,int Id)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            int affectedRows = -1;
            try
            {
                cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@ResidentialId", SqlDbType.Int).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                ConnectDB();
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                DisconnectDB();
            }
            if (affectedRows > 0)
                return true;
            else
                return false;
        }

        // ********************************** Advert Residential Sorguları***************************

        public List<AdvertResidential> ReadAdverts(string query)
        {

            List<AdvertResidential> advertResidentials = new List<AdvertResidential>();
            SqlCommand cmd = new SqlCommand(query, con);
            IDataReader reader;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                ConnectDB();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    advertResidentials.Add(

                        new AdvertResidential
                        {
                            AdverticeId = int.Parse(reader["AdverticeId"].ToString()),
                            PublishDate = DateTime.Parse(reader["PublishDate"].ToString()),
                            IsActive = bool.Parse(reader["IsActive"].ToString()),
                            Title = reader["Title"].ToString(),
                            Explaination = reader["Explanation"].ToString(),
                            UserId = int.Parse(reader["UserId"].ToString()),
                            RealEstate = new Residential
                            {
                                RealEstateId = int.Parse(reader["ResidentialId"].ToString()),
                                SellType = (SellType)Convert.ToInt16(reader["SellType"].ToString()),
                                Square = Convert.ToDouble(reader["Area"].ToString()),
                                Age = Convert.ToInt16(reader["Age"].ToString()),
                                FloorNumber = Convert.ToInt16(reader["FloorNumber"].ToString()),
                                Heating = (HeatingType)Convert.ToInt16(reader["Heating"].ToString()),
                                Balcony = bool.Parse(reader["Balcony"].ToString()),
                                Furnished = bool.Parse(reader["Furnished"].ToString()),
                                AddressId = int.Parse(reader["AddressId"].ToString()),
                                ResidentialType = (ResidentialType)Convert.ToInt16(reader["ResidentialType"].ToString())
                            },

                            ResidentalId = int.Parse(reader["ResidentialId"].ToString()),
                            AdvertType = (AdvertType)short.Parse(reader["AdvertType"].ToString()),

                        }

                        );
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                DisconnectDB();
            }
            return advertResidentials;
        }
        public List<AdvertResidential> ReadAdvertResidentailById(string query,int Id)
        {

            List<AdvertResidential> advertResidentials = new List<AdvertResidential>();
            SqlCommand cmd = new SqlCommand(query, con);
            IDataReader reader;
            try
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                ConnectDB();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    advertResidentials.Add(

                        new AdvertResidential
                        {
                            AdverticeId = int.Parse(reader["AdverticeId"].ToString()),
                            PublishDate = DateTime.Parse(reader["PublishDate"].ToString()),
                            IsActive = bool.Parse(reader["IsActive"].ToString()),
                            Title = reader["Title"].ToString(),
                            Explaination = reader["Explanation"].ToString(),
                            UserId = int.Parse(reader["UserId"].ToString()),
                            RealEstate = new Residential
                            {
                                RealEstateId = int.Parse(reader["ResidentialId"].ToString()),
                                SellType = (SellType)Convert.ToInt16(reader["SellType"].ToString()),
                                Square = Convert.ToDouble(reader["Area"].ToString()),
                                Age = Convert.ToInt16(reader["Age"].ToString()),
                                FloorNumber = Convert.ToInt16(reader["FloorNumber"].ToString()),
                                Heating = (HeatingType)Convert.ToInt16(reader["Heating"].ToString()),
                                Balcony = bool.Parse(reader["Balcony"].ToString()),
                                Furnished = bool.Parse(reader["Furnished"].ToString()),
                                AddressId = int.Parse(reader["AddressId"].ToString()),
                                ResidentialType = (ResidentialType)Convert.ToInt16(reader["ResidentialType"].ToString())
                            },

                            ResidentalId = int.Parse(reader["ResidentialId"].ToString()),
                            AdvertType = (AdvertType)short.Parse(reader["AdvertType"].ToString()),

                        }

                        );
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                DisconnectDB();
            }
            return advertResidentials;
        }

        public object CreateAdvert(string query,DateTime publishDate,bool isActive,string title,string explanation,int userId,int residentialId,short advertType)
        {
            SqlCommand cmd;
            object insertedID = -1;
            try
            {
                cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@PublishDate", SqlDbType.DateTime).Value = publishDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
                cmd.Parameters.Add("@Explanation", SqlDbType.NVarChar).Value = explanation;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                cmd.Parameters.Add("@ResidentialId", SqlDbType.Int).Value = residentialId;
                cmd.Parameters.Add("@AdvertType", SqlDbType.SmallInt).Value = advertType;
          
                cmd.CommandType = CommandType.StoredProcedure;
                ConnectDB();
                insertedID = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("HATA LOGU Yaz." + ex);
            }
            finally
            {
                DisconnectDB();
            }
            return insertedID;

        }

        public bool UpdateAdvert(string query, int Id, DateTime publishDate, bool isActive, string title, string explanation, int userId, int residentialId, short advertType)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            int affectedRows = -1;
            try
            {
                cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("AdverticeId", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@PublishDate", SqlDbType.DateTime).Value = publishDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
                cmd.Parameters.Add("@Explanation", SqlDbType.NVarChar).Value = explanation;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                cmd.Parameters.Add("@ResidentialId", SqlDbType.Int).Value = residentialId;
                cmd.Parameters.Add("@AdvertType", SqlDbType.SmallInt).Value = advertType;

                cmd.CommandType = CommandType.StoredProcedure;
                ConnectDB();
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                DisconnectDB();
            }
            if (affectedRows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteAdvert(string query, int Id)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            int affectedRows = -1;
            try
            {
                cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@AdverticeId", SqlDbType.Int).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                ConnectDB();
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                DisconnectDB();
            }
            if (affectedRows > 0)
                return true;
            else
                return false;
        }
    }
}