using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Diagnostics.CodeAnalysis;
using System.Data;

namespace PractosNumber10_HelpME_
{
    internal class Arrows
    {
        static User user;
        static Admin admin;
        static PersonManager manager;
        static WarehouseManager warehouse;
        static Cashier cashier;
        static Accountant accountant;
        static string Elogin, Epassword;
        static string Flogin, Fpassword;
        static int ID;
        static int Role;
        static string Login = "";
        static string Password = "";
        public static string Name;
        public static string Surname;
        public static string Patronymic;
        public static int ZP;
        public static int UserID;
        public static int Passport;
        public static int subparam2 = 0;
        static bool Entered = false;
        public static void Read_Key(Keystroke currentKey, int position, int max, int min, List<User> users, bool isAuthorized, int menu, int subparam, int check, List<Admin> admins, List<PersonManager> managers, List<WarehouseManager> warehouses, List<Cashier> cashiers, List<Accountant> accountants)
        {
            do
            {
                CursorVisible = false;
                ConsoleKey key = ReadKey().Key;
                currentKey = key switch
                {
                    ConsoleKey.UpArrow => Keystroke.Up,
                    ConsoleKey.DownArrow => Keystroke.Down,
                    ConsoleKey.S => Keystroke.Save,
                    ConsoleKey.F1 => Keystroke.Create,
                    ConsoleKey.Delete => Keystroke.Delete,
                    ConsoleKey.Enter => Keystroke.Enter,
                    ConsoleKey.Escape => Keystroke.Escape,
                    ConsoleKey.OemMinus => Keystroke.Minus,
                    ConsoleKey.OemPlus => Keystroke.Plus,
                    ConsoleKey.F2 => Keystroke.Find,
                    ConsoleKey.F10 => Keystroke.Change,
                    _ => Keystroke.Empty
                } ;
                switch (menu)
                {
                    case 1:
                        switch (currentKey)
                        {
                            case Keystroke.Up:
                                position--;
                                Draw(position, max, min);
                                break;
                            case Keystroke.Down:
                                position++;
                                Draw(position, max, min);
                                break;
                            case Keystroke.Enter:
                                if (position == 2)
                                {
                                    SetCursorPosition(15, 2);
                                    WriteLine("                                     ");
                                    CursorVisible = true;
                                    SetCursorPosition(15, 2);
                                    Elogin = Foolproof.StringParam(Elogin);
                                }
                                else if (position == 3)
                                {
                                    SetCursorPosition(15, 3);
                                    CursorVisible = true;
                                    Epassword = null;
                                    Write("                                                     ");
                                    SetCursorPosition(15, 3);
                                    while (true)
                                    {
                                        var Key = ReadKey(true);

                                        if (Key.Key == ConsoleKey.Enter) break;
                                        Write("*");
                                        Epassword += Key.KeyChar;
                                    }
                                }
                                else if (position == 4)
                                {
                                    menu = 2;
                                    check = 1;
                                    Authorization.Check(Elogin, Epassword, users, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                    if (isAuthorized == false)
                                    {
                                        check = 0;
                                        menu = 1;
                                    }
                                }
                                break;
                            case Keystroke.Escape:
                                Clear();
                                Environment.Exit(0);
                                break;
                        }
                        break;
                    case 2:
                        switch (currentKey)
                        {
                            case Keystroke.Up:
                                position--;
                                Draw(position, max, min);
                                break;
                            case Keystroke.Down:
                                position++;
                                Draw(position, max, min);
                                break;
                            case Keystroke.Create:
                                    menu = 3;
                                    ICRUD_Interface.Create(users, admins, managers, warehouses, cashiers, accountants, menu, subparam, check);
                                break;
                            case Keystroke.Delete:
                                if (position >= min && position <= users.Count + 2)
                                {
                                    User user = users[position - 3];
                                    users.Remove(user);
                                    FileManager.SaveToFile(users);
                                    Clear();
                                    User.Draw(users, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                }
                                else if (position > users.Count + 2 && position <= (admins.Count + users.Count + 2))
                                {
                                    Admin admin = admins[position - (3 + users.Count)];
                                    admins.Remove(admin);
                                    Admin.SaveToFile(admins);
                                    Clear();
                                    User.Draw(users, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                }
                                else if (position > (admins.Count + users.Count + 2) && position <= (admins.Count + users.Count + managers.Count + 2))
                                {
                                    PersonManager manager = managers[position - (3 + users.Count + admins.Count)];
                                    managers.Remove(manager);
                                    PersonManager.SaveToFile(managers);
                                    Clear();
                                    User.Draw(users, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                }
                                else if (position > (admins.Count + users.Count + managers.Count + 2) && position <= (admins.Count + users.Count + managers.Count + warehouses.Count + 2))
                                {
                                    WarehouseManager warehouse = warehouses[position - (3 + users.Count + admins.Count + managers.Count)];
                                    warehouses.Remove(warehouse);
                                    WarehouseManager.SaveToFile(warehouses);
                                    Clear();
                                    User.Draw(users, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                }
                                else if (position > (admins.Count + users.Count + managers.Count + warehouses.Count + 2) && position <= (admins.Count + users.Count + managers.Count + warehouses.Count + cashiers.Count + 2))
                                {
                                    Cashier cashier = cashiers[position - (3 + users.Count + admins.Count + managers.Count + warehouses.Count)];
                                    cashiers.Remove(cashier);
                                    Cashier.SaveToFile(cashiers);
                                    Clear();
                                    User.Draw(users, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                }
                                else if (position > (admins.Count + users.Count + managers.Count + warehouses.Count + cashiers.Count + 2) && position <= (admins.Count + users.Count + managers.Count + warehouses.Count + cashiers.Count + accountants.Count + 2))
                                {
                                    Accountant accountant = accountants[position - (3 + users.Count + admins.Count + managers.Count + warehouses.Count + cashiers.Count)];
                                    accountants.Remove(accountant);
                                    Accountant.SaveToFile(accountants);
                                    Clear();
                                    User.Draw(users, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                }
                                break;
                            case Keystroke.Find:
                                Clear();
                                menu = 5;
                                Flogin = null;
                                Fpassword = null;
                                Role = 0;
                                ID = 0;
                                Entered = false;
                                ICRUD_Interface.Find(users, admins, managers, warehouses, cashiers, accountants, menu, subparam, check);
                                break;
                            case Keystroke.Change:
                                if (position >= min && position <= users.Count + 2)
                                {
                                    user = users[position - 3];
                                    min = 1;
                                    max = 4;
                                    position = 1;
                                    ID = user.ID;
                                    Login = user.Login;
                                    Password = user.Password;
                                    Role = user.Role;
                                    subparam2 = 0;
                                    User.DrawAllInfo(user);
                                    users.Remove(user);
                                    menu = 6;
                                }
                                else if (position > users.Count + 2 && position <= (admins.Count + users.Count + 2))
                                {
                                    admin = admins[position - (3 + users.Count)];
                                    min = 1;
                                    max = 7;
                                    position = 1;
                                    ID = admin.ID;
                                    Login = admin.Login;
                                    Password = admin.Password;
                                    Role = admin.Role;
                                    ZP = admin.ZP;
                                    UserID = admin.UserID;
                                    Passport = admin.Passport;
                                    subparam2 = 1;
                                    if (admin.Name != null && admin.Surname != null && admin.Patronymic != null)
                                    {
                                        max = 10;
                                        Name= admin.Name;
                                        Surname= admin.Surname;
                                        Patronymic= admin.Patronymic;
                                    }
                                    subparam2 = 1;
                                    Admin.DrawAllInfo(admin);
                                    admins.Remove(admin);
                                    menu = 6;
                                }
                                else if (position > (admins.Count + users.Count + 2) && position <= (admins.Count + users.Count + managers.Count + 2))
                                {
                                    manager = managers[position - (3 + users.Count + admins.Count)];
                                    min = 1;
                                    max = 7;
                                    position = 1;
                                    ID= manager.ID;
                                    Login= manager.Login;
                                    Password = manager.Password;
                                    Role = manager.Role;
                                    ZP = manager.ZP;
                                    UserID= manager.UserID;
                                    Passport = manager.Passport;
                                    subparam2 = 1;
                                    if (manager.Name != null && manager.Surname != null && manager.Patronymic != null)
                                    {
                                        max = 10;
                                        Name = manager.Name;
                                        Surname = manager.Surname;
                                        Patronymic = manager.Patronymic;
                                    }
                                    PersonManager.DrawAllInfo(manager);
                                    managers.Remove(manager);
                                    menu = 6;
                                }
                                else if (position > (admins.Count + users.Count + managers.Count + 2) && position <= (admins.Count + users.Count + managers.Count + warehouses.Count + 2))
                                {
                                    warehouse = warehouses[position - (3 + users.Count + admins.Count + managers.Count)];
                                    min = 1;
                                    max = 7;
                                    position = 1;
                                    ID = warehouse.ID;
                                    Login= warehouse.Login;
                                    Password = warehouse.Password;
                                    Role = warehouse.Role;
                                    ZP = warehouse.ZP;
                                    UserID= warehouse.UserID;
                                    Passport= warehouse.Passport;
                                    subparam2 = 1;
                                    if (warehouse.Name != null && warehouse.Surname != null && warehouse.Patronymic != null)
                                    {
                                        max = 10;
                                        Name = warehouse.Name;
                                        Surname = warehouse.Surname;
                                        Patronymic = warehouse.Patronymic;
                                    }
                                    WarehouseManager.DrawAllInfo(warehouse);
                                    warehouses.Remove(warehouse);
                                    menu = 6;
                                }
                                else if (position > (admins.Count + users.Count + managers.Count + warehouses.Count + 2) && position <= (admins.Count + users.Count + managers.Count + warehouses.Count + cashiers.Count + 2))
                                {
                                    cashier = cashiers[position - (3 + users.Count + admins.Count + managers.Count + warehouses.Count)];
                                    min = 1;
                                    max = 7;
                                    position = 1;
                                    ID= cashier.ID;
                                    Login= cashier.Login;
                                    Password = cashier.Password;
                                    Role = cashier.Role;
                                    ZP= cashier.ZP;
                                    UserID= cashier.UserID;
                                    Passport= cashier.Passport;
                                    subparam2 = 1;
                                    if (cashier.Name != null && cashier.Surname != null && cashier.Patronymic != null)
                                    {
                                        max = 10;
                                        Name = cashier.Name;
                                        Surname = cashier.Surname;
                                        Patronymic = cashier.Patronymic;
                                    }
                                    Cashier.DrawAllInfo(cashier);
                                    cashiers.Remove(cashier);
                                    menu = 6;
                                }
                                else if (position > (admins.Count + users.Count + managers.Count + warehouses.Count + cashiers.Count + 2) && position <= (admins.Count + users.Count + managers.Count + warehouses.Count + cashiers.Count + accountants.Count + 2))
                                {
                                    accountant = accountants[position - (3 + users.Count + admins.Count + managers.Count + warehouses.Count + cashiers.Count)];
                                    min = 1;
                                    max = 7;
                                    position = 1;
                                    ID= accountant.ID;
                                    Login= accountant.Login;
                                    Password = accountant.Password;
                                    Role = accountant.Role;
                                    ZP= accountant.ZP;
                                    UserID= accountant.UserID;
                                    Passport= accountant.Passport;
                                    subparam2 = 1;
                                    if (accountant.Name != null && accountant.Surname != null && accountant.Patronymic != null)
                                    {
                                        max = 10;
                                        Name = accountant.Name;
                                        Surname = accountant.Surname;
                                        Patronymic = accountant.Patronymic;
                                    }
                                    Accountant.DrawAllInfo(accountant);
                                    accountants.Remove(accountant);
                                    menu = 6;
                                }
                                break;
                            case Keystroke.Escape:
                                Clear();
                                menu--;
                                max = 4;
                                min = 2;
                                position = 2;
                                Program.Start(currentKey, menu, users, subparam, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                break;
                            case Keystroke.Enter:
                                if (position >= min && position <= users.Count+2)
                                {
                                    user = users[position-3];
                                    menu = 4;
                                    User.DrawAllInfo(user);
                                }
                                else if (position > users.Count + 2 && position <= (admins.Count + users.Count +2))
                                {
                                    admin = admins[position-(3 + users.Count)];
                                    menu = 4;
                                    Admin.DrawAllInfo(admin);
                                }
                                else if (position > (admins.Count + users.Count + 2) && position <= (admins.Count + users.Count + managers.Count + 2)) 
                                {
                                    manager = managers[position-(3 + users.Count + admins.Count)];
                                    menu = 4;
                                    PersonManager.DrawAllInfo(manager);
                                }
                                else if (position > (admins.Count + users.Count + managers.Count + 2) && position <= (admins.Count + users.Count + managers.Count + warehouses.Count + 2))
                                {
                                    warehouse = warehouses[position - (3 + users.Count + admins.Count + managers.Count)];
                                    menu = 4;
                                    WarehouseManager.DrawAllInfo(warehouse);
                                }
                                else if (position > (admins.Count + users.Count + managers.Count + warehouses.Count + 2) && position <= (admins.Count + users.Count + managers.Count + warehouses.Count + cashiers.Count + 2))
                                {
                                    cashier = cashiers[position - (3 + users.Count + admins.Count + managers.Count + warehouses.Count)];
                                    menu = 4;
                                    Cashier.DrawAllInfo(cashier);
                                }
                                else if (position > (admins.Count + users.Count + managers.Count + warehouses.Count + cashiers.Count + 2) && position <= (admins.Count + users.Count + managers.Count + warehouses.Count + cashiers.Count + accountants.Count + 2))
                                {
                                    accountant = accountants[position - (3 + users.Count + admins.Count + managers.Count + warehouses.Count + cashiers.Count)];
                                    menu = 4;
                                    Accountant.DrawAllInfo(accountant);
                                }
                                break;
                        }
                        break;
                    case 3:
                        switch (currentKey)
                        {
                            case Keystroke.Up:
                                position--;
                                Draw(position, max, min);
                                break;
                            case Keystroke.Down:
                                position++;
                                Draw(position, max, min);
                                break;
                            case Keystroke.Enter:
                                switch (subparam)
                                {
                                    case 0:
                                        if (position == 2)
                                        {
                                            SetCursorPosition(15, 2);
                                            WriteLine("                                 ");
                                            SetCursorPosition(15, 2);
                                            CursorVisible = true;
                                            ID = Foolproof.IntParam(ID);
                                        }
                                        else if (position == 3)
                                        {
                                            SetCursorPosition(15, 3);
                                            WriteLine("                                 ");
                                            SetCursorPosition(15, 3);
                                            CursorVisible = true;
                                            Login = Foolproof.StringParam(Login);
                                        }
                                        else if (position == 4)
                                        {
                                            SetCursorPosition(15, 4);
                                            CursorVisible = true;
                                            WriteLine("                                 ");
                                            SetCursorPosition(15, 4);
                                            Password = Foolproof.StringParam(Password);
                                        }
                                        else if (position == 5)
                                        {
                                            SetCursorPosition(15, 5);
                                            CursorVisible = true;
                                            WriteLine("                                 ");
                                            SetCursorPosition(15, 5);
                                            Role = Foolproof.IntParam(Role);
                                        }
                                        break;
                                    case 1:
                                        if (position == 2)
                                        {
                                            SetCursorPosition(15, 2);
                                            CursorVisible = true;
                                            WriteLine("                                 ");
                                            SetCursorPosition(15, 2);
                                            ID = Foolproof.IntParam(ID);
                                        }
                                        else if (position == 3)
                                        {
                                            SetCursorPosition(15, 3);
                                            CursorVisible = true;
                                            WriteLine("                                 ");
                                            SetCursorPosition(15, 3);
                                            Login = Foolproof.StringParam(Login);
                                        }
                                        else if (position == 4)
                                        {
                                            SetCursorPosition(15, 4);
                                            CursorVisible = true;
                                            WriteLine("                                 ");
                                            SetCursorPosition(15, 4);
                                            Password = Foolproof.StringParam(Password);
                                        }
                                        else if (position == 5)
                                        {
                                            SetCursorPosition(15, 5);
                                            CursorVisible = true;
                                            WriteLine("                                 ");
                                            SetCursorPosition(15, 5);
                                            Role = Foolproof.IntParam(Role);
                                        }
                                        else if (position == 6)
                                        {
                                            SetCursorPosition(15, 6);
                                            CursorVisible = true;
                                            WriteLine("                                 ");
                                            SetCursorPosition(15, 6);
                                            Name = Foolproof.StringParam(Name);
                                        }
                                        else if (position == 7)
                                        {
                                            SetCursorPosition(15, 7);
                                            CursorVisible = true;
                                            WriteLine("                                 ");
                                            SetCursorPosition(15, 7);
                                            Surname = Foolproof.StringParam(Surname);
                                        }
                                        else if (position == 8)
                                        {
                                            SetCursorPosition(15, 8);
                                            CursorVisible = true;
                                            WriteLine("                                 ");
                                            SetCursorPosition(15, 8);
                                            Patronymic = Foolproof.StringParam(Patronymic);
                                        }
                                        else if (position == 9)
                                        {
                                            SetCursorPosition(15, 9);
                                            CursorVisible = true;
                                            WriteLine("                                 ");
                                            SetCursorPosition(15, 9);
                                            ZP = Foolproof.IntParam(ZP);
                                        }
                                        else if (position == 10)
                                        {
                                            SetCursorPosition(15, 10);
                                            CursorVisible = true;
                                            WriteLine("                                 ");
                                            SetCursorPosition(15, 10);
                                            UserID = Foolproof.IntParam(UserID);
                                        }
                                        else if (position == 11)
                                        {
                                            SetCursorPosition(15, 11);
                                            CursorVisible = true;
                                            WriteLine("                                 ");
                                            SetCursorPosition(15, 11);
                                            Passport = Foolproof.IntParam(Passport);
                                        }
                                        break;
                                }
                                break;
                            case Keystroke.Save:
                                List<User> user = FileManager.ReadUsersFromFile(users);
                                List<Admin> admin = Admin.ReadUsersFromFile(admins);
                                List<PersonManager> manager = PersonManager.ReadUsersFromFile(managers);
                                List<WarehouseManager> warehouse = WarehouseManager.ReadUsersFromFile(warehouses);
                                List<Cashier> cashier = Cashier.ReadUsersFromFile(cashiers);
                                List<Accountant> accountant = Accountant.ReadUsersFromFile(accountants);
                                switch (subparam)
                                {
                                    case 0:
                                        if (Role == 1 || Role == 2 || Role == 3 || Role == 4 || Role == 5)
                                        {
                                        menu = 2;
                                        user.Add(new User(ID, Role, Login, Password));
                                        FileManager.SaveToFile(user);
                                        check = 1;
                                        Clear();
                                        User.Draw(user, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                        }
                                        else
                                        {
                                            WriteLine("Такой роли не существует (Введите число от 0 до 4)");
                                        }
                                        break;
                                    case 1:
                                        if (Role == 1)
                                        {
                                            menu = 2;
                                            admin.Add(new Admin(ID, Role, Login, Password, ZP, UserID, Passport, Name, Surname, Patronymic));
                                            Admin.SaveToFile(admin);
                                            check = 1;
                                            Clear();
                                            User.Draw(user, subparam, currentKey, check, max, min, position, admin, managers, warehouses, cashiers, accountants);
                                        }
                                        else if (Role == 2)
                                        {
                                            menu = 2;
                                            manager.Add(new PersonManager(ID, Role, Login, Password, ZP, UserID, Passport, Name, Surname, Patronymic));
                                            PersonManager.SaveToFile(manager);
                                            check = 1;
                                            Clear();
                                            User.Draw(user, subparam, currentKey, check, max, min, position, admins, manager, warehouses, cashiers, accountants);
                                        }
                                        else if (Role == 3)
                                        {
                                            menu = 2;
                                            warehouse.Add(new WarehouseManager(ID, Role, Login, Password, ZP, UserID, Passport, Name, Surname, Patronymic));
                                            WarehouseManager.SaveToFile(warehouse);
                                            check = 1;
                                            Clear();
                                            User.Draw(user, subparam, currentKey, check, max, min, position, admins, managers, warehouse, cashiers, accountants);
                                        }
                                        else if (Role == 4)
                                        {
                                            menu = 2;
                                            cashier.Add(new Cashier(ID, Role, Login, Password, ZP, UserID, Passport, Name, Surname, Patronymic));
                                            Cashier.SaveToFile(cashier);
                                            check = 1;
                                            Clear();
                                            User.Draw(user, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashier, accountants);
                                        }
                                        else if (Role == 5)
                                        {
                                            menu = 2;
                                            accountant.Add(new Accountant(ID, Role, Login, Password, ZP, UserID, Passport, Name, Surname, Patronymic));
                                            Accountant.SaveToFile(accountant);
                                            check = 1;
                                            Clear();
                                            User.Draw(user, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountant);
                                        }
                                        else
                                        {
                                            WriteLine("Такой роли быть не может, (введите число от 1 до 5)");
                                        }
                                        break;
                                }
                                break;
                            case Keystroke.Escape:
                                Clear();
                                menu--;
                                Program.Start(currentKey, menu, users, subparam, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                break;
                        }
                        break;
                    case 4:
                        switch (currentKey)
                        {
                            case Keystroke.Escape:
                                Clear();
                                menu = 2;
                                Program.Start(currentKey, menu, users, subparam, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                break;
                        }
                        break;
                    case 5://Поиск
                        switch (currentKey)
                        {
                            case Keystroke.Up:
                                position--;
                                Draw(position, max, min);
                                break;
                            case Keystroke.Down:
                                position++;
                                Draw(position, max, min);
                                break;
                            case Keystroke.Enter:
                                if (position == 2)
                                {
                                    if (Entered == true)
                                    {
                                        SetCursorPosition(30, 30);
                                        WriteLine("Нельзя выбрать больше одного параметра");
                                        ReadKey();
                                        SetCursorPosition(30, 30);
                                        WriteLine("                                       ");
                                    }
                                    else
                                    {
                                    SetCursorPosition(15, 2);
                                    CursorVisible = true;
                                    WriteLine("                                 ");
                                    SetCursorPosition(15, 2);
                                    Entered = true;
                                    ID = Foolproof.IntParam(ID);
                                    }
                                }
                                else if (position == 3)
                                {
                                    if (Entered == true)
                                    {
                                        SetCursorPosition(30, 30);
                                        WriteLine("Нельзя выбрать больше одного параметра");
                                        ReadKey();
                                        SetCursorPosition(30, 30);
                                        WriteLine("                                       ");
                                    }
                                    else
                                    {
                                        SetCursorPosition(15, 3);
                                        CursorVisible = true;
                                        WriteLine("                                 ");
                                        SetCursorPosition(15, 3);
                                        Entered = true;
                                        Flogin = Foolproof.StringParam(Flogin);
                                    }
                                }
                                else if (position == 4)
                                {
                                    if (Entered == true)
                                    {
                                        SetCursorPosition(30, 30);
                                        WriteLine("Нельзя выбрать больше одного параметра");
                                        ReadKey();
                                        SetCursorPosition(30, 30);
                                        WriteLine("                                       ");
                                    }
                                    else
                                    {
                                        SetCursorPosition(15, 4);
                                        CursorVisible = true;
                                        WriteLine("                                 ");
                                        SetCursorPosition(15, 4);
                                        Entered = true;
                                        Fpassword = Foolproof.StringParam(Fpassword);
                                    }
                                }
                                else if (position == 5)
                                {
                                    if (Entered == true)
                                    {
                                        SetCursorPosition(30, 30);
                                        WriteLine("Нельзя выбрать больше одного параметра");
                                        ReadKey();
                                        SetCursorPosition(30, 30);
                                        WriteLine("                                       ");
                                    }
                                    else
                                    {
                                    SetCursorPosition(15, 5);
                                    CursorVisible = true;
                                    WriteLine("                                 ");
                                    SetCursorPosition(15, 5);
                                    Entered = true;
                                    Role = Foolproof.IntParam(Role);
                                    }
                                }
                                else if (position == 6)
                                {
                                    if (Entered == true)
                                    {
                                        menu = 4;
                                        ICRUD_Interface.FindCheck(ID, Role, Flogin, Fpassword, users, admins, managers, warehouses, cashiers, accountants);
                                    }
                                    else 
                                    {
                                        SetCursorPosition(30, 30);
                                        WriteLine("ВВЕДИТЕ ПАРАМЕТР");
                                        ReadKey();
                                        SetCursorPosition(30, 30);
                                        WriteLine("                              ");
                                    }
                                }
                                break;
                            case Keystroke.Escape:
                                Clear();
                                menu = 2;
                                Program.Start(currentKey, menu, users, subparam, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                break;
                        }
                        break;
                    case 6://Изменение
                        switch (currentKey)
                        {
                            case Keystroke.Up:
                                position--;
                                Draw(position, max, min);
                                break;
                            case Keystroke.Down:
                                position++;
                                Draw(position, max, min);
                                break;
                            case Keystroke.Enter:
                                switch (subparam2)
                                {
                                    case 0:
                                        if (position == 1)
                                        {
                                            SetCursorPosition(20, 1);
                                            WriteLine("                                    ");
                                            SetCursorPosition(20, 1);
                                            CursorVisible = true;
                                            ID = 0;
                                            ID = Foolproof.IntParam(ID);
                                        }
                                        else if (position == 2)
                                        {
                                            SetCursorPosition(20, 2);
                                            WriteLine("                                    ");
                                            SetCursorPosition(20, 2);
                                            CursorVisible = true;
                                            Login = null;
                                            Login = Foolproof.StringParam(Login);
                                        }
                                        else if (position == 3)
                                        {
                                            SetCursorPosition(20, 3);
                                            WriteLine("                                    ");
                                            SetCursorPosition(20, 3);
                                            CursorVisible = true;
                                            Password = null;
                                            Password = Foolproof.StringParam(Password);
                                        }
                                        else if (position == 4)
                                        {
                                            SetCursorPosition(20, 4);
                                            WriteLine("                                    ");
                                            SetCursorPosition(20, 4);
                                            CursorVisible = true;
                                            Role = 0;
                                            Role = Foolproof.IntParam(Role);
                                        }
                                        break;
                                    case 1:
                                        if (position == 1)
                                        {
                                            SetCursorPosition(20, 1);
                                            WriteLine("                                    ");
                                            SetCursorPosition(20, 1);
                                            CursorVisible = true;
                                            ID = 0;
                                            ID = Foolproof.IntParam(ID);
                                        }
                                        else if (position == 2)
                                        {
                                            SetCursorPosition(20, 2);
                                            WriteLine("                                    ");
                                            SetCursorPosition(20, 2);
                                            CursorVisible = true;
                                            Login = null;
                                            Login = Foolproof.StringParam(Login);
                                        }
                                        else if (position == 3)
                                        {
                                            SetCursorPosition(20, 3);
                                            WriteLine("                                    ");
                                            SetCursorPosition(20, 3);
                                            CursorVisible = true;
                                            Password = null;
                                            Password = Foolproof.StringParam(Password);
                                        }
                                        else if (position == 4)
                                        {
                                            SetCursorPosition(20, 4);
                                            WriteLine("                                    ");
                                            SetCursorPosition(20, 4);
                                            CursorVisible = true;
                                            Role= 0;
                                            Role = Foolproof.IntParam(Role);
                                        }
                                        else if (position == 5)
                                        {
                                            SetCursorPosition(20, 5);
                                            WriteLine("                                    ");
                                            SetCursorPosition(20, 5);
                                            CursorVisible = true;
                                            ZP = 0;
                                            ZP = Foolproof.IntParam(ZP);
                                        }
                                        else if (position == 6)
                                        {
                                            SetCursorPosition(20, 6);
                                            WriteLine("                                    ");
                                            SetCursorPosition(20, 6);
                                            CursorVisible = true;
                                            UserID = 0;
                                            UserID = Foolproof.IntParam(UserID);
                                        }
                                        else if (position == 7)
                                        {
                                            SetCursorPosition(20, 7);
                                            WriteLine("                                    ");
                                            SetCursorPosition(20, 7);
                                            CursorVisible = true;
                                            Passport = 0;
                                            Passport = Foolproof.IntParam(Passport);
                                        }
                                        if (Name != null && Surname != null && Patronymic != null)
                                        {
                                            if (position == 8)
                                            {
                                                SetCursorPosition(20, 8);
                                                WriteLine("                                    ");
                                                SetCursorPosition(20, 8);
                                                CursorVisible = true;
                                                Name = null;
                                                Name = Foolproof.StringParam(Name);
                                            }
                                            else if (position == 9)
                                            {
                                                SetCursorPosition(20, 9);
                                                WriteLine("                                    ");
                                                SetCursorPosition(20, 9);
                                                CursorVisible = true;
                                                Surname = null;
                                                Surname = Foolproof.StringParam(Surname);
                                            }
                                            else if (position == 10)
                                            {
                                                SetCursorPosition(20, 10);
                                                WriteLine("                                    ");
                                                SetCursorPosition(20, 10);
                                                CursorVisible = true;
                                                Patronymic = null;
                                                Patronymic = Foolproof.StringParam(Patronymic);
                                            }
                                        }

                                        break;
                                }
                                break;
                            case Keystroke.Save:
                                switch (subparam)
                                {
                                    case 0:
                                        if (Role == 1 || Role == 2 || Role == 3 || Role == 4 || Role == 5)
                                        { 
                                            menu = 2;
                                            users.Add(new User(ID, Role, Login, Password));
                                            FileManager.SaveToFile(users);
                                            check = 1;
                                            Clear();
                                            User.Draw(users, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                        }
                                        else
                                        {
                                            SetCursorPosition(30, 30);
                                            WriteLine("Такой роли быть не может (Введите число от 0 до 4)");
                                        }
                                        break;
                                    case 1:
                                        if (Role == 1)
                                        {
                                            menu = 2;
                                            admins.Add(new Admin(ID, Role, Login, Password, ZP, UserID, Passport, Name, Surname, Patronymic));
                                            Admin.SaveToFile(admins);
                                            check = 1;
                                            Clear();
                                            User.Draw(users, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                        }
                                        else if (Role == 2)
                                        {
                                            menu = 2;
                                            managers.Add(new PersonManager(ID, Role, Login, Password, ZP, UserID, Passport, Name, Surname, Patronymic));
                                            PersonManager.SaveToFile(managers);
                                            check = 1;
                                            Clear();
                                            User.Draw(users, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                        }
                                        else if (Role == 3)
                                        {
                                            menu = 2;
                                            warehouses.Add(new WarehouseManager(ID, Role, Login, Password, ZP, UserID, Passport, Name, Surname, Patronymic));
                                            WarehouseManager.SaveToFile(warehouses);
                                            check = 1;
                                            Clear();
                                            User.Draw(users, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                        }
                                        else if (Role == 4)
                                        {
                                            menu = 2;
                                            cashiers.Add(new Cashier(ID, Role, Login, Password, ZP, UserID, Passport, Name, Surname, Patronymic));
                                            Cashier.SaveToFile(cashiers);
                                            check = 1;
                                            Clear();
                                            User.Draw(users, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                        }
                                        else if (Role == 5)
                                        {
                                            menu = 2;
                                            accountants.Add(new Accountant(ID, Role, Login, Password, ZP, UserID, Passport, Name, Surname, Patronymic));
                                            Accountant.SaveToFile(accountants);
                                            check = 1;
                                            Clear();
                                            User.Draw(users, subparam, currentKey, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                        }
                                        else
                                        {
                                            SetCursorPosition(30, 30);
                                            WriteLine("Такой роли быть не может (Введите число от 1 до 5)");
                                        }
                                        break;
                                }
                                break;
                            case Keystroke.Escape:
                                Clear();
                                menu = 2;
                                Program.Start(currentKey, menu, users, subparam, check, max, min, position, admins, managers, warehouses, cashiers, accountants);
                                break;
                        }
                        break;
                    case 7://СкладМен
                        break;
                    case 8://Кассир
                        break;
                    case 9://Бугалтер
                        break;
                }
            } while (check != 1);
        }
        public static void Draw(int position, int max, int min)
        {
            if (position > max)
            {
                position = max;
                SetCursorPosition(0, position);
                WriteLine("->");
                SetCursorPosition(0, position + 1);
                WriteLine("  ");
                SetCursorPosition(0, position);

            }
            else if (position < min)
            {
                position = min;
                SetCursorPosition(0, position - 1);
                WriteLine("  ");
                SetCursorPosition(0, position);
                WriteLine("->");
            }
            else
            {
                SetCursorPosition(0, position - 1);
                WriteLine("  ");
                SetCursorPosition(0, position);
                WriteLine("->");
                SetCursorPosition(0, position + 1);
                WriteLine("  ");
                SetCursorPosition(0, position);
            }
        }


    }
} 
