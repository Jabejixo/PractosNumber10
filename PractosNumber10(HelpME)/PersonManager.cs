using Newtonsoft.Json;
using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractosNumber10_HelpME_
{
    internal class PersonManager : User
    {
        public string Name;
        public string Surname;
        public string Patronymic;
        public int ZP;
        public int UserID;
        public DateTime DateOfBirth;
        public int Passport;


        public PersonManager(int id, int role, string login, string password, int zP, int userID, int passport, string name = null, string surname = null, string patronymic = null) : base(id, role, login, password)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            ZP = zP;
            UserID = userID;
            Passport = passport;
        }

        static public List<PersonManager> ReadUsersFromFile(List<PersonManager> managers)
        {
            if (!File.Exists("PersonManagers.json"))
            {
                FileStream fileStream = File.Create("PersonManagers.json");
                fileStream.Dispose();

                managers = new List<PersonManager>
                {
                    new PersonManager(1, 1, "Manager", "Manager", 50000, 1, 5050)
                };
                SaveToFile(managers);
            }
            else
            {
                string usersInfo = File.ReadAllText("PersonManagers.json");
                managers = JsonConvert.DeserializeObject<List<PersonManager>>(usersInfo);
            }
            return managers;
        }
        static public void SaveToFile(List<PersonManager> managers)
        {
            if (!File.Exists("PersonManagers.json"))
            {
                FileStream fileStream = File.Create("PersonManagers.json");
                fileStream.Dispose();
            }

            string json = JsonConvert.SerializeObject(managers);
            File.WriteAllText("PersonManagers.json", $"\r\n{json}");
        }
        public static void DrawAllInfo(PersonManager manager)
        {
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------------");
            WriteLine("  ID:");
            SetCursorPosition(20, 1);
            WriteLine(manager.ID);
            WriteLine("  Логин:");
            SetCursorPosition(20, 2);
            WriteLine(manager.Login);
            WriteLine("  Пароль:");
            SetCursorPosition(20, 3);
            WriteLine(manager.Password);
            WriteLine("  Роль:");
            SetCursorPosition(20, 4);
            WriteLine(manager.Role);
            WriteLine("  UserID:");
            SetCursorPosition(20, 5);
            WriteLine(manager.UserID);
            WriteLine("  Пасспортные данные:");
            SetCursorPosition(20, 6);
            WriteLine(manager.Passport);
            WriteLine("  Зарплата:");
            SetCursorPosition(20, 7);
            WriteLine(manager.ZP);
            if (manager.Name != null && manager.Surname != null && manager.Patronymic != null)
            {
                WriteLine("  Имя:");
                SetCursorPosition(20, 8);
                WriteLine(manager.Name);
                WriteLine("  Фамилия:");
                SetCursorPosition(20, 9);
                WriteLine(manager.Surname);
                WriteLine("  Отчество:");
                SetCursorPosition(20, 10);
                WriteLine(manager.Patronymic);
            }
            WriteLine("----------------------------------------------------------------------------------------------------");
        }
    }
}
