using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table_Users_Awards.DAL.Interfaces;
using Task7._1._1.Entities;

namespace Table_Users_Awards.DAL
{
    public class dbTable_Users_AwardsDAO : ITable_Users_AwardsDAO
    {
        //Table_Users_AwardsDAO

        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        private static SqlConnection _connection = new SqlConnection(_connectionString);
        public void Add(int userID, int awardID)
        {
            _connection = new SqlConnection(_connectionString);
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
            var query = "INSERT INTO dbo.Table_Users_AwardsDAO(User_ID, Award_ID) " +
                    "VALUES(@User_ID, @Award_ID)";
                var command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@User_ID", userID);
                command.Parameters.AddWithValue("@Award_ID", awardID);
                var result = command.ExecuteNonQuery();
        }

        public void Delete(int awardID, int userID)
        {
            _connection = new SqlConnection(_connectionString);
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
            var query = "DELETE FROM Table_Users_AwardsDAO WHERE User_ID = " + userID + " AND Award_ID = " + awardID;
                var command = new SqlCommand(query, _connection);
                var result = command.ExecuteNonQuery();
        }

        public void DeleteByAwardID(int awardID)
        {
            _connection = new SqlConnection(_connectionString);
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
            var query = "DELETE FROM Table_Users_AwardsDAO WHERE Award_ID = " + awardID;
                var command = new SqlCommand(query, _connection);
                var result = command.ExecuteNonQuery();
        }

        public void DeleteByUserID(int userID)
        {
            _connection = new SqlConnection(_connectionString);
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
            var query = "DELETE FROM Table_Users_AwardsDAO WHERE User_ID = " + userID;
                var command = new SqlCommand(query, _connection);
                var result = command.ExecuteNonQuery();
        }

        public IEnumerable<Award> GetAwardsByUserID(int userID)
        {
            _connection = new SqlConnection(_connectionString);
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
            var query = "SELECT User_ID, Award_ID FROM Table_Users_AwardsDAO";

                var command = new SqlCommand(query, _connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if ((int)reader["User_ID"] == userID)
                    {
                        using (var __connection = new SqlConnection(_connectionString))
                        {

                            var query1 = "SELECT Id, Title FROM Awards";

                            var command1 = new SqlCommand(query1, __connection);

                            __connection.Open();

                            var reader1 = command1.ExecuteReader();

                            while (reader1.Read())
                            {
                                yield return new Award()
                                {
                                    ID = (int)reader1["Id"],
                                    Title = reader1["Title"] as string,
                                };
                            }
                        }
                    }
                }
        }

        public IEnumerable<User> GetUsersByAwardID(int awardID)
        {
            _connection = new SqlConnection(_connectionString);
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
            var query = "SELECT User_ID, Award_ID FROM Table_Users_AwardsDAO";

                var command = new SqlCommand(query, _connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if ((int)reader["Award_ID"] == awardID)
                    {
                        using (var __connection = new SqlConnection(_connectionString))
                        {

                            var query1 = "SELECT Id, Name, DateOfBirth FROM Users";

                            var command1 = new SqlCommand(query1, __connection);

                            __connection.Open();

                            var reader1 = command1.ExecuteReader();

                            while (reader1.Read())
                            {
                                yield return new User()
                                {
                                    ID = (int)reader1["Id"],
                                    Name = reader1["Name"] as string,
                                    DateOfBirth = (DateTime)reader1["DateOfBirth"],
                                };
                            }
                        }
                    }
            }
        }
    }
}
