using Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ClassLib;

namespace Final
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Word> words = new List<Word> {
                new Word("Apple", new List<string>{ "Яблуко", "Ябко", "Яблучко" } ),
                new Word("Tomato", new List<string>{ "Помідор", "Томати", "Помадори" } ),
            };
            MyDictionary myDictionary = new MyDictionary("en-ua", words);
            //MyDictionary myDictionary = new MyDictionary();

            Console.WriteLine(myDictionary);
            myDictionary.LoadDataFromXml();
            myDictionary.SaveDataToXml();
            Console.WriteLine(myDictionary);
        
        
        
        
        }
    }
}
