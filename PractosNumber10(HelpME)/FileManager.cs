using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace PractosNumber10_HelpME_
{
    static class FileManager
    {
        static public void SaveToFile(List<User> users)
        {
            if (!File.Exists("Users.json"))
            {
                FileStream fileStream = File.Create("Users.json");
                fileStream.Dispose();
            }

            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText("Users.json", $"\r\n{json}");
        }

        static public List<User> ReadUsersFromFile(List <User> users)
        {
            if (!File.Exists("Users.json"))
            {
                FileStream fileStream = File.Create("Users.json");
                fileStream.Dispose();

                users = new List<User>
                {
                    new User(0, 0, "Admin", "Admin")
                };
                SaveToFile(users);
            }
            else
            {
                string usersInfo = File.ReadAllText("Users.json");
                users = JsonConvert.DeserializeObject<List<User>>(usersInfo);
            }
            return users;
        }
    }
}
