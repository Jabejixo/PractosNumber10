using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PractosNumber10_HelpME_
{
    internal interface ICRUD_Interface
    {
        static Keystroke currentKey;
        static bool Finded;
        static int Findedd;
        public static void Create(List <User> users, List<Admin> admins, List<PersonManager> managers, List<WarehouseManager> warehouses, List<Cashier> cashiers, List<Accountant> accountants, int menu, int subparam, int check)
        { 

            switch (subparam)
            {
                case 0:
                    Clear();
                    WriteLine("----------------------------------------------------------------------------------------------------");
                    WriteLine("  ВВЕДИТЕ ПАРАМЕТРЫ");
                    WriteLine("  ID: ");
                    WriteLine("  Логин: ");
                    WriteLine("  Пароль: ");
                    WriteLine("  Роль: ");
                    WriteLine("----------------------------------------------------------------------------------------------------");
                    Arrows.Read_Key(currentKey, 2, 5, 2, users, true, menu, subparam, check, admins, managers, warehouses, cashiers, accountants);
                    break;
                case 1:
                    Clear();
                    WriteLine("----------------------------------------------------------------------------------------------------");
                    WriteLine("  ВВЕДИТЕ ПАРАМЕТРЫ");
                    WriteLine("  ID: ");
                    WriteLine("  Логин: ");
                    WriteLine("  Пароль: ");
                    WriteLine("  Роль: ");
                    WriteLine("  Имя: ");
                    WriteLine("  Фамилия: ");
                    WriteLine("  Отчество: ");
                    WriteLine("  Зарплата: ");
                    WriteLine("  UserID: ");
                    WriteLine("  Пасспорт: ");
                    WriteLine("----------------------------------------------------------------------------------------------------");
                    Arrows.Read_Key(currentKey, 2, 11, 2, users, true, menu, subparam, check, admins, managers, warehouses, cashiers, accountants);
                    break;
            }

        }
        public static void Update() 
        {

        }
        public static void Find(List<User> users, List<Admin> admins, List<PersonManager> managers, List<WarehouseManager> warehouses, List<Cashier> cashiers, List<Accountant> accountants, int menu, int subparam, int check) 
        {
            WriteLine("----------------------------------------------------------------------------------------------------");
            WriteLine("  ВВЕДИТЕ ПАРАМЕТРЫ");
            WriteLine("  ID: ");
            WriteLine("  Логин: ");
            WriteLine("  Пароль: ");
            WriteLine("  Роль: ");
            WriteLine("  Поиск по заданным параметрам");
            WriteLine("----------------------------------------------------------------------------------------------------");
            Arrows.Read_Key(currentKey, 2, 6, 2, users, true, menu, subparam, check, admins, managers, warehouses, cashiers, accountants);
        }
        public static void FindCheck(int ID, int Role, string Flogin, string Fpassword, List<User> users, List<Admin> admins, List<PersonManager> managers, List<WarehouseManager> warehouses, List<Cashier> cashiers, List<Accountant> accountants)
        {
            foreach (User user in users)
            {
                if (user.Login == Flogin || user.Password == Fpassword || user.ID == ID || user.Role == Role)
                {
                    Finded = true;
                    SetCursorPosition(0, Findedd + 8);
                    WriteLine($"  ID: {user.ID}       Login: {user.Login}        Role: {user.Role}");
                    Findedd++;
                }
                else
                {
                    Finded = false;
                }
            }
            foreach (Admin admin in admins)
            {
                if (admin.Login == Flogin || admin.Password == Fpassword || admin.ID == ID || admin.Role == Role)
                {
                    Finded = true;
                    SetCursorPosition(0, Findedd + 8);
                    WriteLine($"  ID: {admin.ID}       Login: {admin.Login}        Role: {admin.Role}");
                    Findedd++;
                }
                else
                {
                    Finded = false;
                }
            }
            foreach (PersonManager manager in managers)
            {
                if (manager.Login == Flogin || manager.Password == Fpassword || manager.ID == ID || manager.Role == Role)
                {
                    Finded = true;
                    SetCursorPosition(0, Findedd + 8);
                    WriteLine($"  ID: {manager.ID}       Login: {manager.Login}        Role: {manager.Role}");
                    Findedd++;
                }
                else
                {
                    Finded = false;
                }
            }
            foreach (WarehouseManager warehouse in warehouses)
            {
                if (warehouse.Login == Flogin || warehouse.Password == Fpassword || warehouse.ID == ID || warehouse.Role == Role)
                {
                    Finded = true;
                    SetCursorPosition(0, Findedd + 8);
                    WriteLine($"  ID: {warehouse.ID}       Login: {warehouse.Login}        Role: {warehouse.Role}");
                    Findedd++;
                }
                else
                {
                    Finded = false;
                }
            }
            foreach (Cashier cashier in cashiers)
            {
                if (cashier.Login == Flogin || cashier.Password == Fpassword || cashier.ID == ID || cashier.Role == Role)
                {
                    Finded = true;
                    SetCursorPosition(0, Findedd + 8);
                    WriteLine($"  ID: {cashier.ID}       Login: {cashier.Login}        Role: {cashier.Role}");
                    Findedd++;
                }
                else
                {
                    Finded = false;
                }
            }
            foreach (Accountant accountant in accountants)
            {
                if (accountant.Login == Flogin || accountant.Password == Fpassword || accountant.ID == ID || accountant.Role == Role)
                {
                    Finded = true;
                    SetCursorPosition(0, Findedd + 8);
                    WriteLine($"  ID: {accountant.ID}       Login: {accountant.Login}        Role: {accountant.Role}");
                    Findedd++;
                }
                else
                {
                    Finded = false;
                }   
            }
            if (Finded == false && Findedd == 0)
            {
                SetCursorPosition(30, 30);
                WriteLine("ТАКОГО ПОЛЬЗОВАТЕЛЯ НЕ СУЩЕСТВУЕТ, повторите ввод");
            }
        }
    }
}
