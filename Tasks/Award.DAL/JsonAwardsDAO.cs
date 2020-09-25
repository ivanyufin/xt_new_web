using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Awards.DAL.Interfaces;
using Newtonsoft.Json;
using Task7._1._1.Entities;

namespace Awards.DAL
{
    public class JsonAwardsDAO : IAwardsDAO
    {
        private const string LocalDataPath = "C:\\Database\\Data\\";
        private const string LocalAwardsPath = LocalDataPath + "Awards\\";
        public void Add(Award award)
        {
            if (award == null)
                throw new ArgumentNullException(nameof(award));

            string awardName = "Award_" + award.ID + ".json";
            var awardJson = JsonConvert.SerializeObject(award);

            Directory.CreateDirectory(LocalAwardsPath);

            using (var writer = new StreamWriter(LocalAwardsPath + awardName))
                writer.Write(awardJson);
        }

        public void DeleteByID(int ID)
        {
            File.Delete(LocalAwardsPath + "Award_" + ID + ".json");
        }

        public IEnumerable<Award> GetAll()
        {
            var directory = new DirectoryInfo(LocalAwardsPath);

            foreach (var file in directory.GetFiles())
                using (var reader = new StreamReader(file.FullName))
                    yield return JsonConvert.DeserializeObject<Award>(reader.ReadToEnd());
        }

        public Award GetAwardByID(int ID)
        {
            foreach (var award in GetAll())
                if (award.ID == ID)
                    return award;
            return null;
        }

        public int GetID(string title)
        {
            //TODO
            throw new NotImplementedException();
        }

        public void Update(Award award, string newTitle)
        {
            if (award == null)
                throw new ArgumentNullException(nameof(award));

            string awardName = "Award_" + award.ID + ".json";
            if (!File.Exists(LocalAwardsPath + awardName))
                throw new FileNotFoundException();

            award.Title = newTitle;

            var userJson = JsonConvert.SerializeObject(award);

            using (var writer = new StreamWriter(LocalAwardsPath + awardName))
                writer.Write(userJson);
        }
    }
}
