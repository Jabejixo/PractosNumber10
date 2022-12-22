using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace PractosNumber10_HelpME_
{
    internal class Accountant : User
    {
        public string Name;
        public string Surname;
        public string Patronymic;
        public int ZP;
        public int UserID;
        public DateTime DateOfBirth;
        public int Passport;


        public Accountant(int id, int role, string login, string password, int zP, int userID, int passport, string name = null, string surname = null, string patronymic = null)
            : base(id, role, login, password)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            ZP = zP;
            UserID = userID;
            Passport = passport;
        }

        static public List<Accountant> ReadUsersFromFile(List<Accountant> accountants)
        {
            if (!File.Exists("Accountants.json"))
            {
                FileStream fileStream = File.Create("Accountants.json");
                fileStream.Dispose();

                accountants = new List<Accountant>
                {
                    new Accountant(4, 4, "Accountatn", "Accountatn", 50000, 4, 5050)
                };
                SaveToFile(accountants);
            }
            else
            {
                string usersInfo = File.ReadAllText("Accountants.json");
                accountants = JsonConvert.DeserializeObject<List<Accountant>>(usersInfo);
            }
            return accountants;
        }
        static public void SaveToFile(List<Accountant> cashiers)
        {
            if (!File.Exists("Accountants.json"))
            {
                FileStream fileStream = File.Create("Accountants.json");
                fileStream.Dispose();
            }

            string json = JsonConvert.SerializeObject(cashiers);
            File.WriteAllText("Accountants.json", $"\r\n{json}");
        }
        public static void DrawAllInfo(Accountant accountant)
        {
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------------");
            WriteLine("  ID:");
            SetCursorPosition(20, 1);
            WriteLine(accountant.ID);
            WriteLine("  Логин:");
            SetCursorPosition(20, 2);
            WriteLine(accountant.Login);
            WriteLine("  Пароль:");
            SetCursorPosition(20, 3);
            WriteLine(accountant.Password);
            WriteLine("  Роль:");
            SetCursorPosition(20, 4);
            WriteLine(accountant.Role);
            WriteLine("  UserID:");
            SetCursorPosition(20, 5);
            WriteLine(accountant.UserID);
            WriteLine("  Пасспортные данные:");
            SetCursorPosition(20, 6);
            WriteLine(accountant.Passport);
            WriteLine("  Зарплата:");
            SetCursorPosition(20, 7);
            WriteLine(accountant.ZP);
            if (accountant.Name != null && accountant.Surname != null && accountant.Patronymic != null)
            {
                WriteLine("  Имя:");
                SetCursorPosition(20, 8);
                WriteLine(accountant.Name);
                WriteLine("  Фамилия:");
                SetCursorPosition(20, 9);
                WriteLine(accountant.Surname);
                WriteLine("  Отчество:");
                SetCursorPosition(20, 10);
                WriteLine(accountant.Patronymic);
            }
            WriteLine("----------------------------------------------------------------------------------------------------");
        }
    }
}
