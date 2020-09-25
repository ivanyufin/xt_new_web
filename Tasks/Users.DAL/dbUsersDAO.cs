using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7._1._1.Entities;
using Users.DAL.Interfaces;

namespace Users.DAL
{
    public class dbUsersDAO : IUsersDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        private static SqlConnection _connection = new SqlConnection(_connectionString);
        public void Add(User user)
        {
            _connection = new SqlConnection(_connectionString);
            var query = "INSERT INTO dbo.Users(DateOfBirth, Name) " +
                    "VALUES(@DateOfBirth, @Name)";
                var command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("@Name", user.Name);
                if (_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();
                var result = command.ExecuteNonQuery();
        }

        public void DeleteByID(int ID)
        {
            _connection = new SqlConnection(_connectionString);
            if (_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();
                var query = "DELETE FROM Users WHERE ID = " + ID;
                var command = new SqlCommand(query, _connection);
                command.ExecuteNonQuery();
        }

        public IEnumerable<User> GetAll()
        {
            _connection = new SqlConnection(_connectionString);
            if (_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();
                var query = "SELECT Id, Name, DateOfBirth FROM Users";

                var command = new SqlCommand(query, _connection);


                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User()
                    {
                        ID = (int)reader["Id"],
                        Name = reader["Name"] as string,
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                    };
                }
        }

        public int GetID(string name)
        {
            _connection = new SqlConnection(_connectionString);
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
            var query = "SELECT Id, Name FROM Users";

            var command = new SqlCommand(query, _connection);


            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Title"] as string == name)
                    return (int)reader["id"];
            }
            return (int)reader["id"];
        }

        public User GetUserByID(int ID)
        {
            _connection = new SqlConnection(_connectionString);
                if (_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();
                var query = "SELECT Id, Name, DateOfBirth FROM Users";

                var command = new SqlCommand(query, _connection);


                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if((int)reader["id"] == ID)
                    return new User()
                    {
                        ID = (int)reader["Id"],
                        Name = reader["Name"] as string,
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                    };
                }
            return null;
        }

        public void Update(User user, string newName, DateTime newDateOfBirth)
        {
            _connection = new SqlConnection(_connectionString);
            if (_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();
                var isoDateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat;

                var query = "UPDATE Users SET DateOfBirth = CAST(\'" + newDateOfBirth.ToString(isoDateTimeFormat.SortableDateTimePattern) + "\' AS DATETIME), Name = N\'" + newName + "\' WHERE ID = " + user.ID;
                var command = new SqlCommand(query, _connection);
                var result = command.ExecuteNonQuery();
        }
    }
}
