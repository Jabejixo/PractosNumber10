using System.Diagnostics;
using static System.Console;
namespace PractosNumber10_HelpME_
{
    internal class Program
    {
        public static int menu = 1;
        public static int check = 0;
        public static int max = 4;
        public static int min = 2;
        public static int position = 2;
        static List<User> users = new List<User>();
        static List<Admin> admins = new List<Admin>();
        static List<PersonManager> managers = new List<PersonManager>();
        static List<WarehouseManager> warehouses = new List<WarehouseManager>();
        static List<Cashier> cashiers = new List<Cashier>();
        static List<Accountant> accountants = new List<Accountant>();
        static int subparam;
        static Keystroke currentKey;
        static void Main()
        {
            FileManager.ReadUsersFromFile(users);
            Start(currentKey, menu, users, subparam, check, max, min, position, admins, managers , warehouses, cashiers, accountants);
        }

        public static void Start(Keystroke currentKey, int menu, List<User> users, int subparam, int check, int max, int min, int position, List<Admin> admins, List<PersonManager> managers, List<WarehouseManager> warehouses, List<Cashier> cashiers, List<Accountant> accountants)
        {
            switch (menu)
            {
                case 1:
            Authorization.Autorization(currentKey, users, menu, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                    break;
                case 2:
                    users = FileManager.ReadUsersFromFile(users);
                    admins = Admin.ReadUsersFromFile(admins);
                    managers = PersonManager.ReadUsersFromFile(managers);
                    warehouses = WarehouseManager.ReadUsersFromFile(warehouses);
                    cashiers = Cashier.ReadUsersFromFile(cashiers);
                    accountants = Accountant.ReadUsersFromFile(accountants);
            User.Draw(users, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                    break;
            }
        }
    }
}