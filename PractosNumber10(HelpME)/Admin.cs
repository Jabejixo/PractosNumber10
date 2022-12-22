using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using System.Globalization;

namespace PractosNumber10_HelpME_
{
    internal class Admin : User
    {
        public string Name;
        public string Surname;
        public string Patronymic;
        public int ZP;
        public int UserID;
        public int Passport;

        public Admin(int id, int role, string login, string password,int zP, int userID, int passport,
            string name = null,string surname = null, string patronymic = null) : base(id, role, login, password)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            ZP = zP;
            UserID = userID;
            Passport = passport;
        }
        static public List<Admin> ReadUsersFromFile(List<Admin> admins)
        {
            if (!File.Exists("Admins.json"))
            {
                FileStream fileStream = File.Create("Admins.json");
                fileStream.Dispose();

                admins = new List<Admin>
                {
                    new Admin(0, 0, "Admin", "Admin", 50000, 0, 5050)
                };
                SaveToFile(admins);
            }
            else
            {
                string usersInfo = File.ReadAllText("Admins.json");
                admins = JsonConvert.DeserializeObject<List<Admin>>(usersInfo);
            }
            return admins;
        }
        static public void SaveToFile(List<Admin> admins)
        {
            if (!File.Exists("Admins.json"))
            {
                FileStream fileStream = File.Create("Admins.json");
                fileStream.Dispose();
            }

            string json = JsonConvert.SerializeObject(admins);
            File.WriteAllText("Admins.json", $"\r\n{json}");
        }
        public static void DrawAllInfo(Admin admin)
        {
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------------");
            WriteLine("  ID:");
            SetCursorPosition(20, 1);
            WriteLine(admin.ID);
            WriteLine("  Логин:");
            SetCursorPosition(20, 2);
            WriteLine(admin.Login);
            WriteLine("  Пароль:");
            SetCursorPosition(20, 3);
            WriteLine(admin.Password);
            WriteLine("  Роль:");
            SetCursorPosition(20, 4);
            WriteLine(admin.Role);
            WriteLine("  UserID:");
            SetCursorPosition(20, 5);
            WriteLine(admin.UserID);
            WriteLine("  Пасспортные данные:");
            SetCursorPosition(20, 6);
            WriteLine(admin.Passport);
            WriteLine("  Зарплата:");
            SetCursorPosition(20, 7);
            WriteLine(admin.ZP);
            if (admin.Name!= null && admin.Surname != null && admin.Patronymic != null)
            {
                WriteLine("  Имя:");
                SetCursorPosition(20, 8);
                WriteLine(admin.Name);
                WriteLine("  Фамилия:");
                SetCursorPosition(20, 9);
                WriteLine(admin.Surname);
                WriteLine("  Отчество:");
                SetCursorPosition(20, 10);
                WriteLine(admin.Patronymic);
            }
            WriteLine("----------------------------------------------------------------------------------------------------");
        }
    }
}
