using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Security;
using System.Runtime.InteropServices;

namespace PractosNumber10_HelpME_
{
    static internal class Authorization
    {
        public static Arrows arrow = new();
        public static int subparam;
        static bool isAuthorized;
        public static void Autorization(Keystroke currentKey, List <User> users, int menu,int check, int max, int min, int position, List<Admin> admins, List<PersonManager> managers, List<WarehouseManager> warehouses, List<Cashier> cashiers, List<Accountant> accountants)
        {
            WriteLine("----------------------------------------------------------------------------------------------------");
            WriteLine("  АВТОРИЗАЦИЯ");
            WriteLine("  Логин:  ");
            WriteLine("  Пароль:  ");
            WriteLine("  Авторизоваться");
            WriteLine("----------------------------------------------------------------------------------------------------");
            Arrows.Read_Key(currentKey, position, max, min, users, isAuthorized, menu, subparam , check, admins, managers, warehouses, cashiers, accountants);
        }



        public static bool Check(string Elogin, string Epassword, List <User> users, Keystroke currentKey,int check, int max, int min, int position, List <Admin> admins, List <PersonManager> managers, List <WarehouseManager> warehouses, List <Cashier> cashiers, List <Accountant> accountants)
        {

            users = FileManager.ReadUsersFromFile(users);
            admins = Admin.ReadUsersFromFile(admins);
            managers = PersonManager.ReadUsersFromFile(managers);
            warehouses = WarehouseManager.ReadUsersFromFile(warehouses);
            cashiers = Cashier.ReadUsersFromFile(cashiers);
            accountants = Accountant.ReadUsersFromFile(accountants);

            foreach (User user in users)
            {
                if (user.Login != Elogin || user.Password != Epassword)
                {
                    isAuthorized = false;
                }
                else
                {
                    subparam = 0;
                    User.Draw(users, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                    isAuthorized = true;
                }
            }
            foreach (Admin admin in admins)
            {
                if (admin.Login != Elogin || admin.Password != Epassword)
                {
                    isAuthorized = false;
                }
                else
                {
                    subparam = 0;
                    User.Draw(users, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                    isAuthorized = true;
                }
            }
            foreach (PersonManager manager in managers)
            {
                if (manager.Login != Elogin || manager.Password != Epassword)
                {
                    isAuthorized = false;
                }
                else
                {
                    subparam = 1;
                    User.Draw(users, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                    isAuthorized = true;
                }
            }
            foreach (WarehouseManager warehouse in warehouses)
            {
                if (warehouse.Login != Elogin || warehouse.Password != Epassword)
                {
                    isAuthorized = false;
                }
                else
                {
                    isAuthorized = true;
                }
            }
            foreach (Cashier cashier in cashiers)
            {
                if (cashier.Login != Elogin || cashier.Password != Epassword)
                { 
                    isAuthorized = false;
                }
                else
                {
                    isAuthorized = true;
                }
            }
            foreach (Accountant accountant in accountants)
            {
                if (accountant.Login != Elogin || accountant.Password != Epassword)
                {
                    isAuthorized = false;
                }
                else
                {
                    isAuthorized = true;
                }
            }
            if (isAuthorized == false)
            {
                SetCursorPosition(30, 30);
                WriteLine("ТАКОГО ПОЛЬЗОВАТЕЛЯ НЕ СУЩЕСТВУЕТ, повторите ввод");
                ReadKey();
                SetCursorPosition(30, 30);
                WriteLine("                                                   ");
            }
            return isAuthorized;
        }
    }
}
