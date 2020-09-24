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
        private const string LocalDataPath = "Data\\Awards\\";
        public void Add(Award award)
        {
            if (award == null)
                throw new ArgumentNullException(nameof(award));

            string awardName = "Award_" + award.ID + ".json";
            var awardJson = JsonConvert.SerializeObject(award);

            Directory.CreateDirectory(LocalDataPath);

            using (var writer = new StreamWriter(LocalDataPath + awardName))
                writer.Write(awardJson);
        }

        public void DeleteByID(int ID)
        {
            File.Delete(LocalDataPath + "Award_" + ID + ".json");
        }

        public IEnumerable<Award> GetAll()
        {
            var directory = new DirectoryInfo(Environment.CurrentDirectory + "\\" + LocalDataPath);

            foreach (var file in directory.GetFiles())
                using (var reader = new StreamReader(file.FullName))
                    yield return JsonConvert.DeserializeObject<Award>(reader.ReadToEnd());
        }
    }
}
