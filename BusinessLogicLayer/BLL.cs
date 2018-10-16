using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessObjects;
using System.Data;

namespace BusinessLogicLayer
{
    public class BLL
    {
        public BLL()
        {

        }

        public int SignUpBLL(Users objUser, string usrPassword)
        {
            int output;

            // Salt and Password
            string signUpSalt = CreateSalt(25);
            string signUpHash = GenerateSHA256Hash(usrPassword, signUpSalt);
            objUser.Salt = signUpSalt;
            objUser.Hash = signUpHash;

            DAL objDAL = new DAL();
            output = objDAL.SignUpDAL(objUser);

            return output;

        }

        public int BookingBLL(Booking objUserBooking)
        {
            int output;
            DAL objDal = new DAL();
            output = objDal.BookingDAL(objUserBooking);
            return output;
        }

      

        public int UpdateUserBLL(Users objUpdateUser)
        {
            int output;
            DAL objDal = new DAL();
            output = objDal.UpdateUserDAL(objUpdateUser);
            return output;
        }

        public Users SignInBLL(Users objUsers, string usrPassword)
        {
            Users objUser = null;
            Users objLookupUser = new Users();

            // Retrieve user record based on email 
            DAL objDAL = new DAL();
            objLookupUser = objDAL.SignInDAL(objUsers);

            // Check userPassword and Salt
            if (objLookupUser != null)
            {
                string signInSalt = objLookupUser.Salt;
                string signInHash = objLookupUser.Hash;
                string calHash = GenerateSHA256Hash(usrPassword, signInSalt);

                if (calHash == signInHash) objUser = objLookupUser;
            }

            return objUser;

        }

        public DataSet GetUsersDataBLL(string search)
        {
            DataSet dsUsersData = new DataSet();
            DAL objDal = new DAL();

            dsUsersData = objDal.GetUsersDataDAL(search);// call GetDonationsDataDAL method of DAL

            return dsUsersData;
        }

   

        public DataSet GetBookingDataBLL(string txtSearch)
        {
            DataSet dsBookingData = new DataSet();
            DAL objDal = new DAL();

            dsBookingData = objDal.GetBookingDataDAL(txtSearch);// call GetDonationsDataDAL method of DAL

            return dsBookingData;
        }

        public int UpdateBookingBLL(string name, string email, int conNo, string status, string date, int id)
        {
            int output;
            DAL objDal = new DAL();
            output = objDal.UpdateBookingDAL(name, email, conNo, status, date, id);
            return output;
        }

        public int DeleteBookingBLL(int id)
        {
            int output;
            DAL objDal = new DAL();
            output = objDal.DeleteBookingDAL(id);
            return output;
        }

      

        public String CreateSalt(int size)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public String GenerateSHA256Hash(String input, String salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed sha256hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);

            return ByteArrayToHexString(hash);
        }

        public String ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public int FeedbackBLL(Feedback objUserFeedback)
        {
            int output;
            DAL objDal = new DAL();
            output = objDal.FeedbackDAL(objUserFeedback);
            return output;
        }

        public DataSet GetFeedbackDataBLL()
        {
            DataSet dsFeedbackData = new DataSet();
            DAL objDal = new DAL();

            dsFeedbackData = objDal.GetFeedbackDataDAL();// call GetDonationsDataDAL method of DAL

            return dsFeedbackData;
        }

        public DataTable GetOverallDataBLL()
        {
            DataTable dtOverallData = new DataTable();
            DAL objDal = new DAL();

            dtOverallData = objDal.GetOverallDataDAL();

            return dtOverallData;
        }

        public DataTable GetBookingCountDataBLL()
        {
            DataTable dtBookingData = new DataTable();
            DAL objDal = new DAL();

            dtBookingData = objDal.GetBookingCountDataDAL();

            return dtBookingData;
        }



    }


}
