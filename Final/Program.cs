using Dictionary;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
//using ClassLib;

namespace Final
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            // Для кирилиці
            Console.OutputEncoding = Encoding.UTF8;

            // Створення словника
            List<Word> wordsEnToUa = new List<Word> {
                new Word("Apple", new List<string>{ "Яблуко", "Ябко", "1" } ),
                new Word("Tomato", new List<string>{ "Помідор", "Томати", "1" } ),
                new Word("Egg", new List<string>{ "Яйце", "Яйко", "1" } ),
                new Word("1", new List<string>{ "1", "1", "1" } )
            };
            MyDictionary dictionaryEnToUa = new MyDictionary("En-Ua", wordsEnToUa);
            List<Word> wordsUaToEn = new List<Word> {
                new Word("Імя", new List<string>{ "Name", "Title", "Appellation" } ),
                new Word("Квітка", new List<string>{ "Flower", "Blossom", "Bloom" } ),
                new Word("Вартість", new List<string>{ "Cost", "Value", "Price" } )
            };
            MyDictionary dictionaryUaToEn = new MyDictionary("Ua-En", wordsUaToEn);

            List<MyDictionary> listOfDictionary = new List<MyDictionary> { dictionaryEnToUa, dictionaryUaToEn };
            MyDictionarys myDictionarys = new MyDictionarys(listOfDictionary);

            // ---------------------------------------------------------------

            int choice;
            do
            {
                Console.WriteLine(new string('-', 27));
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
                choice = Convert.ToInt32(Console.ReadLine());

                // ----------------------------------------------
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

                        break;
                    case 10:

                        break;

                }


            } while (true);



        
        
        
        
        }
    }
}
