using Dictionary;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NLog;
using System.Text.RegularExpressions;
using Dictionary;

namespace Final
{
    internal class Program
    {
        public static string ReadWord()
        {
            string str = Console.ReadLine();

            string pattern = @"^[a-zA-Z'_\-]+$";
            do
            {
                if (Regex.IsMatch(str, pattern))
                    return str;
                else {
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
                    Console.Write("Incorrect number!!! \nEnter number again: ");
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
        static void Main(string[] args)
        {
            // Для кирилиці
            Console.OutputEncoding = Encoding.UTF8;
            // NLog
            Logger logger = LogManager.GetCurrentClassLogger();

            // Створення словника
            List<Word> wordsEnToUa = new List<Word> {
                new Word("Apple", new List<string>{ "Яблуко", "Ябко", "1" } ),
                new Word("Tomato", new List<string>{ "Помідор", "Томати", "1" } ),
                new Word("Egg", new List<string>{ "Яйце", "Яйко", "1" } ),
                new Word("1", new List<string>{ "1", "1", "1" } )
            };
            MyDictionary dictionaryEnToUa = new MyDictionary("En-Ua", wordsEnToUa);
            dictionaryEnToUa.SaveDataToXml();

            List<Word> wordsUaToEn = new List<Word> {
                new Word("Імя", new List<string>{ "Name", "Title", "Appellation" } ),
                new Word("Квітка", new List<string>{ "Flower", "Blossom", "Bloom" } ),
                new Word("Вартість", new List<string>{ "Cost", "Value", "Price" } ),
                new Word("2", new List<string>{ "2", "2", "2" } )
            };
            MyDictionary dictionaryUaToEn = new MyDictionary("Ua-En", wordsUaToEn);

            List<MyDictionary> listOfDictionary = new List<MyDictionary> { dictionaryEnToUa, dictionaryUaToEn };
            MyDictionarys myDictionarys = new MyDictionarys(listOfDictionary);

            // ---------------------------------------------------------------

            int choice;
            do
            {
                choice = Menu();

                switch (choice)
                {
                    case 1:
                        myDictionarys.AddWord();
                        break;
                    case 2:
                        myDictionarys.AddTranslation();
                        break;
                    case 3:
                        myDictionarys.ChangeWord();
                        break;
                    case 4:
                        myDictionarys.ChangeTranslation();
                        break;
                    case 5:
                        myDictionarys.DeleteWord();
                        break;
                    case 6:
                        myDictionarys.DeleteTranslation();
                        break;
                    case 7:
                        myDictionarys.FindTranslation();
                        break;
                    case 8:
                        myDictionarys.SortDictionary();
                        break;
                    case 9:
                        myDictionarys.ViewHistory();
                        break;
                    case 10:
                        myDictionarys.DeleteHistory();
                        break;
                    case 11:
                        myDictionarys.ViewLastRequests();
                        break;

                }


            } while (choice != 0);







        }
    }
}
