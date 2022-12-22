using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PractosNumber10_HelpME_
{
    internal class Foolproof
    {
        public static int IntParam(int param)
        {
            try 
            {
                param = Convert.ToInt32(ReadLine());
                return param;
            } catch 
            {
                SetCursorPosition(30,30);
                WriteLine("ОШИБКА, ПОВТОРИТЕ ВВОД");
                ReadKey();
                SetCursorPosition(30, 30);
                WriteLine("                                    ");
                return 0;
            }
        }
        public static string StringParam(string param)
        {
            try
            { 
                 param = ReadLine();
                 return param;
            } catch
            {
                SetCursorPosition(30, 30);
                WriteLine("ОШИБКА, ПОВТОРИТЕ ВВОД");
                ReadKey();
                SetCursorPosition(30, 30);
                WriteLine("                                    ");
                return null;
            }
        }
    }
}
