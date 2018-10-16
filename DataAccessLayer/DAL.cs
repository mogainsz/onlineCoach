using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DAL
    {
        public string ConnectionString = string.Empty;

        public DAL()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["OCDB"].ConnectionString;
        }


        public int SignUpDAL(Users objUser)
        {
           
            int output = 0;
            
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = string.Format(@"INSERT INTO
		[Users] (Firstname, LastName, EmailAddress, Salt, Hash) VALUES
		('{0}','{1}','{2}','{3}', '{4}')",
            objUser.FirstName,
      objUser.LastName, objUser.EmailAddress, objUser.Salt, objUser.Hash
      );

           
            SqlCommand command = new SqlCommand(sql, connection);
           
            try
            {
                connection.Open();
                // ExecuteNonQuery() is Used to execute the insert command. 
                // This inserts the data into the DB.
                output = command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
               
                connection.Close();
            }
            return output;
        }

        public string GetColumnValue(SqlDataReader dr, string columnName)
        {
            string columnValue = string.Empty;
            if (dr[columnName] != null && dr[columnName] != DBNull.Value)
            {
                columnValue = dr[columnName].ToString();
            }
            return columnValue;
        }

        public Users SignInDAL(Users objUsers)
        {
            Users objUser = null; /*new UserMaster();*/
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = string.Format(@"SELECT TOP 1 * FROM [Users] WHERE EmailAddress='{0}'",
                     objUsers.EmailAddress);
            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                // Used to execute the query to validate the entered details (email and password) and returns a corresponding row if user is valid and present in DB.
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    objUser = new Users();
                    if (dr.Read())
                    {
                        // Calling GetColumnValue method to handle null values and retrieve the data from dr object and assign it to objUser variables without exceptions.
                        objUser.UserId = Convert.ToInt32(GetColumnValue(dr, "UserId"));
                        objUser.FirstName = GetColumnValue(dr, "FirstName");
                        objUser.LastName = GetColumnValue(dr, "LastName");
                        objUser.EmailAddress = GetColumnValue(dr, "EmailAddress");
                        objUser.Salt = GetColumnValue(dr, "Salt");
                        objUser.Hash = GetColumnValue(dr, "Hash");
                        objUser.Weight = Convert.ToDouble(GetColumnValue(dr, "Weight"));
                        objUser.Height = Convert.ToDouble(GetColumnValue(dr, "Height"));
                        objUser.Birthday = GetColumnValue(dr, "Birthday");
                        objUser.ActivityLevel = GetColumnValue(dr, "ActivityLevel");
                        objUser.BMI = Convert.ToDouble(GetColumnValue(dr, "BMI"));
                        objUser.About = GetColumnValue(dr, "About");
                        objUser.GoalWeight = Convert.ToDouble(GetColumnValue(dr, "GoalWeight"));
                        objUser.Gender = GetColumnValue(dr, "Gender");
                        objUser.Role = GetColumnValue(dr, "Role");

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return objUser;
        }


        public int BookingDAL(Booking objUserBook)
        {
            int output = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = string.Format(@"INSERT INTO
		[Booking] (Name, EmailAddress, ContactNo,LectDate ) VALUES
		('{0}','{1}','{2}','{3}')",
            objUserBook.Name,
      objUserBook.EmailAddress, objUserBook.ContactNo, objUserBook.LectDate
      );
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                // ExecuteNonQuery() is Used to execute the insert command. 
                // This inserts the data into the DB.
                output = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return output;
        }



        public int UpdateUserDAL(Users objUpdateUser)
        {

            int output = 0;
           
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = $@"UPDATE [Users]
		SET FirstName='{objUpdateUser.FirstName}', LastName='{objUpdateUser.LastName}', EmailAddress='{objUpdateUser.EmailAddress}', Weight='{objUpdateUser.Weight}', Height='{objUpdateUser.Height}', Birthday='{objUpdateUser.Birthday}', ActivityLevel='{objUpdateUser.ActivityLevel}', BMI='{objUpdateUser.BMI}', About='{objUpdateUser.About.Replace("'","''")}', GoalWeight='{objUpdateUser.GoalWeight}', Gender='{objUpdateUser.Gender}'  WHERE UserId= '{objUpdateUser.UserId}'";


            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                // ExecuteNonQuery() is Used to execute the insert command. 
                // This inserts the data into the DB.
                output = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                connection.Close();
            }
            return output;
        }

        public DataSet GetUsersDataDAL(string search)
        {
            DataSet dsUsersData = new DataSet();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string cmd = "Select * from [Users] where Role = 'User' and LastName like '%' + @lName + '%'";
            SqlCommand command = new SqlCommand(cmd, connection);
            command.Parameters.AddWithValue("@lName", search);
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);// Used to execute the select command.
                adapter.Fill(dsUsersData);// Fill the dataset dsDonationsData from the sql adapter.
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return dsUsersData; // return the entire dataset.


        }

    

        public DataSet GetBookingDataDAL(string txtSearch)
        {
            DataSet dsBookingData = new DataSet();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string cmd = "Select * from [Booking] where Name like '%' + @orgName + '%' order by DatePlaced";
             
            SqlCommand command = new SqlCommand(cmd, connection);

            command.Parameters.AddWithValue("@orgName", txtSearch);
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);// Used to execute the select command.
                adapter.Fill(dsBookingData);// Fill the dataset dsDonationsData from the sql adapter.
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return dsBookingData; // return the entire dataset.


        }

        public int UpdateBookingDAL(string name, string email, int conNo, string status, string date, int id)
        {

            int output = 0;

            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = $@"UPDATE [Booking]
		SET Name='{name}', EmailAddress='{email}', ContactNo='{conNo}' ,Status='{status}', LectDate='{date}' WHERE BookingId= '{id}'";


            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                // ExecuteNonQuery() is Used to execute the insert command. 
                // This inserts the data into the DB.
                output = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                connection.Close();
            }
            return output;
        }

        public int DeleteBookingDAL(int id)
        {

            int output = 0;

            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = $@"DELETE FROM [Booking]
		 WHERE BookingId= '{id}'";


            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                // ExecuteNonQuery() is Used to execute the insert command. 
                // This inserts the data into the DB.
                output = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                connection.Close();
            }
            return output;
        }

        public int FeedbackDAL(Feedback objUserFeedback)
        {
            int output = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = string.Format(@"INSERT INTO
		[FeedBack] (FullName, EmailAddress, Comment, Overall) VALUES
		('{0}','{1}','{2}','{3}')",
            objUserFeedback.FullName,
      objUserFeedback.EmailAddress, objUserFeedback.Comment.Replace("'", "''"),
      objUserFeedback.Overall);
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                // ExecuteNonQuery() is Used to execute the insert command. 
                // This inserts the data into the DB.
                output = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return output;
        }


        public DataSet GetFeedbackDataDAL()
        {
            DataSet dsFeedbackData = new DataSet();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string cmd = "Select * from [Feedback] order by DateSent desc";
            SqlCommand command = new SqlCommand(cmd, connection);

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);// Used to execute the select command.
                adapter.Fill(dsFeedbackData);// Fill the dataset dsDonationsData from the sql adapter.
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return dsFeedbackData; // return the entire dataset.


        }

        public DataTable GetOverallDataDAL()
        {
            DataTable dtOverallData = new DataTable();
           
            SqlConnection connection = new SqlConnection(ConnectionString);
            string cmd = "Select Overall, count(Overall) from [Feedback] GROUP BY Overall";
            SqlCommand command = new SqlCommand(cmd, connection);

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dtOverallData);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return dtOverallData; 


        }

        public DataTable GetBookingCountDataDAL()
        {
            DataTable dtOverallData = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString);
            string cmd = "Select Status, count(BookingId) from [Booking] GROUP BY Status";
            SqlCommand command = new SqlCommand(cmd, connection);

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dtOverallData);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return dtOverallData;


        }





    }
}
