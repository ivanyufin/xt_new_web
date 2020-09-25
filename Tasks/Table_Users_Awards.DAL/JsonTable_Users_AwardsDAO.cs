using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Table_Users_Awards.DAL.Interfaces;
using Task7._1._1.Entities;

namespace Table_Users_Awards.DAL
{
    public class JsonTable_Users_AwardsDAO : ITable_Users_AwardsDAO
    {
        private const string LocalDataPath = "C:\\Database\\Data\\";
        private const string TablePath = "table_users_awards.json";
        private const string AwardsPath = "Awards\\";
        private const string UsersPath = "Users\\";
        private readonly Task7._1._1.Entities.Table_Users_Awards table_Users_Awards = new Task7._1._1.Entities.Table_Users_Awards();

        public void Add(int userID, int awardID)
        {
            table_Users_Awards.User_ID = userID;
            table_Users_Awards.Award_ID = awardID;

            var tableJson = JsonConvert.SerializeObject(table_Users_Awards);

            Directory.CreateDirectory(LocalDataPath);

            using (var writer = new StreamWriter(LocalDataPath + TablePath, true))
                writer.WriteLine(tableJson);
        }

        public void Delete(int awardID, int userID)
        {
            using (var reader = new StreamReader(LocalDataPath + TablePath))
                while (!reader.EndOfStream)
                {
                    Task7._1._1.Entities.Table_Users_Awards table_Users_Awards = JsonConvert.DeserializeObject<Task7._1._1.Entities.Table_Users_Awards>(reader.ReadLine());
                    if (table_Users_Awards.Award_ID == awardID && table_Users_Awards.User_ID == userID)
                        continue;
                    else
                        using (var writter = new StreamWriter(LocalDataPath + TablePath + ".tmp", true))
                        {
                            Task7._1._1.Entities.Table_Users_Awards new_table_Users_Awards = new Task7._1._1.Entities.Table_Users_Awards();
                            new_table_Users_Awards.Award_ID = table_Users_Awards.Award_ID;
                            new_table_Users_Awards.User_ID = table_Users_Awards.User_ID;
                            var newTableJson = JsonConvert.SerializeObject(new_table_Users_Awards);
                            writter.WriteLine(newTableJson);
                        }
                }
            File.Delete(LocalDataPath + TablePath);
            File.Move(LocalDataPath + TablePath + ".tmp", LocalDataPath + TablePath);
        }

        public void DeleteByAwardID(int awardID)
        {
            int count_Iteration = 0;
            using (var reader = new StreamReader(LocalDataPath + TablePath))
                while (!reader.EndOfStream)
                {
                    count_Iteration++;
                    Task7._1._1.Entities.Table_Users_Awards table_Users_Awards = JsonConvert.DeserializeObject<Task7._1._1.Entities.Table_Users_Awards>(reader.ReadLine());
                    if (table_Users_Awards.Award_ID != awardID)
                        using(var writter = new StreamWriter(LocalDataPath + TablePath + ".tmp", true))
                        {
                            Task7._1._1.Entities.Table_Users_Awards new_table_Users_Awards = new Task7._1._1.Entities.Table_Users_Awards();
                            new_table_Users_Awards.Award_ID = table_Users_Awards.Award_ID;
                            new_table_Users_Awards.User_ID = table_Users_Awards.User_ID;
                            var newTableJson = JsonConvert.SerializeObject(new_table_Users_Awards);
                            writter.WriteLine(newTableJson);
                        }
                }
            if (count_Iteration > 1)
            {
                File.Delete(LocalDataPath + TablePath);
                File.Move(LocalDataPath + TablePath + ".tmp", LocalDataPath + TablePath);
            }
            else
            {
                File.Delete(LocalDataPath + TablePath);
                File.Create(LocalDataPath + TablePath).Close();
            }
        }

        public void DeleteByUserID(int userID)
        {
            using (var reader = new StreamReader(LocalDataPath + TablePath))
            {
                while (!reader.EndOfStream)
                {
                    Task7._1._1.Entities.Table_Users_Awards table_Users_Awards = JsonConvert.DeserializeObject<Task7._1._1.Entities.Table_Users_Awards>(reader.ReadLine());
                    if (table_Users_Awards.User_ID != userID)
                        using (var writter = new StreamWriter(LocalDataPath + TablePath + ".tmp", true))
                        {
                            Task7._1._1.Entities.Table_Users_Awards new_table_Users_Awards = new Task7._1._1.Entities.Table_Users_Awards();
                            new_table_Users_Awards.Award_ID = table_Users_Awards.Award_ID;
                            new_table_Users_Awards.User_ID = table_Users_Awards.User_ID;
                            var newTableJson = JsonConvert.SerializeObject(new_table_Users_Awards);
                            writter.WriteLine(newTableJson);
                        }
                }
            }
            File.Delete(LocalDataPath + TablePath);
            File.Move(LocalDataPath + TablePath + ".tmp", LocalDataPath + TablePath);
        }

        public IEnumerable<Award> GetAwardsByUserID(int userID)
        {
            if(!File.Exists(LocalDataPath + TablePath))
            {
                var table = File.Create(LocalDataPath + TablePath);
                table.Close();
            }
            List<int> awardsID = new List<int>();
            List<Award> awards = new List<Award>();
            using (var reader = new StreamReader(LocalDataPath + TablePath))
                while (!reader.EndOfStream)
                {
                    Task7._1._1.Entities.Table_Users_Awards table_Users_Awards = JsonConvert.DeserializeObject<Task7._1._1.Entities.Table_Users_Awards>(reader.ReadLine());
                    if (table_Users_Awards.User_ID == userID)
                        awardsID.Add(table_Users_Awards.Award_ID);
                }

            for (int i = 0; i < awardsID.Count; i++)
                using(var reader = new StreamReader(LocalDataPath + AwardsPath + "Award_" + awardsID[i] + ".json"))
                    awards.Add(JsonConvert.DeserializeObject<Award>(reader.ReadToEnd()));
            return awards;
        }

        public IEnumerable<User> GetUsersByAwardID(int awardID)
        {
            List<int> usersID = new List<int>();
            List<User> users = new List<User>();
            using (var reader = new StreamReader(LocalDataPath + TablePath))
                while (!reader.EndOfStream)
                {
                    Task7._1._1.Entities.Table_Users_Awards table_Users_Awards = JsonConvert.DeserializeObject<Task7._1._1.Entities.Table_Users_Awards>(reader.ReadLine());
                    if (table_Users_Awards.Award_ID == awardID)
                        if(usersID.IndexOf(table_Users_Awards.User_ID) == -1)
                            usersID.Add(table_Users_Awards.User_ID);
                }

            for (int i = 0; i < usersID.Count; i++)
                using (var reader = new StreamReader(LocalDataPath + UsersPath + "User_" + usersID[i] + ".json"))
                    users.Add(JsonConvert.DeserializeObject<User>(reader.ReadToEnd()));
            return users;
        }
    }
}
