using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Task7._1._1.Entities;
using Users.DAL.Interfaces;

namespace Users.DAL
{
    public class JsonUsersDAO : IUsersDAO
    {
        private const string LocalDataPath = "C:\\Database\\Data\\";
        private const string LocalUsersPath = LocalDataPath + "Users\\";
        public void Add(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            string userName = "User_" + user.ID + ".json";
            var userJson = JsonConvert.SerializeObject(user);

            Directory.CreateDirectory(LocalUsersPath);

            using (var writer = new StreamWriter(LocalUsersPath + userName))
                writer.Write(userJson);
        }

        public void DeleteByID(int ID)
        {
            File.Delete(LocalUsersPath + "User_" + ID + ".json");
        }

        public IEnumerable<User> GetAll()
        {
            var directory = new DirectoryInfo(LocalUsersPath);

            foreach (var file in directory.GetFiles())
                using (var reader = new StreamReader(file.FullName))
                    yield return JsonConvert.DeserializeObject<User>(reader.ReadToEnd());
        }

        public int GetID(string name)
        {
            throw new NotImplementedException();
        }

        public User GetUserByID(int ID)
        {
            foreach(var user in GetAll())
                if (user.ID == ID)
                    return user;
            return null;
        }

        public void Update(User user, string newName, DateTime newDateOfBirth)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            string userName = "User_" + user.ID + ".json";
            if (!File.Exists(LocalUsersPath + userName))
                throw new FileNotFoundException();

            user.Name = newName;
            user.DateOfBirth = newDateOfBirth;

            var userJson = JsonConvert.SerializeObject(user);

            using (var writer = new StreamWriter(LocalUsersPath + userName))
                writer.Write(userJson);
        }
    }
}
