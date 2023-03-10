using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class Allcs
    {
        public static string ReadWord()
        {
            string str = Console.ReadLine();

            string pattern = @"^[a-zA-Z'_\-]+$";
            do
            {
                if (Regex.IsMatch(str, pattern))
                    return str;
                else
                {
                    Console.Write("Incorrect word!!! \nEnter word again: ");
                    str = Console.ReadLine();
                }
            } while (true);
        }
        public static string ReadNumber()
        {
            string str = Console.ReadLine();

            string pattern = @"^\d+$";
            do
            {
                if (Regex.IsMatch(str, pattern))
                    return str;
                else
                {
                    Console.Write("\nIncorrect number!!! \nEnter number again: ");
                    str = Console.ReadLine();
                }
            } while (true);
        }
        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine(new string('-', 27));
            Console.WriteLine("0  - Exit");
            Console.WriteLine("1  - Add word");
            Console.WriteLine("2  - Add translation");
            Console.WriteLine("3  - Change word");
            Console.WriteLine("4  - Change translation");
            Console.WriteLine("5  - Delete word");
            Console.WriteLine("6  - Delete translation");
            Console.WriteLine("7  - Find word");
            Console.WriteLine("8  - Sort");
            Console.WriteLine("9  - View request history");
            Console.WriteLine("10 - Delete request history");
            Console.WriteLine("11 - View last requests");
            Console.WriteLine(new string('-', 27));
            Console.Write("Enter choice: ");

            return Convert.ToInt32(ReadNumber());
        }
    }
}
