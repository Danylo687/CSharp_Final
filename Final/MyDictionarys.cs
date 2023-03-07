using Dictionary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    [Serializable]
    public class MyDictionarys
    {
        public List<MyDictionary> Dictionarys { get; set; } = new List<MyDictionary>();

        public MyDictionarys() { Dictionarys = new List<MyDictionary>(); }
        public MyDictionarys(List<MyDictionary> dictionarys)
        {
            Dictionarys = dictionarys;
        }
        public MyDictionarys(MyDictionary dictionary)
        {
            Dictionarys.Add(dictionary);
        }
        // ------------------------------------------

        public void AddWord()
        {
            Console.Clear();
            Console.WriteLine("Choose dictionary");
            Console.WriteLine(new string('-', 20));
            for (int i = 0; i < Dictionarys.Count; i++)
            {
                int j = i + 1;
                Console.WriteLine($"{j} - {Dictionarys[i].Name}");
            }
            Console.WriteLine("0 - Back");
            Console.WriteLine(new string('-', 30));

            Console.Write("Enter choice: ");
            int selectedDictionary = Convert.ToInt32(Console.ReadLine());

            // ----------------------------------------------
            Console.Clear();
            if (selectedDictionary != 0)
            {
                Word addedWord = new Word();
                Console.Write("Enter word: ");
                addedWord.Name = Console.ReadLine();
                List<string> translations = new List<string>();
                Console.Write("Enter the number of word translations: ");
                int countOfTranslations = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < countOfTranslations; i++)
                {
                    int j = i + 1;
                    Console.Write($"Enter {j} translation: ");
                    addedWord.Interpretations.Add(Console.ReadLine());
                }

                Console.WriteLine("\n\n" + addedWord);
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void AddTranslation()
        {
            Console.Clear();
            Console.WriteLine("Choose dictionary");
            Console.WriteLine(new string('-', 20));
            for (int i = 0; i < Dictionarys.Count; i++)
            {
                int j = i + 1;
                Console.WriteLine($"{j} - {Dictionarys[i].Name}");
            }
            Console.WriteLine("0 - Back");
            Console.WriteLine(new string('-', 30));

            Console.Write("Enter choice: ");
            int selectedDictionary = Convert.ToInt32(Console.ReadLine()) - 1;

            // ----------------------------------------------
            bool added = false, isCorrect = true;
            do
            {
                Console.Clear();
                if (!isCorrect) Console.WriteLine("Incorrect word!!!");
                if (selectedDictionary != -1)
                {
                    Console.Write("Enter word: ");
                    string searchWord = Console.ReadLine();

                    if (Dictionarys[selectedDictionary].Words.Find(x => (x.Name == searchWord)) != null)
                    {
                        Console.Write("Enter translation: ");
                        Dictionarys[selectedDictionary].Words.Find(x => (x.Name == searchWord)).Interpretations.Add(Console.ReadLine());
                        isCorrect = true;
                        added = true;
                    }
                    else isCorrect = false;

                    Console.Clear();
                }
            } while (!added);

        }

        // ------------------------------------------
        public override string ToString()
        {
            string str = "";

            foreach (var dictionary in Dictionarys)
            {
                str += dictionary.ToString();
                str += new string('-', 50);
                str += "\n\n";
            }

            return str;
        }
    }
}
