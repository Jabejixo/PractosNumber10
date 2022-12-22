using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace PractosNumber10_HelpME_
{
    internal class User : ICRUD_Interface
    {
        public int ID;
        public string Login;
        public string Password;
        public int Role;

        public User(int id, int role, string login, string password)
        {
            ID = id;
            Login = login;
            Password = password;
            Role = role;
        }
        public static void Draw(List<User> users, int subparam, Keystroke currentKey, int check, int max, int min, int position, List<Admin> admins, List<PersonManager> managers, List<WarehouseManager> warehouses, List<Cashier> cashiers, List<Accountant> accountants)
        {
            min = 3;
            position = 3;
            max = users.Count + admins.Count + managers.Count + warehouses.Count + cashiers.Count + accountants.Count + 2;
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------------");
            if (subparam == 0)
            {
            WriteLine($"---------------------------------------ДОБРО ПОЖАЛОВАТЬ АДМИН--------------------------------------");
            }
            else if (subparam == 1)
            {
            WriteLine($"---------------------------------------ДОБРО ПОЖАЛОВАТЬ МАНАГЕР------------------------------------");
            }
            WriteLine("----------------------------------------------------------------------------------------------------");
            for (int i = 3; i < max+1; i++)
            {
                SetCursorPosition(69, i);
                Write("|");
            }
            SetCursorPosition(73, 5);
            Write("F1 - Создать");
            SetCursorPosition(73, 6);
            Write("F2 - Поиск");
            SetCursorPosition(73, 7);
            Write("F10 - Изменить");
            SetCursorPosition(73, 8);
            Write("Delete - Удалить");
            SetCursorPosition(0, max+1);
            WriteLine("----------------------------------------------------------------------------------------------------");
            FileManager.ReadUsersFromFile(users);
            SetCursorPosition(0, 3);
            foreach (var user in users)
            {
                WriteLine($"  ID: {user.ID}       Логин: {user.Login}       Роль: {user.Role}");
            }
            foreach (var admin in admins)
            {
                WriteLine($"  ID: {admin.ID}       Логин: {admin.Login}       Роль: {admin.Role}");
            }
            foreach (var manager in managers)
            {
                WriteLine($"  ID: {manager.ID}       Логин: {manager.Login}       Роль: {manager.Role}");
            }
            foreach (var warehouse in warehouses)
            {
                WriteLine($"  ID: {warehouse.ID}       Логин: {warehouse.Login}       Роль: {warehouse.Role}");
            }
            foreach (var cashier in cashiers)
            {
                WriteLine($"  ID: {cashier.ID}       Логин: {cashier.Login}       Роль: {cashier.Role}");
            }
            foreach (var accauntant in accountants)
            {
                WriteLine($"  ID: {accauntant.ID}       Логин: {accauntant.Login}       Роль: {accauntant.Role}");
            }
            check = 0;
            Arrows.Read_Key(currentKey, position, max, min, users, true, 2, subparam, check, admins, managers, warehouses, cashiers, accountants);
        }
        public static void DrawAllInfo(User user)
        {
            Clear();      
            WriteLine("----------------------------------------------------------------------------------------------------");
            WriteLine("  ID:");
            SetCursorPosition(20, 1);
            WriteLine(user.ID);
            WriteLine("  Login:");
            SetCursorPosition(20, 2);
            WriteLine(user.Login);
            WriteLine("  Password:");
            SetCursorPosition(20, 3);
            WriteLine(user.Password);
            WriteLine("  Role:");
            SetCursorPosition(20, 4);
            WriteLine(user.Role);
            WriteLine("----------------------------------------------------------------------------------------------------");
        }
    }
}
