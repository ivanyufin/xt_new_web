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

        public void DeleteByAwardID(int awardID)
        {
            //TODO
        }

        public void DeleteByUserID(int userID)
        {
            //TODO
        }

        public IEnumerable<Award> GetAwardsByUserID(int userID)
        {
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
            //TODO
            return null;
        }
    }
}
