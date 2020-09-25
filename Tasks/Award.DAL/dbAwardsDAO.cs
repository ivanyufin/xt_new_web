using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Awards.DAL.Interfaces;
using Task7._1._1.Entities;

namespace Awards.DAL
{
    public class dbAwardsDAO : IAwardsDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        private static SqlConnection _connection = new SqlConnection(_connectionString);
        public void Add(Award award)
        {
            _connection = new SqlConnection(_connectionString);
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
            var query = "INSERT INTO dbo.Awards(Title) " +
                    "VALUES(@Title)";
                var command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Title", award.Title);
                var result = command.ExecuteNonQuery();
        }

        public void DeleteByID(int ID)
        {
            _connection = new SqlConnection(_connectionString);
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
            var query = "DELETE FROM Awards WHERE ID = " + ID;
                var command = new SqlCommand(query, _connection);
                var result = command.ExecuteNonQuery();
        }

        public IEnumerable<Award> GetAll()
        {
            _connection = new SqlConnection(_connectionString);
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
            var query = "SELECT Id, Title FROM Awards";

                var command = new SqlCommand(query, _connection);


                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Award()
                    {
                        ID = (int)reader["Id"],
                        Title = reader["Title"] as string,
                    };
                }
        }

        public Award GetAwardByID(int ID)
        {
            _connection = new SqlConnection(_connectionString);
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
            var query = "SELECT Id, Title FROM Awards";

                var command = new SqlCommand(query, _connection);


                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if ((int)reader["id"] == ID)
                        return new Award()
                        {
                            ID = (int)reader["Id"],
                            Title = reader["Title"] as string,
                        };
                }
            return null;
        }

        public int GetID(string title)
        {
            _connection = new SqlConnection(_connectionString);
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
            var query = "SELECT Id, Title FROM Awards";

            var command = new SqlCommand(query, _connection);


            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Title"] as string == title)
                    return (int)reader["id"];
            }
            return (int)reader["id"];
        }

        public void Update(Award user, string newTitle)
        {
            _connection = new SqlConnection(_connectionString);
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
            var isoDateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat;

                var query = "UPDATE Awards SET Title = N\'" + newTitle + "\' WHERE ID = " + user.ID;
                var command = new SqlCommand(query, _connection);
                var result = command.ExecuteNonQuery();
        }
    }
}
