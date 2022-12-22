using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractosNumber10_HelpME_
{
    internal class Cashier : User
    {
        public string Name;
        public string Surname;
        public string Patronymic;
        public int ZP;
        public int UserID;
        public DateTime DateOfBirth;
        public int Passport;


        public Cashier(int id, int role, string login, string password, int zP, int userID, int passport, string name = null, string surname = null, string patronymic = null)
            : base(id, role, login, password)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            ZP = zP;
            UserID = userID;
            Passport = passport;
        }

        static public List<Cashier> ReadUsersFromFile(List<Cashier> cashiers)
        {
            if (!File.Exists("Cashiers.json"))
            {
                FileStream fileStream = File.Create("Cashiers.json");
                fileStream.Dispose();

                cashiers = new List<Cashier>
                {
                    new Cashier(3, 3, "Cashier", "Cashier", 50000, 3, 5050)
                };
                SaveToFile(cashiers);
            }
            else
            {
                string usersInfo = File.ReadAllText("Cashiers.json");
                cashiers = JsonConvert.DeserializeObject<List<Cashier>>(usersInfo);
            }
            return cashiers;
        }
        static public void SaveToFile(List<Cashier> cashiers)
        {
            if (!File.Exists("Cashiers.json"))
            {
                FileStream fileStream = File.Create("Cashiers.json");
                fileStream.Dispose();
            }

            string json = JsonConvert.SerializeObject(cashiers);
            File.WriteAllText("Cashiers.json", $"\r\n{json}");
        }
        public static void DrawAllInfo(Cashier cashier)
        {
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------------");
            WriteLine("  ID:");
            SetCursorPosition(20, 1);
            WriteLine(cashier.ID);
            WriteLine("  Логин:");
            SetCursorPosition(20, 2);
            WriteLine(cashier.Login);
            WriteLine("  Пароль:");
            SetCursorPosition(20, 3);
            WriteLine(cashier.Password);
            WriteLine("  Роль:");
            SetCursorPosition(20, 4);
            WriteLine(cashier.Role);
            WriteLine("  UserID:");
            SetCursorPosition(20, 5);
            WriteLine(cashier.UserID);
            WriteLine("  Пасспортные данные:");
            SetCursorPosition(20, 6);
            WriteLine(cashier.Passport);
            WriteLine("  Зарплата:");
            SetCursorPosition(20, 7);
            WriteLine(cashier.ZP);
            if (cashier.Name != null && cashier.Surname != null && cashier.Patronymic != null)
            {
                WriteLine("  Имя:");
                SetCursorPosition(20, 8);
                WriteLine(cashier.Name);
                WriteLine("  Фамилия:");
                SetCursorPosition(20, 9);
                WriteLine(cashier.Surname);
                WriteLine("  Отчество:");
                SetCursorPosition(20, 10);
                WriteLine(cashier.Patronymic);
            }
            WriteLine("----------------------------------------------------------------------------------------------------");
        }
    }
}
