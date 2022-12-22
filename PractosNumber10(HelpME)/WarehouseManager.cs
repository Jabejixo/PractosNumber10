using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractosNumber10_HelpME_
{
    internal class WarehouseManager : User
    {
        public string Name;
        public string Surname;
        public string Patronymic;
        public int ZP;
        public int UserID;
        public DateTime DateOfBirth;
        public int Passport;


        public WarehouseManager(int id, int role, string login, string password, int zP, int userID, int passport, string name = null, string surname = null, string patronymic = null)
            : base(id, role, login, password)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            ZP = zP;
            UserID = userID;
            Passport = passport;
        }


        static public List<WarehouseManager> ReadUsersFromFile(List<WarehouseManager> warehouses)
        {
            if (!File.Exists("WarehouseManagers.json"))
            {
                FileStream fileStream = File.Create("WarehouseManagers.json");
                fileStream.Dispose();

                warehouses = new List<WarehouseManager>
                {
                    new WarehouseManager(2, 2, "Warehouse", "Warehouse", 50000, 2, 5050)
                };
                SaveToFile(warehouses);
            }
            else
            {
                string usersInfo = File.ReadAllText("WarehouseManagers.json");
                warehouses = JsonConvert.DeserializeObject<List<WarehouseManager>>(usersInfo);
            }
            return warehouses;
        }
        static public void SaveToFile(List<WarehouseManager> warehouses)
        {
            if (!File.Exists("WarehouseManagers.json"))
            {
                FileStream fileStream = File.Create("WarehouseManagers.json");
                fileStream.Dispose();
            }

            string json = JsonConvert.SerializeObject(warehouses);
            File.WriteAllText("WarehouseManagers.json", $"\r\n{json}");
        }
        public static void DrawAllInfo( WarehouseManager warehouse)
        {
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------------");
            WriteLine("  ID:");
            SetCursorPosition(20, 1);
            WriteLine(warehouse.ID);
            WriteLine("  Логин:");
            SetCursorPosition(20, 2);
            WriteLine(warehouse.Login);
            WriteLine("  Пароль:");
            SetCursorPosition(20, 3);
            WriteLine(warehouse.Password);
            WriteLine("  Роль:");
            SetCursorPosition(20, 4);
            WriteLine(warehouse.Role);
            WriteLine("  UserID:");
            SetCursorPosition(20, 5);
            WriteLine(warehouse.UserID);
            WriteLine("  Пасспортные данные:");
            SetCursorPosition(20, 6);
            WriteLine(warehouse.Passport);
            WriteLine("  Зарплата:");
            SetCursorPosition(20, 7);
            WriteLine(warehouse.ZP);
            if (warehouse.Name != null && warehouse.Surname != null && warehouse.Patronymic != null)
            {
                WriteLine("  Имя:");
                SetCursorPosition(20, 8);
                WriteLine(warehouse.Name);
                WriteLine("  Фамилия:");
                SetCursorPosition(20, 9);
                WriteLine(warehouse.Surname);
                WriteLine("  Отчество:");
                SetCursorPosition(20, 10);
                WriteLine(warehouse.Patronymic);
            }
            WriteLine("----------------------------------------------------------------------------------------------------");
        }
    }
}
